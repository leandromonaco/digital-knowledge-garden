# Digital Knowledge Garden with Obsidian

![License](https://img.shields.io/badge/license-MIT-blue.svg) 
[![Star this repo](https://img.shields.io/github/stars/leandromonaco/digital-knowledge-garden?style=social)](https://github.com/leandromonaco/digital-knowledge-garden/stargazers)

> [!NOTE] 
> If you find this project helpful, please give it a star 🌟

## Toolkit

- `winget install --id GitHub.GitHubDesktop`
- `winget install --id Obsidian.Obsidian`
- obsidian://show-plugin?id=webpage-html-export
- obsidian://show-plugin?id=obsidian-git

## GitHub Actions Configuration
TBA

## Publish Website Changes
1. Delete all files in `digital-knowledge-garden\docs`
2. Export HTML![Obsidian_wbVfX1Bz2Y](https://github.com/user-attachments/assets/867ea0ea-f6fc-4972-b04b-7aabe9940f8d)
3. Push Git changes
4. A GitHub Action will be triggered to publish https://leandromonaco.github.io/digital-knowledge-garden
