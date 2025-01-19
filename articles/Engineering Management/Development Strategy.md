# Software Development Strategy

## Table of contents
- [Introduction](#introduction)
- [General](#general)
- [Guidelines](#guidelines)
- [Tools, Frameworks and Libraries](#tools-frameworks-and-libraries)
- [Coding Standards](#coding-standards)

## Introduction

This document is a set of upfront decisions that allows the team to come up with an effective set of dos, don’ts and how's regarding 
the future application design, development and deployment, and move consistently through each step of a development project.
## General
- Use GitHub folder structure (src, doc, test, build, tool)
- Use sqlproj project file for SQL databases
- Use the latest .NET LTS version. See [.NET Roadmap](https://github.com/dotnet/core/blob/main/roadmap.md)
## Guidelines

Area | Guideline
------------ | -------------
Change Management | - [GitHub Flow](https://guides.github.com/introduction/flow/) <br> - [Semantic Versioning](https://semver.org/) <br> - [Code Review Guidelines](https://google.github.io/eng-practices/review/) <br> - [Changelog Guidelines](https://keepachangelog.com/en/1.0.0/) <br> - [Conventional Commits](https://www.conventionalcommits.org/)
Security | - [OWASP Top 10 - 2021](https://owasp.org/Top10/) <br> - [.NET Security Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html)
Architecture | - [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) <br> - [The Twelve-Factor App](https://12factor.net/)
Process | - [Scrum Guide](https://scrumguides.org/scrum-guide.html) <br> - [Kanban Guide for Scrum Teams](https://www.scrum.org/resources/kanban-guide-scrum-teams)
Documentation | - [Technical Writing Style Guide](https://docs.microsoft.com/en-us/style-guide/welcome/)

## Tools, Frameworks and Libraries
- [Nuget Trends](https://nugettrends.com/)
- `dotnet list package` [Documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package)
  
  Area | Packages
  ------------ | -------------
  Testing | - [Specflow](https://specflow.org/tools/specflow/) <br> - [xUnit](https://xunit.net/) <br> - [nSubstitute](https://nsubstitute.github.io/) <br> - [Fluent Assertions](https://fluentassertions.com/) <br> - [AutoFixture](https://autofixture.github.io/) <br> - [BenchmarkDotNet](https://benchmarkdotnet.org/) <br> - [Coverlet](https://dotnetfoundation.org/projects/coverlet) <br> - [NBomber](https://github.com/PragmaticFlow/NBomber) <br> - [Playwright](https://playwright.dev/dotnet/docs/next/intro) <br> - [WireMock.Net](https://github.com/WireMock-Net/WireMock.Net) <br> - [TestContainers](https://github.com/testcontainers/testcontainers-dotnet) <br> - [LocalStack](https://github.com/localstack/localstack) <br> - [Spectre.Console](https://github.com/spectreconsole/spectre.console)
  Logging | - [Serilog](https://serilog.net/) <br> - [SEQ](https://datalust.co/seq)
  Architecture | - [Clean Architecture Solution Template](https://github.com/jasontaylordev/CleanArchitecture)
  Worker Service  | - [Quartz.NET](https://www.quartz-scheduler.net/) <br> - [Hangfire](https://www.hangfire.io/)
  API | - [Fluent API](https://github.com/mariotoffia/FluentDocker) <br> - [Asp.Versioning.Http](https://www.nuget.org/packages/Asp.Versioning.Http) <br> - [Microsoft.Extensions.Diagnostics.HealthChecks](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks/) <br> - [Guard Clauses](https://github.com/ardalis/GuardClauses) <br> - [AWS Lambda Powertools for .NET](https://github.com/awslabs/aws-lambda-powertools-dotnet)
  Build | - [Nuke](https://nuke.build/) <br> - [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) <br> 
  SMTP Testing | - [Papercut](https://github.com/ChangemakerStudios/Papercut-SMTP)
  CLI Tools | - [System.CommandLine](https://docs.microsoft.com/en-us/dotnet/standard/commandline/)
  Code Analyzers | - [SonarAnalyzer.CSharp](https://github.com/SonarSource/sonar-dotnet) <br> - [FluentAssertions.Analyzers](https://github.com/fluentassertions/fluentassertions.analyzers)
  
## Code Reviews
- https://github.com/mgreiler/code-review-checklist
- https://github.com/joho/awesome-code-review
- [Benefits of Coding Standards](https://www.youtube.com/watch?v=ndDcJt6XAaU)
- https://awesome-guidelines.com/
# Tools
https://snyk.io/code-checker

## Feature Flags

[[Feature Flag Management]]

## Logging

Always use *Structured Logging*, which makes it easier to store and query log-events.
https://datatracker.ietf.org/doc/html/rfc7807
 
## Health Checks

A health check API is a separate REST service that is implemented within a microservice component that quickly returns the operational status of the service and an indication of its ability to connect to downstream dependent services.
Example: myservice.com/health

## Caching

A distributed cache is a cache shared by multiple app servers, typically maintained as an external service to the app servers that access it. A distributed cache can improve the performance and scalability of an application, especially when the application is hosted by a cloud service or a server farm.

When cached data is distributed, the data:

    - Is coherent (consistent) across requests to multiple servers.
    - Survives server restarts and app deployments.
    - Doesn't use local memory.

## API Versioning
Versioning is an important aspect of any mature web service. Microsoft has published REST API guidelines that require that all compliant services must support explicit versioning. This ensures that clients can rely on services to be stable over time, while still enabling service changes and new features. Detailed information about the recommended guidance can be found in the [Microsoft REST Guidelines for versioning](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md#12-versioning).

### Example

- https://service-a.com/{instanceId}/endpoint?api-version=1.0
- https://service-a.com/{instanceId}/endpoint?api-version=2.0

### Code
```
// Define a 'version set' that applies to an API group
var versionSet = app.NewApiVersionSet()
                    .HasApiVersion(1.0)
                    .HasApiVersion(2.0)
                    .ReportApiVersions()
                    .Build();

app.MapGet("{instanceId}/endpoint", [Authorize] async (IMediator mediator, [FromHeader] string authorization, Guid instanceId, CancellationToken cancellationToken) => await mediator.Send(new RequestV1() { InstanceId = instanceId }, cancellationToken))
   .WithApiVersionSet(versionSet)
   .MapToApiVersion(1.0);

app.MapGet("{instanceId}/endpoint", [Authorize] async (IMediator mediator, [FromHeader] string authorization, Guid instanceId, CancellationToken cancellationToken) => await mediator.Send(new RequestV2() { InstanceId = instanceId }, cancellationToken))
   .WithApiVersionSet(versionSet)
   .MapToApiVersion(2.0);
```

## Rate Limiting
[Rate Limiting](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/)

## Output Caching
https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-7-preview-6/

## Paging
https://devblogs.microsoft.com/odata/up-running-w-odata-in-asp-net-6/

# Coding Standards
## Clean Code

- https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/configuration-options
- https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/code-style-rule-options
- https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/code-quality-rule-options
- https://learn.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options

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
- [OWASP for .NET](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html "https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html")
- [OWASP TOP 10](https://learn.securecodewarrior.com/guidelines "https://learn.securecodewarrior.com/guidelines")
- [CWE TOP 25](https://cwe.mitre.org/top25/archive/2022/2022_cwe_top25.html "https://cwe.mitre.org/top25/archive/2022/2022_cwe_top25.html")
- [APIs](https://github.com/shieldfy/API-Security-Checklist "https://github.com/shieldfy/API-Security-Checklist")
# Guidelines
- [Secure coding Guidelines Microsoft](https://docs.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines)
- [Secure Coding Guidelines SCW](https://learn.securecodewarrior.com/guidelines)
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
- We run it with the `RUN_LOCAL` flag to bypass some of the GitHub Actions checks. This automatically sets `VALIDATE_ALL_CODEBASE` to true.
- We map our local codebase to `/tmp/lint` so that the linter can pick up the code.
- The way we set environment variables is of course different, but the overall process of running the GitHub Super Linter remains the same.

# Pre-Commit Hooks
  https://alirezanet.github.io/Husky.Net/guide/#features


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
## Reference Material
- https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health
- https://aws.amazon.com/blogs/compute/introducing-the-net-6-runtime-for-aws-lambda/
- https://aws.amazon.com/blogs/compute/building-serverless-net-applications-on-aws-lambda-using-net-7/
- https://docs.aws.amazon.com/codedeploy/latest/userguide/tutorial-lambda-sam-template.html
- https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/sam-specification.html
- https://aws.amazon.com/architecture/well-architected
- https://aws.amazon.com/architecture/icons/
- https://aws.amazon.com/blogs/architecture/lets-architect-creating-resilient-architecture
- https://aws.amazon.com/blogs/architecture/modernization-pathways-for-a-legacy-net-framework-monolithic-application-on-aws
- https://aws.amazon.com/blogs/compute/best-practices-for-organizing-larger-serverless-applications/
- https://aws.amazon.com/blogs/architecture/throttling-a-tiered-multi-tenant-rest-api-at-scale-using-api-gateway-part-1/?nc1=b_rp
- https://aws.amazon.com/blogs/architecture/throttling-a-tiered-multi-tenant-rest-api-at-scale-using-api-gateway-part-2
- https://aws.amazon.com/cdk/
