## Installation
  
  1. Install [Caskaydia Cove Nerd Font Complete Regular.otf](https://github.com/ryanoasis/nerd-fonts/blob/3b93c9963710a840f12c3f3e4e6f6240e39cbbdc/patched-fonts/CascadiaCode/Regular/complete/Caskaydia%20Cove%20Nerd%20Font%20Complete%20Regular.otf)
  2. Run `winget install --id Microsoft.WindowsTerminal`
  4. Run `winget install --id Microsoft.PowerShell`
  5. Run `winget install --id JanDeDobbeleer.OhMyPosh`
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
  10. Check "Show all fonts"
  11. Choose the CaskaydiaCove Nerd Font

## Documentation
- [What is Windows Terminal?](https://learn.microsoft.com/en-us/windows/terminal/)
- [Tutorial: Set up a custom prompt for PowerShell or WSL with Oh My Posh](https://docs.microsoft.com/en-us/windows/terminal/tutorials/custom-prompt-setup)
- [How to enable TAB completion for the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete)
