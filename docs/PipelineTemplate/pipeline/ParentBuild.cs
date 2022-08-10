using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NerdbankGitVersioning;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.Octopus;
using Nuke.Common.Utilities.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

namespace NukePipeline
{

    [CheckBuildProjectConfigurations]
    [ShutdownDotNetAfterServerBuild]
    public class ParentBuild : NukeBuild
    {

        public static int Main() => Execute<ParentBuild>(x => x.CreateRelease);

        [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
        //readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
        readonly Configuration Configuration = Configuration.Release;

        [Parameter] string OctopusServerUrl;
        [Parameter] string OctopusApiKey;
        [Parameter] string OctopusSpaceId;

        [Solution] readonly Solution Solution;
        AbsolutePath SolutionDirectory => RootDirectory.Parent;
        AbsolutePath SourceDirectory => SolutionDirectory / "src";
        AbsolutePath TestDirectory => SolutionDirectory / "test";
        AbsolutePath ToolDirectory => SolutionDirectory / "tools";
        AbsolutePath OutputDirectory => SolutionDirectory / "output";

        DeploymentList _deploymentList;

        IReadOnlyCollection<AbsolutePath> _projectFiles;

        Dictionary<string, string> _versions = new Dictionary<string, string>();

        public Target Initialize => _ => _
            .Executes(() =>
            {
                SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                TestDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                ToolDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                EnsureCleanDirectory(OutputDirectory);
                LoadDeploymentFile();
                _projectFiles = SolutionDirectory.GlobFiles("**/*.csproj");
            });

        public Target Restore => _ => _
            .DependsOn(Initialize)
            .Executes(() =>
            {
                NuGetTasks.NuGetRestore(s => s.SetTargetPath(SolutionDirectory));
            });

        public Target Versioning => _ => _
        .DependsOn(Restore)
              .Executes(() =>
              {
                  foreach (var projectFile in _projectFiles)
                  {
                      string id = Path.GetFileNameWithoutExtension(projectFile);
                      var versionResult = NerdbankGitVersioningTasks.NerdbankGitVersioningGetVersion(v => v.SetProcessWorkingDirectory(projectFile.Parent).SetProcessArgumentConfigurator(a => a.Add("-f json"))).Result;
                      NerdbankGitVersioningTasks.NerdbankGitVersioningSetVersion(v => v.SetProject(projectFile.Parent)
                                                                                       .SetVersion(versionResult.Version)
                                                                                       );
                      _versions.Add(id, versionResult.Version);
                  }

              });

        public Target Compile => _ => _
        .DependsOn(Versioning)
        .Executes(() =>
        {
            foreach (var projectFile in _projectFiles)
            {
                //Ignore build and test folders
                if (!projectFile.ToString().ToLower().Contains("build") && !projectFile.ToString().Contains("test"))
                {
                    var id = Path.GetFileNameWithoutExtension(projectFile);
                    var buildProfile = GetBuildProfile(id);
                    FileInfo fileInfo = new FileInfo(projectFile);
                    var buildDestination = $@"{fileInfo.Directory}\bin";

                    switch (buildProfile)
                    {
                        case "netcore":
                            MSBuildTasks.MSBuild(s => s.SetTargetPath(projectFile)
                                                     .SetConfiguration(Configuration)
                                                     .SetProperty("DeployOnBuild", "true")
                                                     .SetProperty("Platform", "AnyCPU")
                                                     .SetProperty("PublishUrl", buildDestination)
                                                     .SetProperty("DeployDefaultTarget", "WebPublish")
                                                     .SetProperty("WebPublishMethod", "FileSystem")
                                                     .SetProperty("SelfContained", "true")
                                                     .SetProperty("RuntimeIdentifier", "win-x64")
                                                     .SetMSBuildVersion(MSBuildVersion.VS2019)
                                                     .SetVerbosity(MSBuildVerbosity.Detailed)
                                                     .SetTargets("Restore", "Build", "Publish")
                                                  );
                            break;
                        case "web48":
                            MSBuildTasks.MSBuild(s => s.SetTargetPath(projectFile)
                                               .SetConfiguration(Configuration)
                                               .SetProperty("DeployOnBuild", "true")
                                                .SetProperty("Platform", "AnyCPU")
                                                .SetProperty("PublishUrl", buildDestination)
                                                .SetMSBuildVersion(MSBuildVersion.VS2019)
                                                .SetVerbosity(MSBuildVerbosity.Detailed)
                                                .SetProperty("DeployDefaultTarget", "WebPublish")
                                                .SetProperty("WebPublishMethod", "FileSystem")
                                               .SetTargets("Build", "Publish")
                                            );
                            break;
                        default:
                            MSBuildTasks.MSBuild(s => s.SetTargetPath(projectFile)
                                            .SetConfiguration(Configuration)
                                            .SetProperty("DeployOnBuild", "true")
                                            .SetProperty("Platform", "AnyCPU")
                                            .SetMSBuildVersion(MSBuildVersion.VS2019)
                                            .SetVerbosity(MSBuildVerbosity.Detailed)
                                            .SetProperty("PublishUrl", buildDestination)
                                            .SetProperty("DeployDefaultTarget", "WebPublish")
                                            .SetProperty("WebPublishMethod", "FileSystem")
                                            );
                            break;
                    }
                }
            }



        });

        public Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            foreach (var projectFile in _projectFiles)
            {
                string id = Path.GetFileNameWithoutExtension(projectFile);
                Logger.Info($"Compiling project - {id}");
                if (IsDeployable(id))
                {
                    var sourcePath = $"{projectFile.Parent}\\bin";
                    var targetPath = $"{OutputDirectory}\\{id}";

                    //if it's a .NET Core Project, override source path
                    var directories = new List<string>();
                    var netCoreDirectories = Directory.GetDirectories(sourcePath, "*win-x64*", SearchOption.AllDirectories).ToArray();
                    var netFrameworkDirectories = Directory.GetDirectories(sourcePath, "*release*", SearchOption.AllDirectories).ToArray();
                    directories.AddRange(netCoreDirectories);
                    directories.AddRange(netFrameworkDirectories);
                    if (directories.Count > 0)
                    {
                        sourcePath = directories.FirstOrDefault();
                    }

                    Logger.Info($"Source Path - {sourcePath}");
                    Logger.Info($"Target Path - {targetPath}");
                    CopyDirectoryRecursively(sourcePath, targetPath);
                    DeleteUnwantedFiles(targetPath);
                    OctopusTasks.OctopusPack(o => o.SetBasePath(targetPath)
                                                   .SetOutputFolder(OutputDirectory)
                                                   .SetId(id)
                                                   .SetVersion(_versions.GetValueOrDefault(id)));

                    DeleteDirectory(targetPath);
                }
            }




        });

        public Target Push => _ => _
                  .DependsOn(Pack)
                  .Executes(() =>
                  {
                      var packages = SolutionDirectory.GlobFiles("**/output/*.nupkg");
                      foreach (var package in packages)
                      {

                          try
                          {
                              OctopusTasks.OctopusPush(o => o.SetServer(OctopusServerUrl)
                                                         .SetApiKey(OctopusApiKey)
                                                         .SetSpace(OctopusSpaceId)
                                                         .SetPackage(package));
                          }
                          catch
                          {
                              //if the package exists the default behaviour is throwing an exception
                          }
                      }

                  });

        public Target CreateRelease => _ => _
                  .DependsOn(Push)
                  .Executes(() =>
                  {
                      foreach (var projectFile in _projectFiles)
                      {
                          string id = Path.GetFileNameWithoutExtension(projectFile);

                          if (IsDeployable(id))
                          {
                              var releaseProjectName = _deploymentList.Applications.Where(a => a.Id.Equals(id)).FirstOrDefault().DeploymentProjectName;
                              var releaseVersion = _versions.GetValueOrDefault(id);

                              //if the package exists the default behaviour is to reject the package
                              OctopusTasks.OctopusCreateRelease(o => o.SetServer(OctopusServerUrl)
                                                                 .SetApiKey(OctopusApiKey)
                                                                 .SetSpace(OctopusSpaceId)
                                                                 .SetProject(releaseProjectName)
                                                                 .SetVersion(releaseVersion)
                                                                 .EnableIgnoreExisting());
                          }
                      }

                  });

        /// <summary>
        /// Check in deployment list to see if the project is deployable
        /// </summary>
        /// <param name="id">Source Project Id (csproj)</param>
        /// <returns></returns>
        private bool IsDeployable(string id) => _deploymentList?.Applications.Count(a => a.Id.Equals(id)) > 0;

        private string GetBuildProfile(string id)
        {
            if (IsDeployable(id))
            {
                var app = _deploymentList?.Applications.Where(a => a.Id.Equals(id)).FirstOrDefault();
                return app.BuildProfile;
            }

            return null;
        }

        private void LoadDeploymentFile()
        {
            FileInfo buildAssembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
            using (StreamReader r = new StreamReader($"{buildAssembly.Directory}\\Deployment\\deployment_list.json"))
            {
                string json = r.ReadToEnd();
                _deploymentList = JsonSerializer.Deserialize<DeploymentList>(json);
            }
        }

        private void DeleteUnwantedFiles(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    Logger.Info($"Current file {file}");
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.Extension == ".dll" || fileInfo.Extension == ".pdb" || fileInfo.Extension == ".xml")
                    {
                        Logger.Info($"Deleting file {file}");
                        File.Delete(file);
                    }
                }

            }
        }
    }

}