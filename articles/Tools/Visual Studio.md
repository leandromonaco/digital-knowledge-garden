<<<<<<< HEAD
- https://learn.microsoft.com/en-us/visualstudio/get-started/visual-studio-ide
  https://learn.microsoft.com/en-us/aspnet/core/test/dev-tunnels
  https://learn.microsoft.com/en-us/aspnet/core/test/http-files
  
  ## Installation
- ```
=======
## Installation
 ```
>>>>>>> e89b33083bcb8beb793b776dec7c4eab0dce39bd
  winget install -e --id Microsoft.VisualStudio.2019.Professional
  winget install -e --id Microsoft.VisualStudio.2022.Enterprise
  winget install -e --id Microsoft.VisualStudio.2022.TestController
  winget install -e --id Microsoft.VisualStudio.2022.TestAgent
  winget install -e --id Microsoft.VisualStudio.2022.TeamExplorer
  winget install -e --id Microsoft.VisualStudio.2022.Professional
  winget install -e --id Microsoft.VisualStudio.2022.Enterprise
  winget install -e --id Microsoft.VisualStudio.2022.Community
  winget install -e --id Microsoft.VisualStudio.2022.BuildTools
  ```
## Configuration
 [Import or export installation configurations](https://docs.microsoft.com/en-us/visualstudio/install/import-export-installation-configurations)


## Extensions
  ```powershell
  
  #Credits: https://gist.github.com/ScottHutchinson/b22339c3d3688da5c9b477281e258400
  #$PackageName = "AmazonWebServices.AWSToolkitforVisualStudio2022"
  #$PackageName = "GitHub.copilotvs"
  #$PackageName = "SteveCadwallader.CodeMaid"
  #$PackageName = "SteveCadwallader.CodeMaidVS2022"
  #$PackageName = "ironcev.sharpen"
  #$PackageName = "SonarSource.SonarLintforVisualStudio2022"
  #$PackageName = "DevExpress.CodeRushforVS2022"
  #$PackageName = "MLNET.notebook"
  #$PackageName = "VisualStudioProductTeam.ProjectSystemTools2022"
  $PackageName = "snyk-security.snyk-vulnerability-scanner-vs-2022"
  
  $ErrorActionPreference = "Stop"
  
  $baseProtocol = "https:"
  $baseHostName = "marketplace.visualstudio.com"
  
  $Uri = "$($baseProtocol)//$($baseHostName)/items?itemName=$($PackageName)"
  $VsixLocation = "$($env:Temp)\$([guid]::NewGuid()).vsix"
  
  $VSInstallDir = "C:\Program Files (x86)\Microsoft Visual Studio\Installer\resources\app\ServiceHub\Services\Microsoft.VisualStudio.Setup.Service"
  
  if (-Not $VSInstallDir) {
  Write-Error "Visual Studio InstallDir registry key missing"
  Exit 1
  }
  
  Write-Host "Grabbing VSIX extension at $($Uri)"
  $HTML = Invoke-WebRequest -Uri $Uri -UseBasicParsing -SessionVariable session
  
  Write-Host "Attempting to download $($PackageName)..."
  $anchor = $HTML.Links |
  Where-Object { $_.class -eq 'install-button-container' } |
  Select-Object -ExpandProperty href
  
  if (-Not $anchor) {
  Write-Error "Could not find download anchor tag on the Visual Studio Extensions page"
  Exit 1
  }
  Write-Host "Anchor is $($anchor)"
  $href = "$($baseProtocol)//$($baseHostName)$($anchor)"
  Write-Host "Href is $($href)"
  Invoke-WebRequest $href -OutFile $VsixLocation -WebSession $session
  
  if (-Not (Test-Path $VsixLocation)) {
  Write-Error "Downloaded VSIX file could not be located"
  Exit 1
  }
  Write-Host "VSInstallDir is $($VSInstallDir)"
  Write-Host "VsixLocation is $($VsixLocation)"
  Write-Host "Installing $($PackageName)..."
  Start-Process -Filepath "$($VSInstallDir)\VSIXInstaller" -ArgumentList "/q /a $($VsixLocation)" -Wait
  
  Write-Host "Cleanup..."
  rm $VsixLocation
  
  Write-Host "Installation of $($PackageName) complete!"
  ```

## Features

- [Profiling](https://docs.microsoft.com/en-us/visualstudio/profiling)
