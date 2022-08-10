# Development Strategy

## Table of contents
- [Introduction](#introduction)
- [General](#general)
- [Guidelines](#guidelines)
- [Conventions](#conventions)
- [Best Practices](#best-practices)
- [Tools and Frameworks](#tools-and-frameworks)

## Introduction

This document is a set of upfront decisions that allows the team to come up with an effective set of dos, don’ts and hows regarding 
the future application design, development and deployment, and move consistently through each step of a development project. 

## General

- Use GitHub folder structure (src, doc, test, build, tool)
- Use sqlproj project file for SQL databases
- Use the latest .NET LTS version. See [.NET Roadmap](https://github.com/dotnet/core/blob/main/roadmap.md)

## Guidelines

Area | Guideline
------------ | -------------
Change Management | - [GitHub Flow](https://guides.github.com/introduction/flow/) <br> - [Semantic Versioning](https://semver.org/) <br> - [Code Review Guidelines](https://google.github.io/eng-practices/review/) <br> - [Changelog Guidelines](https://keepachangelog.com/en/1.0.0/)
Security | - [OWASP Top 10 - 2021](https://owasp.org/Top10/) <br> - [.NET Security Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html)
Architecture | - [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) <br> - [The Twelve-Factor App](https://12factor.net/)
Process | - [Scrum Guide](https://scrumguides.org/scrum-guide.html) <br> - [Kanban Guide for Scrum Teams](https://www.scrum.org/resources/kanban-guide-scrum-teams)
Documentation | - [Technical Writing Style Guide](https://docs.microsoft.com/en-us/style-guide/welcome/)

## Conventions
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Azure Resources Naming Conventions](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)

## Best Practices

- [Asynchronous Programming](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md)
- [ASP.NET Core](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AspNetCoreGuidance.md)
- [Unit testing best practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) 
- Clean Architecture / SOLID / KISS / YAGNI / DRY 
- [C# static code analysis](https://rules.sonarsource.com/csharp)
- [TypeScript TypeScript static code analysis](https://rules.sonarsource.com/typescript)
- [T-SQL static code analysis](https://rules.sonarsource.com/tsql)

## Tools and Frameworks

Area | Packages
------------ | -------------
Testing | - [Specflow](https://specflow.org/tools/specflow/) <br> - [xUnit](https://xunit.net/) <br> - [nSubstitute](https://nsubstitute.github.io/) <br> - [Fluent Assertions](https://fluentassertions.com/) <br> - [Fluent Validations](https://fluentvalidation.net/) <br> - [AutoFixture](https://autofixture.github.io/) <br> - [BenchmarkDotNet](https://benchmarkdotnet.org/) <br> - [Coverlet](https://dotnetfoundation.org/projects/coverlet) <br> - [NBomber](https://github.com/PragmaticFlow/NBomber) <br> - [Playwright](https://playwright.dev/dotnet/docs/next/intro)
Logging | - [Serilog](https://serilog.net/) <br> - [SEQ](https://datalust.co/seq)
Architecture | - [Clean Architecture Solution Template](https://github.com/jasontaylordev/CleanArchitecture)
Worker Service  | - [Quartz.NET](https://www.quartz-scheduler.net/) <br> - [Hangfire](https://www.hangfire.io/)
API | - [Fluent API](https://github.com/mariotoffia/FluentDocker) <br> - [Asp.Versioning.Http](https://www.nuget.org/packages/Asp.Versioning.Http) <br> - [Microsoft.Extensions.Diagnostics.HealthChecks](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks/) <br> - [Guard Clauses](https://github.com/ardalis/GuardClauses)
Build | - [Nuke](https://nuke.build/) <br> - [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) <br> 
SMTP Testing | - [Papercut](https://github.com/ChangemakerStudios/Papercut-SMTP)
Tools | - [CommandLineParser](https://www.nuget.org/packages/CommandLineParser/)

## Code Quality

- https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/
- https://rules.sonarsource.com/csharp (https://www.nuget.org/packages/SonarAnalyzer.CSharp/)
- https://docs.devexpress.com/CodeRushForRoslyn/116021/static-code-analysis/analyzers-library

```xml
  <PropertyGroup>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <CodeAnalysisTreatWarningsAsErrors>true</CodeAnalysisTreatWarningsAsErrors>
  </PropertyGroup>
```


# Reference Material
- https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health
