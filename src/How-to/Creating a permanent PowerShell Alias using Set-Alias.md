To create a permanent PowerShell Alias using the Set-Alias cmdlet, you should add it to your PowerShell profile, which ensures that the alias is available every time you launch PowerShell.

1. Open the PowerShell profile file in Notepad: `notepad $profile`
2. Add the following line to create a permanent alias: `Set-Alias -Name aliasname -Value command`
3. Save your changes and close Notepad.
4. To ensure that your profile is loaded, run the command: `. $profile`