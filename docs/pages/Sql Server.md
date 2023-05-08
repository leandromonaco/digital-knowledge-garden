## Installation

### Local Server Instance
```
winget install -e --id Microsoft.SQLServer.2019.Express
winget install -e --id Microsoft.SQLServer.2019.Developer --override '/QUIET /IACCEPTSQLSERVERLICENSETERMS /CONFIGURATIONFILE="C:\Dev\SQLConfigurationFile.ini"'
```
**SQLConfigurationFile.ini**
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
  
### Docker Image
```
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

### SQL Server Management Studio
```
winget install -e --id Microsoft.SQLServerManagementStudio
winget upgrade -e --id Microsoft.SQLServerManagementStudio
```

### Sqlcmd Tools
```
winget install -e --id Microsoft.Sqlcmd
winget upgrade -e --id Microsoft.Sqlcmd
```


## Documentation
- [Install SQL Server from the Command Prompt](https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-from-the-command-prompt)
- [Install SQL Server using a configuration file](https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-using-a-configuration-file)

## EF vs. Stored Procedures
- [Entity Framework Vs Stored Procedures - Performance Measure](https://stackoverflow.com/questions/9739230/entity-framework-vs-stored-procedures-performance-measure)
- [Performance Considerations (Entity Framework)](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/performance-considerations?redirectedfrom=MSDN)
- [What are the pros and cons of using stored procedures vs C# code for DB work?](https://docs.microsoft.com/en-us/answers/questions/236924/what-are-the-pros-and-cons-of-using-stored-procedu.html)
## SQL Performance
- [[Performance]]
## Resources
- [Brent Ozar](https://www.brentozar.com/)
- [SQL Kit](https://sqlserver-kit.org/en)

## Retries

Enable transient error resiliency by adding `EnableRetryOnFailure` to the `UseSqlServer` call on [[ASP.NET]]


## Useful Queries
### Backup
```sql
BACKUP DATABASE [DbName] TO
DISK = N'C:\Dev\Database\DbName.bak'
WITH COMPRESSION, STATS = 10
GO
```
### Paging
```sql
--https://learn.microsoft.com/en-us/sql/t-sql/queries/select-order-by-clause-transact-sql
SELECT *
FROM Employee
ORDER BY EmployeeId
OFFSET 20 ROWS
FETCH NEXT 5 ROWS ONLY 
```
### Restore
```sql
USE master;
GO

ALTER DATABASE [DbName]
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO

RESTORE DATABASE [DbName]
FROM DISK = N'C:\Dev\Database\DbName.bak'
WITH RECOVERY
GO

RESTORE DATABASE [DbName]
FROM DISK = N'C:\Dev\Database\DbName.bak'
WITH MOVE 'DbName' TO 'C:\Dev\Database\DbName.mdf',
   MOVE 'DbName_log' TO 'C:\Dev\Database\DbName_log.ldf',
RECOVERY, REPLACE
GO

RESTORE DATABASE Local
FROM DISK = N'/var/opt/mssql/data/Local.bak'
WITH MOVE 'Database' TO '/var/opt/mssql/data/Local.mdf',
     MOVE 'Database_Log' TO '/var/opt/mssql/log/Local.ldf',
RECOVERY, REPLACE
GO
```
### Get all linked tables by FK
```sql
SELECT
OBJECT_NAME(fkeys.constraint_object_id) foreign_key_name,
OBJECT_NAME(fkeys.parent_object_id) referencing_table_name,
COL_NAME(fkeys.parent_object_id, fkeys.parent_column_id) referencing_column_name,
OBJECT_SCHEMA_NAME(fkeys.parent_object_id) referencing_schema_name,
OBJECT_NAME (fkeys.referenced_object_id) referenced_table_name,
COL_NAME(
fkeys.referenced_object_id,
fkeys.referenced_column_id
) referenced_column_name,
OBJECT_SCHEMA_NAME(fkeys.referenced_object_id) referenced_schema_name
FROM
sys.foreign_key_columns AS fkeys
ORDER BY referenced_table_name
```
### View the compatibility level of a database
```sql
USE AdventureWorks2019;  
GO  
SELECT compatibility_level  
FROM sys.databases WHERE name = 'AdventureWorks2019';  
GO
```
### List table and columns with their foreign keys 
```sql
SELECT
schema_name(tab.schema_id) + '.' + tab.name AS [Table],
col.name AS 'Column Name',
t.name AS 'Data Type',
col.max_length AS 'Max Length',
col.precision AS 'Precision',
schema_name(pk_tab.schema_id) + '.' + pk_tab.name AS 'Primary Table',
pk_col.name AS 'PK Column Name',
fk.name AS 'FK Constraint Name'
FROM
sys.tables tab
INNER JOIN sys.columns col ON col.object_id = tab.object_id
LEFT OUTER JOIN sys.foreign_key_columns fk_cols ON fk_cols.parent_object_id = tab.object_id
AND fk_cols.parent_column_id = col.column_id
LEFT OUTER JOIN sys.types AS t ON col.user_type_id = t.user_type_id
LEFT OUTER JOIN sys.foreign_keys fk ON fk.object_id = fk_cols.constraint_object_id
LEFT OUTER JOIN sys.tables pk_tab ON pk_tab.object_id = fk_cols.referenced_object_id
LEFT OUTER JOIN sys.columns pk_col ON pk_col.column_id = fk_cols.referenced_column_id
AND pk_col.object_id = fk_cols.referenced_object_id
ORDER BY
schema_name(tab.schema_id) + '.' + tab.name,
col.column_id
```

### List tables with no records
```sql
SELECT
  t.NAME AS TableName,
  p.rows AS RowCounts
FROM
  sys.tables t
  INNER JOIN sys.partitions p ON t.object_id = p.OBJECT_ID
WHERE
  t.NAME NOT LIKE 'dt%'
  AND t.is_ms_shipped = 0
  AND p.rows = 0
GROUP BY
  t.Name,
  p.Rows
ORDER BY
  t.Name
```

## Encryption by Certificate
- https://docs.microsoft.com/en-us/sql/t-sql/functions/encryptbycert-transact-sql
- https://docs.microsoft.com/en-us/sql/t-sql/functions/decryptbycert-transact-sql
- https://docs.microsoft.com/en-us/sql/t-sql/statements/create-certificate-transact-sql
- https://docs.microsoft.com/en-us/sql/t-sql/statements/alter-certificate-transact-sql
## Encryption by Password
### 1 - Create Symmetric Key (one-off)

Encryption keys are generated by running the [CREATE SYMMETRIC KEY](https://docs.microsoft.com/en-us/sql/t-sql/statements/create-symmetric-key-transact-sql) command.

```sql
CREATE SYMMETRIC KEY [SymKey_SomeID] WITH ALGORITHM = AES_256,
KEY_SOURCE = 'KEY_SOURCE_STRING',
IDENTITY_VALUE = 'IDENTITY_VALUE_STRING' ENCRYPTION BY PASSWORD = 'eLtGc5woM&S$n5'

-- View the newly created encryption
SELECT * 
FROM sys.symmetric_keys

-- View the actual key data. At its lowest level, a 256 bit AES key is comprised of 256 bits (32 bytes) of data.
SELECT * 
FROM sys.key_encryptions
```
### 2 - Open Symmetric Key

A symmetric encryption key must be opened using the [OPEN SYMMETRIC KEY](https://docs.microsoft.com/en-us/sql/t-sql/statements/open-symmetric-key-transact-sql) command before it can be used. 

```sql
OPEN SYMMETRIC KEY [SymKey_SomeID] 
DECRYPTION BY PASSWORD = 'eLtGc5woM&S$n5'
```
### 3 - Encrypt Data

Data can be encrypted using the SQL function [ENCRYPTBYKEY](https://docs.microsoft.com/en-us/sql/t-sql/functions/encryptbykey-transact-sql).

The *authenticator* value is used as an additional piece of data against which the encryption will be validated. If the same context (including *authenticator*) is not provided again when decrypting, then decryption will fail.

The following SQL statement demonstrates encrypting a string using a GUID value as an *authenticator*:

```sql
DECLARE @keyId UNIQUEIDENTIFIER = (SELECT key_guid FROM sys.symmetric_keys WHERE name='SymKey_SomeID')
DECLARE @auth VARCHAR(40) = '7AECFD07-4643-41FC-B17C-472AD71699E7'
DECLARE @str VARCHAR(50) = 'Super secret string data'
SELECT ENCRYPTBYKEY(@keyId, @str, 1, @auth)
```
### 4 - Decrypt Data

```sql
DECLARE @encryptedData VARBINARY(200) = 0x00983DD06D6B6AC67A112F2A8866927A020000005A05FE279810FC3A75B27979324C9C81EBCE0D65AD8E2312ACBC5E23A49F135FFE44453511432DDF7C68D764865DE75C12F692E50B0B6EC5F3FD2C0E4C2C68DE5EEB8F773DA407DA32D6C79C5EF6F0BA
DECLARE @auth VARCHAR(40) = '7AECFD07-4643-41FC-B17C-472AD71699E7'
SELECT CONVERT(VARCHAR(100), DECRYPTBYKEY(@encryptedData, 1, @auth))
```
## Troubleshooting
- **Error:** 'Agent XPs' component is turned off as part of the security configuration for this server. A system administrator can enable the use of 'Agent XPs' by using sp_configure. For more information about enabling 'Agent XPs', see "Surface Area Configuration" in SQL Server Books Online. (Microsoft.SqlServer.Management.MaintenancePlanWizard)
- **Solution:**
  ```sql
  sp_configure 'show advanced options', 1;  
  GO  
  RECONFIGURE;  
  GO  
  sp_configure 'Agent XPs', 1;  
  GO  
  RECONFIGURE  
  GO
  ```
- **Error:** SQLServerAgent is not currently running so it cannot be notified of this action. (Microsoft SQL Server, Error: 22022)
- **Solution:** Open SQL Server Configuration Manager and enable SQL Server Agent Service
- **Error:** Cannot execute as the database principal because the principal ‘dbo’ does not exist, this type of principal cannot be impersonated, or you do not have permission. (Microsoft SQL Server, Error: 15517)
- **Solution:**
  ```sql
  USE [AdventureWorks]
  GO
  ALTER AUTHORIZATION ON DATABASE::[AdventureWorks] TO [sa]
  GO
  ```
