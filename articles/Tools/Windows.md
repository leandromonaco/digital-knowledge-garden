## DISM Commands
- List All Features: `DISM /online /get-features /Format:Table`
- See Feature Info: `DISM /online /get-featureinfo /featurename:[feature name]`
- Disable Feature: `DISM /online /disable-feature /featurename:[feature name]`
- Enable Feature: `DISM /online /enable-feature /featurename:[feature name]`
## Enable Windows Features (Windows 10)
  
  
  ```
  DISM /online /enable-feature /featurename:IIS-WebServerRole
  DISM /online /enable-feature /featurename:IIS-WebServerManagementTools
  DISM /online /enable-feature /featurename:IIS-ManagementConsole
  DISM /online /enable-feature /featurename:IIS-NetFxExtensibility45
  DISM /online /enable-feature /featurename:IIS-ISAPIExtensions
  DISM /online /enable-feature /featurename:IIS-ISAPIFilter
  DISM /online /enable-feature /featurename:IIS-ASPNET45
  DISM /online /enable-feature /featurename:IIS-CGI
  DISM /online /enable-feature /featurename:IIS-DefaultDocument
  DISM /online /enable-feature /featurename:IIS-DirectoryBrowsing
  DISM /online /enable-feature /featurename:IIS-HttpErrors
  DISM /online /enable-feature /featurename:IIS-StaticContent
  DISM /online /enable-feature /featurename:IIS-HttpLogging
  DISM /online /enable-feature /featurename:IIS-HttpCompressionStatic
  DISM /online /enable-feature /featurename:IIS-Security
  DISM /online /enable-feature /featurename:IIS-IPSecurity
  DISM /online /enable-feature /featurename:IIS-BasicAuthentication
  DISM /online /enable-feature /featurename:IIS-WindowsAuthentication                 
  DISM /online /enable-feature /featurename:IIS-DigestAuthentication      
  DISM /online /enable-feature /featurename:IIS-URLAuthorization            
  DISM /online /enable-feature /featurename:IIS-ClientCertificateMappingAuthentication
  DISM /online /enable-feature /featurename:IIS-IISCertificateMappingAuthentication   
  DISM /online /enable-feature /featurename:IIS-CertProvider
  ```
-
## Configure IP/Port Mapping
### Overview
  ![image](https://user-images.githubusercontent.com/5598150/176797511-7b7a1cfd-0b69-4120-808b-243fc162a3da.png)
### Actions
  
  1. Started my server on localhost:8081
  2. Added my "local DNS" in the hosts file as a new line (127.65.43.21 example.app). Any free address in the network 127.0.0.0/8 (127.x.x.x) can be used. You can check with ```netstat -a -n -p TCP | grep "LISTENING"```
  3. Added the following network configuration with `netsh interface portproxy add v4tov4 listenport=80 listenaddress=127.65.43.21 connectport=8081 connectaddress=127.0.0.1`
  4. I can now access the server at http://example.app
### Notes
- These commands/file modifications need to be executed with Admin rights
- netsh portproxy needs ipv6 libraries even only to use v4tov4, typically they will also be included by default, otherwise install them using the following command: netsh interface ipv6 install
  
  You can see the entry you have added with the command:
  
  `netsh interface portproxy show v4tov4`
  
  You can remove the entry with the following command:
  
  `netsh interface portproxy delete v4tov4 listenport=80 listenaddress=127.65.43.21`
## Documentation
- [DISM - Deployment Image Servicing and Management](https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/dism---deployment-image-servicing-and-management-technical-reference-for-windows)
- [Using Netsh](https://technet.microsoft.com/en-us/library/bb490939.aspx)
- [Netsh commands for Interface IP](https://technet.microsoft.com/en-us/library/cc738592(v=ws.10).aspx)
- [Netsh commands for Interface Portproxy](https://technet.microsoft.com/es-es/library/cc731068(v=ws.10).aspx#BKMK_1)
- [Windows Port Forwarding Example](http://woshub.com/port-forwarding-in-windows/)