**Class**
```csharp
using System;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Method)]
public class StopWatchAttribute: Attribute
{
    public virtual void OnEntry()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        AppDomain.CurrentDomain.ProcessExit += (sender, args) =>
        {
            stopwatch.Stop();
            Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
        };
    }
}
```

**How to use it**

```csharp
public class MyClass
{
    [StopWatch]
    public static void MyMethod()
    {
        // Code to be measured.
        System.Threading.Thread.Sleep(500);
    }
}
```