- [Benefits of Coding Standards](https://www.youtube.com/watch?v=ndDcJt6XAaU)
- https://awesome-guidelines.com/

# Tools
https://snyk.io/code-checker

# Coding Standards

## Clean Code

✅ Detect and address Code Smells with [Sonarlint](https://www.sonarlint.org/visualstudio/ "https://www.sonarlint.org/visualstudio/")

✅ Follow Clean Code [Programming Principles](https://github.com/webpro/programming-principles "https://github.com/webpro/programming-principles")

✅ Follow Clean Code Best Practices: [.NET](https://github.com/thangchung/clean-code-dotnet "https://github.com/thangchung/clean-code-dotnet") | [Typescrypt](https://github.com/labs42io/clean-code-typescript "https://github.com/labs42io/clean-code-typescript")

✅ Follow Unit Testing Best Practices: [.NET](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices "https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices")

✅ Follow Coding Style Guidelines: [C#](https://google.github.io/styleguide/csharp-style.html "https://google.github.io/styleguide/csharp-style.html") | [TypeScript](https://google.github.io/styleguide/tsguide.html "https://google.github.io/styleguide/tsguide.html") | [Angular](https://angular.io/guide/styleguide#angular-coding-style-guide "https://angular.io/guide/styleguide#angular-coding-style-guide") | [SQL](https://www.sqlstyle.guide/ "https://www.sqlstyle.guide/")

## APIs

✅ Follow [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines "https://github.com/Microsoft/api-guidelines")

## Security

✅ Follow Security Guidelines:

- Detect and address Security issues with [Snyk Code](https://marketplace.visualstudio.com/items?itemName=snyk-security.snyk-vulnerability-scanner-vs-2022)
-   [OWASP for .NET](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html "https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html")
     
-   [OWASP TOP 10](https://learn.securecodewarrior.com/guidelines "https://learn.securecodewarrior.com/guidelines")
    
-   [CWE TOP 25](https://cwe.mitre.org/top25/archive/2022/2022_cwe_top25.html "https://cwe.mitre.org/top25/archive/2022/2022_cwe_top25.html")
    
-   [APIs](https://github.com/shieldfy/API-Security-Checklist "https://github.com/shieldfy/API-Security-Checklist")

# Guidelines

- [Secure Coding Guidelines](https://learn.securecodewarrior.com/guidelines)
- https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html
- https://github.com/treffynnon/sqlstyle.guide
- https://github.com/webpro/programming-principles
- https://github.com/thangchung/clean-code-dotnet
- https://github.com/davidfowl/AspNetCoreDiagnosticScenarios
- https://github.com/davidfowl/DotNetCodingPatterns
- https://github.com/mgechev/angular-performance-checklist
- https://github.com/labs42io/clean-code-typescript

# Style Guides

- [C#](https://google.github.io/styleguide/csharp-style.html)
- [TypeScript](https://google.github.io/styleguide/tsguide.html)
- [Angular](https://angular.io/guide/styleguide#angular-coding-style-guide)
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Azure Resources Naming Conventions](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)

# Linting

Linting is essentially a form of static code analysis. It analyzes the code you wrote against some rules for stylistic or programmatic errors. Think of it as a tool that flags suspicious usage in software.

A linter can help you save a lot of time by:

- Preventing broken code from being pushed
- Helping establish coding best practices
- Building guidelines for code layout and format
- Helping code reviews be a lot smoother
- Flagging bugs in your code from syntax errors

Given the useful nature of linting tools, you would ideally want to run a linter before any code reviews happen on every single piece of code that is pushed to your repository. This definitely helps you write better, more readable, and more stable code.

## Super Linter


You first want to pull the latest Docker container down from DockerHub with this command:

    docker pull github/super-linter:latest

To run this container you then run the following:

    docker run -e RUN_LOCAL=true -e USE_FIND_ALGORITHM=true -v /project/directory:/tmp/lint github/super-linter

Notice a couple of things here:

-   We run it with the `RUN_LOCAL` flag to bypass some of the GitHub Actions checks. This automatically sets `VALIDATE_ALL_CODEBASE` to true.
-   We map our local codebase to `/tmp/lint` so that the linter can pick up the code.
-   The way we set environment variables is of course different, but the overall process of running the GitHub Super Linter remains the same.

# Pre-Commit Hooks

https://alirezanet.github.io/Husky.Net/guide/#features


# Nuget Packages

- [SonarAnalyzer.CSharp](https://www.nuget.org/packages/SonarAnalyzer.CSharp/)

# Rules Catalog

- [SonarSource](https://rules.sonarsource.com/csharp)
- [DevExpress](https://docs.devexpress.com/CodeRushForRoslyn/116021/static-code-analysis/analyzers-library)

# Code Quality Rules

See [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/)

```xml
<PropertyGroup>
  <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  <CodeAnalysisTreatWarningsAsErrors>true</CodeAnalysisTreatWarningsAsErrors>
</PropertyGroup>
```


# Best Practices

- [Asynchronous Programming](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md)
- [ASP.NET Core](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AspNetCoreGuidance.md)
- [Unit testing best practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) 
- Clean Architecture / SOLID / KISS / YAGNI / DRY 
- [C# static code analysis](https://rules.sonarsource.com/csharp)
- [TypeScript TypeScript static code analysis](https://rules.sonarsource.com/typescript)
- [T-SQL static code analysis](https://rules.sonarsource.com/tsql)