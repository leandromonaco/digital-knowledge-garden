**Program.cs**

```csharp
services.AddHttpClient("MyClient", client =>
            {
                client.DefaultRequestHeaders.Add("authToken", "token123");
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
```
            



## Option 1 - Inject IHttpClientFactory 

```csharp
var  httpClient = _httpClientFactory.CreateClient("MyClient");
```


## Option 2 - Create Instance


```csharp
var httpClient = new HttpClient();

responseJson = await httpClient.GetStringAsync($"https://domain.com/endpoint");
var instance = JsonSerializer.Deserialize<ObjectDeserialized>(responseJson)!;
```

