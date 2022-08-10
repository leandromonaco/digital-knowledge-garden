[Entity Framework Core tools reference - .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Install/Update
1. Install EF command ```dotnet tool install -g dotnet-ef --version 3.0.0```
2. Update EF command (if required) ```dotnet tool update -g dotnet-ef --version 6.0.3```

## Create/Update Model (Database First)
1. csproj file must reference  ```Microsoft.EntityFrameworkCore.Design``` and ```Microsoft.EntityFrameworkCore.SqlServer``` nuget packages
2. Navigate to the folder where you want to store the model
3. Update EF Model Classes ```dotnet ef dbcontext scaffold "Server=localhost;Database=DbName;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Database -f```
    
