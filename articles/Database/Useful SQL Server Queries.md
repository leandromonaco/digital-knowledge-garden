### Find Objects using a Function

```sql
SELECT 
    o.name AS ObjectName,
    o.type_desc AS ObjectType,
    s.name AS SchemaName,
    r.referenced_entity_name AS ReferencedFunction,
    r.referenced_schema_name AS ReferencedSchema
FROM 
    sys.sql_expression_dependencies r
JOIN 
    sys.objects o ON r.referencing_id = o.object_id
JOIN 
    sys.schemas s ON o.schema_id = s.schema_id
WHERE 
    r.referenced_entity_name = 'FunctionName';
```
### Backup

```sql
--Windows
BACKUP DATABASE [DbName] TO
DISK = N'C:\Dev\Database\DbName.bak'
WITH COMPRESSION, STATS = 10
GO

--Linux
BACKUP DATABASE [DbName] TO
DISK = N'/var/opt/mssql/data/DbName.bak'
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
### View the compatibility level of a database

```sql
USE AdventureWorks2019;  
GO  
SELECT compatibility_level  
FROM sys.databases WHERE name = 'AdventureWorks2019';  
GO
```

### List all tables that are linked by foreign keys

```sql
SELECT 
    FK_Table = FK.TABLE_NAME,
    FK_Column = CU.COLUMN_NAME,
    PK_Table = PK.TABLE_NAME,
    PK_Column = PT.COLUMN_NAME,
    Constraint_Name = C.CONSTRAINT_NAME
FROM 
    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
INNER JOIN 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK 
        ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
INNER JOIN 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK 
        ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
INNER JOIN 
    INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU 
        ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
INNER JOIN 
    (
    SELECT 
        i1.TABLE_NAME, 
        i2.COLUMN_NAME
    FROM 
        INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
    INNER JOIN 
        INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 
        ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
    WHERE 
        i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
    ) PT 
    ON PT.TABLE_NAME = PK.TABLE_NAME
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

### List all DB objects in a Database

```sql
SELECT name,*
FROM [DBName].sys.all_objects
WHERE upper(name) LIKE upper('%someName%')
ORDER BY type_desc
```

### Columns Data Size

```sql
SELECT  CAST(SUM(TotalSize) AS varchar(255)) + ' bytes'
FROM(
		SELECT (DATALENGTH(Column1) + 
				DATALENGTH(Column2) + 
				DATALENGTH(Column3) + 
				DATALENGTH(Column4) + 
				DATALENGTH(Column5)) AS TotalSize 
		FROM TableName 
) t
```

### Parameterized Dynamic SQL

```sql
DECLARE @sql NVARCHAR(MAX);
DECLARE @paramDefinition NVARCHAR(MAX);
DECLARE @value NVARCHAR(50) = 'HR';

SET @sql = 'SELECT * FROM Employees WHERE Department = @department';
SET @paramDefinition = '@department NVARCHAR(50)';

EXEC sp_executesql @sql, @paramDefinition, @department = @value;
```
