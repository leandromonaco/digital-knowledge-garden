```csharp
public static void SeedSqlServerDatabase(DevExLeadContext context)
        {
            if (context.Database.IsRelational()) // Check if the database provider is a relational database (in-memory is not considered relational)
            {
                // Disable all constraints
                context.Database.ExecuteSqlRaw("EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");
            }
            

            // Read and deserialize JSON files
            var jsonFiles = Directory.GetFiles($@"{AppContext.BaseDirectory}\Seed", "*.json");


            foreach (var jsonFile in jsonFiles)
            {
                var fileInfo = new FileInfo(jsonFile);
                var tableName = ExtractTableName(fileInfo.Name);
                var jsonData = File.ReadAllText(jsonFile);
                var tablesWithoutIdentity = new List<string> { "BacklogItemEmployee", "BacklogItemSprint" };

                List<object>? rows = FetchRows(tableName, jsonData);

                // Add data to the context
                if (rows != null)
                {
                    if (context.Database.IsRelational())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            if (!tablesWithoutIdentity.Contains(tableName))
                            {
                                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] ON");
                            }

                            Console.WriteLine($"Adding data to {tableName} table");
                            AddFetchRows(context, tableName, rows);
                            context.SaveChanges();

                            if (!tablesWithoutIdentity.Contains(tableName))
                            {
                                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] OFF");
                            }
                           
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        AddFetchRows(context, tableName, rows);
                        context.SaveChanges();
                    }

                 
                }
            }

            if (context.Database.IsRelational()) // Check if the database provider is a relational database (in-memory is not considered relational)
            {
                // Enable all constraints
                context.Database.ExecuteSqlRaw("EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
            }
        }
```

#sqlserver #dataseeding #testing