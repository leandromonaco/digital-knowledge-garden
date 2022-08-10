using AzP.Assistance.Build;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;


[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{

    public static int Main() => Execute<ParentBuild>(x => x.CreateRelease);

}
