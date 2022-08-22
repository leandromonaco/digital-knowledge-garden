# Documentation

- [System.CommandLine overview](https://docs.microsoft.com/en-us/dotnet/standard/commandline/)

# Package

- [System.CommandLine](https://www.nuget.org/packages/System.CommandLine/)

# Code Example

```csharp
var userIdArgument = new Option<Guid>(name: "--userId", description: "User ID", getDefaultValue: () => Guid.Empty);
var passwordArgument = new Option<string>("--password", "New Password");

var rootCommand = new RootCommand();
rootCommand.Add(userIdArgument);
rootCommand.Add(passwordArgument);

rootCommand.SetHandler((userIdValue, passwordValue) =>
                                                            {
                                                                Console.WriteLine($"userId = {userIdValue}");
                                                                Console.WriteLine($"password = {passwordValue}");
                                                            },
                                                            userIdArgument, passwordArgument
                      );

await rootCommand.InvokeAsync(args);
```

# Publish CLI Tool
TBA
