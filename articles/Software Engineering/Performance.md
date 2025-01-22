[Performance Improvements in .NET 6](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6) #DotNet


.𝗡𝗘𝗧 𝗣𝗲𝗿𝗳𝗼𝗿𝗺𝗮𝗻𝗰𝗲 𝟭𝟬𝟭: 

𝟭. 𝗖𝗮𝗰𝗵𝗶𝗻𝗴 (in-mem Memory Cache or Redis) 
𝟮. 𝗗𝗮𝘁𝗮𝗯𝗮𝘀𝗲 𝗢𝗽𝘁𝗶𝗺𝗶𝘇𝗮𝘁𝗶𝗼𝗻 (optimize queries, proper indexing, connection pooling) 
𝟯. 𝗔𝘀𝘆𝗻𝗰 𝗽𝗿𝗼𝗴𝗿𝗮𝗺𝗺𝗶𝗻𝗴 (offload all CPU extensive or I/O bound operations to DB, file systems, ext. systems) 
𝟰. 𝗨𝘀𝗲 𝗘𝗻𝘁𝗶𝘁𝘆 𝗙𝗿𝗮𝗺𝗲𝘄𝗼𝗿𝗸 𝗖𝗼𝗿𝗲 𝗪𝗶𝘀𝗲𝗹𝘆 (use eager loading, projections, and optimizations like compiled queries) 
𝟱. 𝗠𝗲𝗺𝗼𝗿𝘆 𝗠𝗮𝗻𝗮𝗴𝗲𝗺𝗲𝗻𝘁 (use value types and be cautious with large object graphs. Use dispose pattern to db connections or streams. Avoid boxing/unboxing. Use StringBuilder instead of String for a large number of concatenations.) 
𝟲. 𝗛𝗧𝗧𝗣 𝗖𝗮𝗰𝗵𝗶𝗻𝗴 (use ETags, Last-Modified headers) 
𝟳. 𝗠𝗶𝗻𝗶𝗺𝗶𝘇𝗲 𝗥𝗼𝘂𝗻𝗱-𝗧𝗿𝗶𝗽𝘀 (reduce the number of HTTP requests and database round-trips) 
𝟴. 𝗖𝗼𝗻𝘁𝗲𝗻𝘁 𝗗𝗲𝗹𝗶𝘃𝗲𝗿𝘆 𝗡𝗲𝘁𝘄𝗼𝗿𝗸𝘀 (𝗖𝗗𝗡𝘀) - (Offload static assets (CSS, JavaScript, images) to CDNs for faster delivery to users) 
𝟵. 𝗖𝗼𝗺𝗽𝗿𝗲𝘀𝘀𝗶𝗼𝗻 (Enable GZIP or Brotli compression for HTTP responses to reduce data transfer size) 
𝟭𝟬 𝗟𝗼𝗴𝗴𝗶𝗻𝗴 𝗮𝗻𝗱 𝗧𝗿𝗮𝗰𝗶𝗻𝗴 (Avoid excessive logging in production. Use distributed tracing across microservices) 
𝟭𝟭. 𝗣𝗮𝗿𝗮𝗹𝗹𝗲𝗹𝗶𝘀𝗺 𝗮𝗻𝗱 𝗖𝗼𝗻𝗰𝘂𝗿𝗿𝗲𝗻𝗰y (Utilize parallelism and multithreading for CPU-bound tasks using Parallel class or Task Parallel Library (TPL)) 
𝟭𝟮. 𝗥𝗲𝘀𝗼𝘂𝗿𝗰𝗲 𝗢𝗽𝘁𝗶𝗺𝗶𝘇𝗮𝘁𝗶𝗼𝗻 (Optimize images and assets for the web to reduce load times) 
𝟭𝟯. 𝗛𝗧𝗧𝗣/𝟮 𝗼𝘃𝗲𝗿 𝗦𝗦𝗟 (now make intelligent decisions about the page content) 
𝟭𝟰. 𝗠𝗲𝗮𝘀𝘂𝗿𝗲 𝗮𝗻𝗱 𝗠𝗼𝗻𝗶𝘁𝗼𝗿 𝗽𝗲𝗿𝗳𝗼𝗿𝗺𝗮𝗻𝗰𝗲 (use VS Diagnostic Tools, App Insights or BenchmarkDotNet) 
𝟭𝟱. 𝗨𝘀𝗲 𝗦𝗽𝗮𝗻<> 𝗶𝗻𝘀𝘁𝗲𝗮𝗱 𝗼𝗳 𝗖𝗼𝗹𝗹𝗲𝗰𝘁𝗶𝗼𝗻𝘀 (spans can represent a contiguous section of memory, this means we can use them to operate over arrays)