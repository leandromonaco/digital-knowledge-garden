**Useful Links**
- https://platform.openai.com/docs/overview
- Generate API Key: https://platform.openai.com/api-keys
- Select Available Models for API: https://platform.openai.com/settings/proj_ABtkl6IvMcTADnrDL1jhRkjQ/limits
- API Credits: https://platform.openai.com/settings/organization/billing/overview

**Library**
- https://www.nuget.org/packages/OpenAI
- https://github.com/openai/openai-dotnet

**Snippet**

```csharp
 var prompt = @"some prompt";
 ChatClient client = new(model: "gpt-4o", "open-api-key");
 ChatCompletion completion = client.CompleteChat(prompt);
 Console.WriteLine($"{completion.Content[0].Text}");
```