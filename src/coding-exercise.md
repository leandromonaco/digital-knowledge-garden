# Objective

Assess your natural approach to coding and engineering best practices.

# Pre-Requisites

1. Test the [API Authentication](#api-authentication).
2. Run the [Code](#code) with your favorite IDE.

# Process

1. Refactor the code following SOLID principles.
2. Test the code.
3. Make the code production-ready.

# Code

```csharp
public class Program
{
    static void Main(string[] args)
    {
        Task.Run(async () =>
        {
            //Get Repositories
            await GetDetails("https://dev.azure.com/AcmeInc/ff86f2fb-5c3a-49e2-a677-c9b95d6baaef/_apis/tfvc/branches?includeParent=1&includeChildren=1&includeDeleted=1&includeLinks=1&api-version=6.0");
            //Get Commits
            await GetDetails("https://dev.azure.com/AcmeInc/ff86f2fb-5c3a-49e2-a677-c9b95d6baaef/_apis/git/repositories/4563efa9-da5d-4f54-b609-18db14479f48/commits?api-version=6.0");
            //Get Pull Requests
            await GetDetails("https://dev.azure.com/AcmeInc/ff86f2fb-5c3a-49e2-a677-c9b95d6baaef/_apis/git/repositories/4563efa9-da5d-4f54-b609-18db14479f48/pullrequests?searchCriteria.status=completed||searchCriteria.status=open?api-version=5.1");
        }).Wait();
    }


    public static async Task GetDetails(string url)
    {
        try
        {
            var personalaccesstoken = "bGVtb25hY29AYWxsaWFuei1hc3Npc3RhbmNlLmNvbS5hdTpuZXczZ3ludmRpdWJpdno0djNoc2E1enpqMmF3ZGtvbzQ3ZnZxMzZ4aWJxb2x5Y203NnNx";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", personalaccesstoken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    var resultJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(resultJson);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
``` 

# API Authentication

- **Organization:** AcmeInc
- **Test Operation**: https://dev.azure.com/AcmeInc/_apis/projects?stateFilter=All&api-version=1.0
- **Authorization Header:** `Basic bGVtb25hY29AYWxsaWFuei1hc3Npc3RhbmNlLmNvbS5hdTpuZXczZ3ludmRpdWJpdno0djNoc2E1enpqMmF3ZGtvbzQ3ZnZxMzZ4aWJxb2x5Y203NnNx`
- **Repository Name:** SmartHotel360

# Documentation

- [Azure DevOps Services REST API Reference](https://docs.microsoft.com/en-us/rest/api/azure/devops/?view=azure-devops-rest-6.1)
- [GitHub REST API Reference](https://docs.github.com/en/rest)

