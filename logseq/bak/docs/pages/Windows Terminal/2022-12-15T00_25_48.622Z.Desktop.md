## Installation
  
  1. Install [Ubuntu Nerd Font](https://github.com/ryanoasis/nerd-fonts/releases/download/v2.2.2/Ubuntu.zip)
  2. Run `winget install -e --id Microsoft.WindowsTerminal`
  4. Install [[Powershell]] 
  5. Run `winget install JanDeDobbeleer.OhMyPosh -s winget`
  6. Run `Install-Module PSReadLine -AllowPrerelease -Force`
  7. Run `notepad $PROFILE` 
  8. Add these lines
  ```
  oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\jandedobbeleer.omp.json" | Invoke-Expression
  Import-Module PSReadLine
  Set-PSReadLineOption -PredictionSource History  
  Set-PSReadLineOption -PredictionViewStyle ListView  
  Set-PSReadLineOption -EditMode Windows
  ```
  8. Restart command prompt window
  9. Go to Settings -> Profile -> Appearance
  10. Choose the font

## Documentation
- [What is Windows Terminal?](https://learn.microsoft.com/en-us/windows/terminal/)
- [Tutorial: Set up a custom prompt for PowerShell or WSL with Oh My Posh](https://docs.microsoft.com/en-us/windows/terminal/tutorials/custom-prompt-setup)
- [How to enable TAB completion for the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete)
