# Digital Knowledge Garden with Obsidian

![License](https://img.shields.io/badge/license-MIT-blue.svg) 
[![Star this repo](https://img.shields.io/github/stars/leandromonaco/digital-knowledge-garden?style=social)](https://github.com/leandromonaco/digital-knowledge-garden/stargazers)

> [!NOTE] 
> This site is live on https://leandromonaco.github.io/digital-knowledge-garden
> If you find this project helpful, please give it a star 🌟

## Table of Contents
1. [Toolkit](#toolkit)
2. [AI Vault Organizer](#ai-vault-organizer)
3. [GitHub Pages Configuration](#github-pages-configuration)
4. [Publish Website Changes](#publish-website-changes)


## Toolkit

- `winget install --id GitHub.GitHubDesktop`
- `winget install --id Obsidian.Obsidian`
- obsidian://show-plugin?id=webpage-html-export
- obsidian://show-plugin?id=obsidian-git

## AI Vault Organizer

🤖 **Automated vault maintenance and organization**

This repository includes an AI agent that helps keep your Obsidian vault organized and up to date.

**Features:**
- ✨ Automatically adds metadata (frontmatter) to markdown files
- 🔍 Detects broken internal links
- ⚠️ Identifies merge conflict markers
- 📅 Flags stale content (>2 years old)
- 🔄 Finds duplicate content

**Quick Start:**
```bash
# Dry run (preview changes):
python vault_organizer.py

# Apply changes:
python vault_organizer.py --apply
```

📖 See [VAULT_ORGANIZER_README.md](VAULT_ORGANIZER_README.md) for detailed documentation.

**Automation:**
The vault organizer runs automatically every Sunday via GitHub Actions and can be triggered manually from the Actions tab.

## GitHub Pages Configuration
![image](https://github.com/user-attachments/assets/88b4d3da-ec0e-4f1b-8c73-bd4b295f8459)


## Publish Website Changes
1. Delete all files in `digital-knowledge-garden\docs`
2. Export HTML![Obsidian_wbVfX1Bz2Y](https://github.com/user-attachments/assets/867ea0ea-f6fc-4972-b04b-7aabe9940f8d)
3. Push Git changes
4. A GitHub Action will be triggered to publish https://leandromonaco.github.io/digital-knowledge-garden
