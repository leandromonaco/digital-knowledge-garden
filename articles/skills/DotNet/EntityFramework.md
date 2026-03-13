## EF CLI

- [Entity Framework Core tools reference - .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

### Commands
- Install:     `dotnet tool install --global dotnet-ef`
- Update:      `dotnet tool update --global dotnet-ef`

## Create/Update Model (Database First)
1. `.csproj` file must reference the following nuget packages:
    - `Microsoft.EntityFrameworkCore.Design` 
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Sqlite`
1. Navigate to the folder where you want to store the model
2. Update EF Model Classes

`dotnet ef dbcontext scaffold "Server=localhost;Database=DbName;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Database -f --project C:\Dev\Something.csproj`

`dotnet ef dbcontext scaffold "DataSource='C:\ScrumTeamSqlLite3.db" Microsoft.EntityFrameworkCore.Sqlite -o Database -f --project C:\Dev\Something.csproj`

## Connection String

- [Connection String Syntax](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax)

Search for `DbContext.cs` class

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connectionString = "Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer";
    optionsBuilder.UseSqlServer(connectionString);
}
```

## Logging

This will allow us to see the SQL Queries being executed

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connectionString = "Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer";
    optionsBuilder.LogTo(Console.Write, LogLevel.Trace)
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors()
                  .UseSqlServer(connectionString);
}
```
