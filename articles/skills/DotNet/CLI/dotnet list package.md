- [dotnet list package](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package)  command in the .NET Core CLI tools to fetch installed packages for a given solution or project. Use it like so from the Windows command line:
  
  `dotnet list "C:\Source\MySolution\MySolution.sln" package`
  
  It works on both .NET Framework and .NET Core projects.
  
  **Note:** For this command to work, the solution must use the [new NuGet PackageReference format](https://learn.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference) for referencing NuGet packages.
  
  Migration is as easy as right-clicking ``packages.config``, and clicking ``Migrate packages.config to 
    PackageReference...``, then restoring packages by building the solution.
# Parameters
- `--vulnerable`
- Lists packages that have known security vulnerabilities. Cannot be combined with  `--deprecated`  or  `--outdated`  options. Nuget.org is the source of information about vulnerabilities. For more information, see [Vulnerabilities](https://learn.microsoft.com/en-us/nuget/api/registration-base-url-resource), [How to Scan NuGet Packages for Security Vulnerabilities](https://devblogs.microsoft.com/nuget/how-to-scan-nuget-packages-for-security-vulnerabilities/), and [Security best practices for package consumers](https://learn.microsoft.com/en-us/nuget/concepts/security-best-practices).

## How to prioritize vulnerable packages

After `dotnet list package --vulnerable` flags a package, use the advisory details to assess both severity and likelihood of exploitation.

- **CVE**: The Common Vulnerabilities and Exposures identifier is the issue ID you can track across GitHub, NVD, vendor advisories, and security tools.
- **CVSS score**: Most CVE records include a Common Vulnerability Scoring System score from `0.0` to `10.0` to describe impact severity. Under CVSS v3.x, `9.0-10.0` is critical, `7.0-8.9` is high, `4.0-6.9` is medium, `0.1-3.9` is low, and `0.0` is none.
- **EPSS score**: The Exploit Prediction Scoring System estimates the probability that a vulnerability will be exploited in the wild. Higher EPSS values usually deserve faster triage, especially when they are paired with a high CVSS score.

### Suggested triage flow

1. Capture the **CVE ID** from the NuGet advisory.
2. Review the **CVSS score** to understand technical severity.
3. Check the **EPSS score** to understand exploit likelihood.
4. Prioritize remediation first for packages with both a high CVSS score and a high EPSS score.

Tags: #type/reference #status/evergreen #topic/software-engineering/dotnet
