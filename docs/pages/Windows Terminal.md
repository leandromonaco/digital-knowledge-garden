- ## Installation
  
  1. Run`winget install -e --id Microsoft.WindowsTerminal`
  2. Install [[Powershell]] 
  3. Run `winget install JanDeDobbeleer.OhMyPosh -s winget`
  4. Run `Install-Module PSReadLine -AllowPrerelease -Force`
  5. Run `notepad $PROFILE` 
  6. Add these lines
  ```
  oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\jandedobbeleer.omp.json" | Invoke-Expression
  Import-Module PSReadLine
  Set-PSReadLineOption -PredictionSource History  
  Set-PSReadLineOption -PredictionViewStyle ListView  
  Set-PSReadLineOption -EditMode Windows
  ```
  
  7. Restart command prompt window
## Documentation
- [What is Windows Terminal?](https://learn.microsoft.com/en-us/windows/terminal/)
- [Tutorial: Set up a custom prompt for PowerShell or WSL with Oh My Posh](https://docs.microsoft.com/en-us/windows/terminal/tutorials/custom-prompt-setup)
- [How to enable TAB completion for the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete)