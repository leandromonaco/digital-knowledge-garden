# EF vs. Stored Procedures

- [Entity Framework Vs Stored Procedures - Performance Measure](https://stackoverflow.com/questions/9739230/entity-framework-vs-stored-procedures-performance-measure)
- [Performance Considerations (Entity Framework)](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/performance-considerations?redirectedfrom=MSDN)
- [What are the pros and cons of using stored procedures vs C# code for DB work?](https://docs.microsoft.com/en-us/answers/questions/236924/what-are-the-pros-and-cons-of-using-stored-procedu.html)

# SQL Performance
- [Performance Center for SQL Server Database](https://docs.microsoft.com/en-us/sql/relational-databases/performance/performance-center-for-sql-server-database-engine-and-azure-sql-database?view=sql-server-ver16)
- [Start and use the Database Engine Tuning Advisor](https://docs.microsoft.com/en-us/sql/relational-databases/performance/start-and-use-the-database-engine-tuning-advisor?view=sql-server-ver16)
- [Monitor performance by using the Query Store](https://docs.microsoft.com/en-us/sql/relational-databases/performance/monitoring-performance-by-using-the-query-store?view=sql-server-ver16)
- [Use the Maintenance Plan Wizard](https://docs.microsoft.com/en-us/sql/relational-databases/maintenance-plans/use-the-maintenance-plan-wizard)

# Resources

- [Brent Ozar](https://www.brentozar.com/)
- [SQL Kit](https://sqlserver-kit.org/en)

# Useful Queries

## Get all linked tables by FK
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

## View the compatibility level of a database
```sql
USE AdventureWorks2019;  
GO  
SELECT compatibility_level  
FROM sys.databases WHERE name = 'AdventureWorks2019';  
GO
```

## List table and columns with their foreign keys 
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

# Troubleshooting

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
