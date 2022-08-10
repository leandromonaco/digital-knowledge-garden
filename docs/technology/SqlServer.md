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
