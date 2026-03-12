
- ```dotnet new lambda.EmptyFunction --help```
  
**Create Lambda Function**
  
  - Install DotNet Lambda templates ```dotnet new -i Amazon.Lambda.Templates```
  - Install ```dotnet tool install -g Amazon.Lambda.Tools```
  - List templates ```dotnet new --list```
  - Run ```dotnet new serverless.AspNetCoreMinimalAPI --name MinimalApi```
  - ```dotnet build```
  - ```dotnet publish -c Release -o publish p:PublishReadyToRun=false```
  - zip content of the .\publish\ folder (function.zip)
  
**Create Deployment Package**
  
  1. Create Cdk folder and run ```cdk init app --language=csharp```
  2. configure deployment settings (CdkStack.cs)
  ```csharp
  // The code that defines your stack goes here
  var lambda = new Function(this, "MinimalApiNet6", new FunctionProps
  {
    Runtime = Runtime.DOTNET_6,
    Code = Code.FromAsset("../MinimalApi/bin/Debug/net6.0"),
    Handler = "MinimalApi",
    FunctionName = "minimalApiNet6"
  });
  
  var api = new LambdaRestApi(this, "APIGatewayNet6", new LambdaRestApiProps
  {
    RestApiName = "APIGatewayNet6",
    Description = "A simple Minimal API with .NET 6",
    Handler = lambda
  }); 
  ```      
  3. Emit the synthesized CloudFormation template ```cdk synth```
  
**Test with LocalStack**
  
  1. Add Environment Variable `EDGE_PORT=52005` (custom LocalStack port number)
  2. `cdklocal init app --language=csharp`
  3. Change Stack.cs file
  4. `cdklocal synth -v` (this must be run where the cdk.json file is located. It creates the cdk.out folder)
  5. `cdklocal bootstrap --profile default` (if you get "Unable to resolve AWS account to use." make sure the localstack service is running http://localhost:4566/health)
  6. `cdklocal deploy -v`
  8. Test endpoint using Postman![image](https://user-images.githubusercontent.com/5598150/169179873-6bdf5b22-fcd7-4eee-a314-be505a528da5.png)
  
**Documentation**
- https://aws.amazon.com/blogs/compute/introducing-the-net-6-runtime-for-aws-lambda/
- https://docs.aws.amazon.com/lambda/latest/dg/lambda-csharp.html
- https://aws.amazon.com/blogs/developer/net-core-global-tools-for-aws/