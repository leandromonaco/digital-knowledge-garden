# Digital Knowledge Garden with Obsidian

![License](https://img.shields.io/badge/license-MIT-blue.svg) 
[![Star this repo](https://img.shields.io/github/stars/leandromonaco/digital-knowledge-garden?style=social)](https://github.com/leandromonaco/digital-knowledge-garden/stargazers)

> [!NOTE] 
> This site is live on https://leandromonaco.github.io/digital-knowledge-garden
> If you find this project helpful, please give it a star 🌟

## 📚 Knowledge Areas

### 🏢 Engineering Management
Resources, templates, and guides for engineering managers.
- [Overview](articles/Engineering%20Management/Overview.md) - Tech Lead vs Engineering Manager
- [Resources](articles/Engineering%20Management/Resources.md) - Curated reading list (Agile, Architecture, Careers, and more)
- [Goal Setting](articles/Engineering%20Management/Goal%20Setting/Goal%20Setting%20-%20Index.md) - OKRs and goal-setting frameworks
- [Knowledge Sharing](articles/Engineering%20Management/Goal%20Setting/Knowledge%20Sharing.md) - Best practices for sharing knowledge
- [Team Playbook](articles/Engineering%20Management/Team%20Playbook/Ways%20of%20Working.md) - Ways of working, DOR, DOD
- [Hiring](articles/Engineering%20Management/Hiring/Interview.md) - Interview guides and coding assessments
- [Health Monitor](articles/Engineering%20Management/Health%20Monitor/Questionnaire.md) - Team and manager health surveys

### 🛠️ Skills & Technologies
- [.NET](articles/skills/DotNet/Index.md) - ASP.NET, C#, Entity Framework, Minimal API, testing
- [AWS](articles/skills/Cloud/AWS/Index.md) - Services, CDK, SAM CLI, credentials
- [Azure](articles/skills/Cloud/Azure/Index.md) - Azure CLI and resources
- [Frontend](articles/skills/Frontend/Index.md) - HTML, CSS, JavaScript/TypeScript, Angular, React
- [AI](articles/skills/AI/Open%20AI.md) - OpenAI API and local LLMs with Ollama
- [Authentication](articles/skills/Authentication.md) - JWT, encryption, and OpenID Connect

### 🔧 Tools
- [Docker](articles/Tools/Docker%20Desktop.md) - Docker Desktop, CLI, and Compose
- [Git](articles/Tools/Git.md) - Git tips and workflows
- [VS Code](articles/Tools/VSCode.md) - Editor tips and extensions
- [GitHub Copilot](articles/Tools/GitHub%20Copilot.md) - AI pair programming
- [Kubernetes](articles/Tools/Kubernetes.md) - Container orchestration
- [PowerShell](articles/Tools/Powershell.md) - Scripting and automation
- [SQL Server](articles/Tools/Sql%20Server.md) - Database management

### 📖 How-to Guides
Step-by-step guides for common development tasks:
- [Build and Run Docker Containers](articles/How-to/Build%20and%20Run%20a%20Container%20with%20Docker.md)
- [BDD Tests with Playwright (TypeScript)](articles/How-to/BDD%20Test%20Cases%20using%20Playwright%20(TypeScript).md)
- [Git Workflows](articles/How-to/Git.md)
- [SQL Server Queries](articles/How-to/Useful%20SQL%20Server%20Queries.md)
- [Create Self-Signed Certificate](articles/How-to/Create%20Self-Signed%20Certificate.md)

### 📊 Cheatsheets
- [HTML](articles/cheatsheets/HTML.md)
- [CSS](articles/cheatsheets/CSS.md)
- [JavaScript & TypeScript](articles/cheatsheets/Javascript%20%26%20TypeScript.md)

### 🚀 Projects
- [Feature Flag Management](projects/Feature%20Flag%20Management.md)
- [Developer Experience Integrations](projects/Developer%20Experience%20Integrations/) - GitHub, JIRA, Google Calendar APIs

---

## Table of Contents
1. [Toolkit](#toolkit)
2. [GitHub Pages Configuration](#github-pages-configuration)
3. [Publish Website Changes](#publish-website-changes)


## Toolkit

- `winget install --id GitHub.GitHubDesktop`
- `winget install --id Obsidian.Obsidian`
- obsidian://show-plugin?id=webpage-html-export
- obsidian://show-plugin?id=obsidian-git

## GitHub Pages Configuration
![image](https://github.com/user-attachments/assets/88b4d3da-ec0e-4f1b-8c73-bd4b295f8459)


## Publish Website Changes
1. Delete all files in `digital-knowledge-garden\docs`
2. Export HTML![Obsidian_wbVfX1Bz2Y](https://github.com/user-attachments/assets/867ea0ea-f6fc-4972-b04b-7aabe9940f8d)
3. Push Git changes
4. A GitHub Action will be triggered to publish https://leandromonaco.github.io/digital-knowledge-garden

