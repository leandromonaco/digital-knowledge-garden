## Installation
```
winget install -e --id Microsoft.SQLServer.2019.Express
winget install -e --id Microsoft.SQLServer.2019.Developer --override '/QUIET /IACCEPTSQLSERVERLICENSETERMS /CONFIGURATIONFILE="C:\Dev\SQLConfigurationFile.ini"'
winget install -e --id Microsoft.SQLServerManagementStudio
```
## SQLConfigurationFile.ini
  ```
  ; Microsoft SQL Server Configuration file  
  [OPTIONS]  
  ; Specifies a Setup work flow, like INSTALL, UNINSTALL, or UPGRADE.  
  ; This is a required parameter.  
  ACTION="Install"  
  ; Specifies features to install, uninstall, or upgrade.  
  ; The list of top-level features include SQL, AS, RS, IS, and Tools.  
  ; The SQL feature will install the database engine, replication, and full-text.  
  ; The Tools feature will install Management Tools, Books online,   
  ; SQL Server Data Tools, and other shared components.  
  FEATURES=SQL,Tools
  INSTANCENAME=SQL2019Dev
  SQLSYSADMINACCOUNTS="[Domain]\[Username]"
  SECURITYMODE=SQL
  SAPWD="S4P4ssw0rd"
  ```
## Documentation
- [Install SQL Server from the Command Prompt](https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-from-the-command-prompt)
- [Install SQL Server using a configuration file](https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-using-a-configuration-file)