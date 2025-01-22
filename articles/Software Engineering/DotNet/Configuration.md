

## Packages

- [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)
- [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables)
- [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets/)

## Implementation

**Singleton**
```csharp
using Microsoft.Extensions.Configuration;

public static class ConfigurationManager
{
    private static IConfigurationRoot _configuration;
    public static IConfigurationRoot Configuration
    {
        get
        {
            if (_configuration == null)
            {
                _configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppContext.BaseDirectory)
                                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                                        .AddEnvironmentVariables("AppId:")
                                        .AddUserSecrets("3490e6ac-9364-432d-9bfb-7c37692752cb")
                                        .Build();
            }
            return _configuration;
        }
    }
}
```

**Usage**

`ConfigurationManager.Configuration["SomeConfig"]`

## Code Sample
### .NET Console App
```csharp
 var configuration = new ConfigurationBuilder()
                                        .SetBasePath(AppContext.BaseDirectory)
                                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                        .Build();
```

### ASP.NET
```csharp
private static ConfigurationManager GetConfiguration(ConfigurationManager configurationManager)
{
    configurationManager
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables("AppPrefix:")
                 .Build();

    return configurationManager;
}
```

## Add Configuration File to csproj
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
</ItemGroup>
```

## Cross-Platform Support

The : separator doesn't work with environment variable [hierarchical keys](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0#non-prefixed-environment-variables) on all platforms. `__`, the double underscore, is supported by all platforms. 

| :warning: WARNING          |
|:---------------------------|
|`AppPrefix:ModuleConfiguration:Infrastructure:Redis:Port` would need to be translated to `AppPrefix__ModuleConfiguration__Infrastructure__Redis__Port`|

## Set Environment Variable

| :warning: WARNING          |
|:---------------------------|
|When creating/removing Environment Variables, Visual Studio MUST be restarted to pick up the changes.|

- `setx Lambda__ModuleConfiguration__Infrastructure__Cognito__ValidIssuer   "SOME VALUE" /M`
- `setx Lambda__ModuleConfiguration__Infrastructure__Cognito__ClientId  "SOME VALUE" /M`
- `setx ASPNETCORE_ENVIRONMENT "Development" /M` or `setx ASPNETCORE_ENVIRONMENT "Staging" /M` or `setx ASPNETCORE_ENVIRONMENT "Production" /M`

## Safe storage of app secrets in development

1. Add a reference to the `Microsoft.Extensions.Configuration.UserSecrets` package
2. Navigate to your .NET project folder
3. Run `dotnet user-secrets init` (one-off per project)
4. Run `dotnet user-secrets set "Segment:WriteKey" "some-write-key"`
5. Read the value in your application
```csharp
var configuration = new ConfigurationBuilder().AddUserSecrets("[ID obtained from step 3]").Build();
var value = configuration["Segment:SomeConfig"];
```

Values are stored on ```C:\Users\<username>\AppData\Roaming\Microsoft\UserSecrets```

Read more on [ASP.NET Core Official Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)

## Documentation

- [Configuration in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration)
- [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Use multiple environments in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- [setx](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/setx)

## Troubleshooting

- **Issue:** ASP.NET Core: AddEnvironmentVariables doesn't load variables
- **Cause:** You probably just declared your Environment Variables hence Visual Studio does not see them.
- **Resolution:** Restart your Visual Studio.
