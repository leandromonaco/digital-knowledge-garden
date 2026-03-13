```csharp
DateTimeOffset myTime = DateTimeOffset.UtcNow;
Guid uuidV7 = Guid.CreateVersion7(myTime);
```

Using UUIDv7 “out of the box” as a primary key in SQL Server is generally not recommended because SQL Server’s uniqueidentifier type doesn’t preserve the natural, time‐sortable order of a UUIDv7. In SQL Server the 16-byte GUID is stored using a legacy byte‐ordering scheme (designed for backward compatibility), so even if you generate a UUIDv7 (which embeds a Unix timestamp in its most significant 48 bits), the database’s internal reordering will scramble that order.

This means you won’t automatically benefit from the sequential insertion advantages (e.g. improved index locality and reduced page splits) that UUIDv7 can offer in other systems. Instead, many experts continue to favor SQL Server’s built‑in methods (like NEWSEQUENTIALID()) for generating sequential values when that property is desired.

If you require UUIDv7 for global uniqueness or for a distributed system—but still want to use SQL Server—you would need to implement a custom solution. Options include:

• Storing the UUIDv7 in a BINARY(16) column and managing the byte order explicitly, or  
• Using a custom generator (or conversion function) that “reorders” the UUIDv7 bytes to match SQL Server’s sorting behavior.

Without such custom handling, the benefits of UUIDv7 (namely, its natural ordering) are effectively lost on SQL Server.

**References:**

[Extend System.Guid with a new creation API for v7 · Issue #103658 · dotnet/runtime](https://github.com/dotnet/runtime/issues/103658#issuecomment-2180882270)
[RFC 9562 - Universally Unique IDentifiers (UUIDs)](https://datatracker.ietf.org/doc/rfc9562/)

**Tags**

#Performance #DotNet 