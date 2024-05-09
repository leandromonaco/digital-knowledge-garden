Welcome to my **Digital Knowledge Garden** 🌱

"The more I learn, the more I realize how much I don't know" -Aristotle

This project was inspired by this [blog post](https://github.com/readme/guides/private-documentation)

## Toolkit

- `winget install --id Obsidian.Obsidian`
- [obsidian-git](https://github.com/denolehov/obsidian-git)
- [webpage-export](https://github.com/KosmosisDire/obsidian-webpage-export)
- GitHub Desktop

## Publish

1. Delete all files in `digital-knowledge-garden\docs`
2. Export `src` as HTML Documents (self-contained)![[Pasted image 20240510083448.png]]![[Pasted image 20240510085959.png]]
3. Copy `docs\src` to `docs`
4. Delete `docs\src` and `docs\lib` folders
5. Push Git changes
6. A GitHub Action will be triggered to publish https://leandromonaco.github.io/digital-knowledge-garden
### Sources

- [Daily.dev](https://daily.dev/)