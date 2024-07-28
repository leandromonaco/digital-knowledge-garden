  
  ```powershell
  
  $HostFile = 'C:\Windows\System32\drivers\etc\hosts'
  
  # Create a backup copy of the Hosts file
  $dateFormat = (Get-Date).ToString('dd-MM-yyyy hh-mm-ss')
  $FileCopy = $HostFile + '.' + $dateFormat  + '.copy'
  Copy-Item $HostFile -Destination $FileCopy
  
  $Bindings = Get-IISSiteBinding "websitename.com"
  
  # Get the contents of the Hosts file
  $File = Get-Content $HostFile
  
  # write the Entries to hosts file, if it doesn't exist.
  foreach ($Binding in $Bindings) 
  {
  $HostFileEntry = $Binding.bindingInformation
  $HostFileEntry = $HostFileEntry -replace "\*:443:", ""
  
  Write-Host "Checking existing HOST file entries for $HostFileEntry..."
  
  #Set a Flag
  $EntryExists = $false
  
  if ($File -contains "127.0.0.1 `t $HostFileEntry") 
  {
    Write-Host "Host File Entry for $HostFileEntry already exists."
    $EntryExists = $true
  }
  #Add Entry to Host File
  if (!$EntryExists) 
  {
    Write-host "Adding Host File Entry for $HostFileEntry"
    Add-content -path $HostFile -value "127.0.0.1 `t $HostFileEntry"
  }
  }
  
  ```