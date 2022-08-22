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

Action<Guid, string> ConsoleAppRunner = (userIdValue, passwordValue) =>
{
    ConsoleAppHelper.ResetPassword(userIdValue, passwordValue);
    Console.ReadLine();
};

rootCommand.SetHandler(ConsoleAppRunner, userIdArgument, passwordArgument);

await rootCommand.InvokeAsync(args);
```

# Publish CLI Tool
TBA
