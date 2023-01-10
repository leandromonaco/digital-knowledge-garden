- [dotnet list package](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package)  command in the .NET Core CLI tools to fetch installed packages for a given solution or project. Use it like so from the Windows command line:
  
  `dotnet list "C:\Source\MySolution\MySolution.sln" package`
  
  It works on both .NET Framework and .NET Core projects.
  
  **Note:** For this command to work, the solution must use the [new NuGet PackageReference format](https://learn.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference) for referencing NuGet packages.
  
  Migration is as easy as right-clicking ``packages.config``, and clicking ``Migrate packages.config to 
    PackageReference...``, then restoring packages by building the solution.
# Parameters
- `--vulnerable`
- Lists packages that have known [[Security]] vulnerabilities. Cannot be combined with  `--deprecated`  or  `--outdated`  options. Nuget.org is the source of information about vulnerabilities. For more information, see [Vulnerabilities](https://learn.microsoft.com/en-us/nuget/api/registration-base-url-resource) and [How to Scan NuGet Packages for Security Vulnerabilities](https://devblogs.microsoft.com/nuget/how-to-scan-nuget-packages-for-security-vulnerabilities/).