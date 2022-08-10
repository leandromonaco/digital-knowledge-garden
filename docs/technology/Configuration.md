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

# References

- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments
- https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/setx
- https://stackoverflow.com/questions/53870781/asp-net-core-addenvironmentvariables-doesnt-load-variables
