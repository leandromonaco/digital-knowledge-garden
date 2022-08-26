

# Packages

- [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)

# Code
```csharp
private static ConfigurationManager GetConfiguration(ConfigurationManager configurationManager)
{
    configurationManager
                 .SetBasePath(Environment.CurrentDirectory)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables("AppPrefix:")
                 .Build();

    return configurationManager;
}
```

# Add Configuration File to csproj
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
</ItemGroup>
```

# Cross-Platform Support

The : separator doesn't work with environment variable [hierarchical keys](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0#non-prefixed-environment-variables) on all platforms. __, the double underscore, is supported by all platforms. 

> **Note**
> ```AppPrefix:ModuleConfiguration:Infrastructure:Redis:Port``` would need to be translated to ```AppPrefix__ModuleConfiguration__Infrastructure__Redis__Port```

# Set Environment Variable

> **Warning**
> When creating/removing Environment Variables, Visual Studio MUST be restarted to pick up the changes.

- ```setx Lambda__ModuleConfiguration__Infrastructure__Cognito__ValidIssuer   "SOME VALUE" /M```
- ```setx Lambda__ModuleConfiguration__Infrastructure__Cognito__ClientId  "SOME VALUE" /M```
- ```setx ASPNETCORE_ENVIRONMENT "Development" /M``` or ```setx ASPNETCORE_ENVIRONMENT "Staging" /M``` or ```setx ASPNETCORE_ENVIRONMENT "Production" /M```

# Safe storage of app secrets in development

1. Navigate to your .NET Core Project folder
2. Run ```dotnet user-secrets init```
3. Run ```dotnet user-secrets set "Segment:WriteKey" "some-write-key"```
4. Read the value in your application
```csharp
var builder = WebApplication.CreateBuilder(args);
var segmentWriteKey = builder.Configuration["Segment:WriteKey"];
```

Read more on [ASP.NET Core Official Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)

# Documentation

- [Configuration in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration)
- [Use multiple environments in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- [setx](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/setx)

# Troubleshooting

- **Issue:** ASP.NET Core: AddEnvironmentVariables doesn't load variables
- **Cause:** You probably just declared your Environment Variables hence Visual Studio does not see them.
- **Resolution:** Restart your Visual Studio.
