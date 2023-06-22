# Nuke Build Setup

### Installation

https://nuke.build/docs/getting-started/installation/

1. Run ```dotnet tool install Nuke.GlobalTool --global```
2. Run ```nuke :setup```

![image](https://user-images.githubusercontent.com/5598150/178411271-aba9595f-1701-4eef-a973-379b0af50795.png)

- [Documentation](https://nuke.build/)
- [Cli-tools Support](https://nuke.build/docs/common/cli-tools/)

- See [Example](https://github.com/leandromonaco/Workbench/blob/main/MicroserviceTemplate/build/Build.cs)
- Run ```dotnet run --plan``` from build folder to see Execution Plan
- Run ```dotnet run --Param1 "value" --Param2 "value" --Param3 "value"```

Notes:

1. Install [nbgv .NET Core CLI tool](https://github.com/dotnet/Nerdbank.GitVersioning/blob/master/doc/nbgv-cli.md)
2. Add [nuget.config](https://github.com/leandromonaco/Documentation/blob/main/nuget.config) file next to your sln file (requires VS restart)
3. Create build folder under your application and copy the files from [PipelineTemplate](https://github.com/leandromonaco/Documentation/tree/main/PipelineTemplate)
4. Update Solution Name in the [.nuke/parameters.json](https://github.com/leandromonaco/Documentation/blob/5f67d5628d3217874dd82a3c6a6351e42f2adb69/PipelineTemplate/nuke/parameters.json#L3) file
5. Create the [version.json](https://github.com/leandromonaco/Documentation/blob/main/version.json) file under each component that must be versioned (required for GitVersioning to calculate the semantic version number)
6. Create deployment_list.json file (required for the pipeline to know which components should be packed for deployment)


https://github.com/OctopusDeploy/OctoVersion
