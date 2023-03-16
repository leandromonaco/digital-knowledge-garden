## Tools

- `winget install -e --id Amazon.AWSCLI`
- `winget install -e --id Amazon.SAM-CLI`
- `winget install -e --id Amazon.NoSQLWorkbench`
- `npm install -g aws-cdk`
- `dotnet tool install -g Amazon.Lambda.Tools`
- [AWS Application Composer](https://aws.amazon.com/blogs/aws/aws-application-composer-now-generally-available-visually-build-serverless-applications-quickly/)

  
**Upgrade**

- `sam --version`
- `winget upgrade -e --id Amazon.SAM-CLI`
- `cdk --version`
- `npm upgrade -g aws-cdk`
- `dotnet tool update -g Amazon.Lambda.Tools`
  
## Credentials

1. Run `aws configure`
2. AWS Access Key ID: `test`
3. AWS Secret Access Key: `test`
4. Default region name: `ap-southeast-2`
5. Default output format: `json`
6. Run `aws configure list` to verify the newly configured credentials (stored in `C:\Users\{USER}\.aws\credentials`)


## AWS CDK

**Commands**

- `dotnet build src` compile this app
- `cdk deploy` deploy this stack to your default AWS account/region
- `cdk diff` compare deployed stack with current state
- `cdk synth` emits the synthesized CloudFormation template

**Documentation**
- [AWS Cloud Development Kit](https://aws.amazon.com/cdk/)
- [Getting started with the AWS CDK](https://docs.aws.amazon.com/cdk/v2/guide/getting_started.html)
- https://docs.aws.amazon.com/cdk/v2/guide/troubleshooting.html#troubleshooting_toolkit

## SAM CLI

**Commands**

- `sam init` ![image](https://user-images.githubusercontent.com/5598150/194959241-e345d6ee-dcd1-4e2d-b94d-0b22d8a27051.png)

**Documentation**
- [What is the AWS Serverless Application Model (AWS SAM)?](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/what-is-sam.html)
- [AWS Serverless Application Model](https://aws.amazon.com/serverless/sam/)
- https://docs.aws.amazon.com/codedeploy/latest/userguide/tutorial-lambda-sam-template.html
- https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/sam-specification.html

## AWS CLI

**Commands**
- `aws --endpoint-url=http://localhost:4566 dynamodb create-table --table-name ServiceName_Setting --attribute-definitions AttributeName=TenantId,AttributeType=S --key-schema AttributeName=TenantId,KeyType=HASH --billing-mode PAY_PER_REQUEST`
- `aws --endpoint-url=http://localhost:4566 sqs create-queue --queue-name sample-queue2`
- `aws --endpoint-url=http://localhost:4566 kms --region ap-southeast-2 create-key --tags TagKey=Purpose,TagValue=Test --description "Development test key"`
- `aws --endpoint-url=http://localhost:4566 kms encrypt --region ap-southeast-2 --key-id 1cc95196-acb1-4279-9063-a3daa3d9a20d --plaintext fileb://C:\TEMP\connectionstring.txt`

**Documentation**
- [AWS CLI Command Reference](https://awscli.amazonaws.com/v2/documentation/api/latest/index.html)
- [dynamodb](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/dynamodb/index.html)

## Moto

**Documentation**
- http://docs.getmoto.org/en/latest/docs/server_mode.html
- https://hub.docker.com/r/motoserver/moto/tags
- http://docs.getmoto.org/en/latest/docs/services/events.html
  
## LocalStack 

**Installation**
  
  1. Run `winget install -e --id Python.Python.3`
  2. Install pip  `py -m ensurepip --upgrade`
  3. Install Docker `winget install -e --id Docker.DockerDesktop`
  4. Go to -> "start" and type "Manage App Execution Aliases". Go to it and turn off "Python"
  5. Install [LocalStack Cockpit](https://docs.localstack.cloud/get-started/cockpit/)
  6. Install localstack-cli `pip install localstack` and check version `localstack --version``
  7. Browse `http://localhost:4566/` and `http://localhost:4566/health` to test the setup
  
 Usage: `aws --endpoint-url=http://localhost:4566 sqs create-queue --queue-name myQueue`
  
**Documentation**

- [AWS Service Feature Coverage](https://docs.localstack.cloud/aws/feature-coverage/)
- [Configuration](https://docs.localstack.cloud/localstack/configuration/)
  
**Environment Variables**
```
AWS_DEFAULT_REGION=ap-southeast-2
SERVICES=s3,sns,kms,sqs,lambda,dynamodb,iam,serverless,ecr,sts,ssm,logs
DYNAMODB_SHARE_DB=1
PERSIST_ALL=1
USE_SINGLE_REGION=true
LAMBDA_EXECUTOR=docker
LAMBDA_REMOTE_DOCKER=true
LAMBDA_REMOVE_CONTAINERS=true
DEBUG=1
DATA_DIR=/tmp/localstack/data
LOCALSTACK_HOSTNAME=localhost
LOCALSTACK_API_KEY=[Insert PRO Version Key]
```
  
## DynamoDB
  
**Commands**
- `aws --endpoint-url=http://localhost:4566 dynamodb list-tables`
- `aws --endpoint-url=http://localhost:4566 dynamodb create-table --table-name DEV_Settings_TEMP22 --attribute-definitions AttributeName=InstanceId,AttributeType=S AttributeName=SettingA,AttributeType=N --key-schema AttributeName=InstanceId,KeyType=HASH AttributeName=SettingA,KeyType=RANGE --billing-mode PAY_PER_REQUEST`

**NoSQL Workbench**
  
  1. Open NoSQL Workbench
  2. Add Connection
  3. Click "DynamoDB Local"
  4. Hostname: localhost | Port: 8000

**Documentation**
- [Core Components of Amazon DynamoDB](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.CoreComponents.html)
- [Supported Data Types](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/MidLevelAPILimitations.SupportedTypes.html)
- https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithItems.html
- [NoSQL Workbench](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/workbench.settingup.html)

## Lambda
  
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
  
  1. ```npm install -g aws-cdk-local aws-cdk``` (ECR is a PRO feature https://github.com/localstack/localstack/issues/5382)
  2. ```cdklocal init app --language=csharp```
  3. Change Stack.cs file
  4. ```cdklocal synth -v``` (this must be run where the cdk.json file is located. It creates the cdk.out folder)
  5. ```cdklocal bootstrap -v``` (if you get "Unable to resolve AWS account to use." make sure the localstack service is running http://localhost:4566/health)
  6. ```cdklocal deploy -v```
  8. Test endpoint using Postman![image](https://user-images.githubusercontent.com/5598150/169179873-6bdf5b22-fcd7-4eee-a314-be505a528da5.png)
  
**Documentation**
- https://aws.amazon.com/blogs/compute/introducing-the-net-6-runtime-for-aws-lambda/
- https://docs.aws.amazon.com/lambda/latest/dg/lambda-csharp.html
- https://aws.amazon.com/blogs/developer/net-core-global-tools-for-aws/

## Cognito
  
**Commands**
  
- `aws --endpoint-url=http://localhost:9229 cognito-idp create-user-pool-client --user-pool-id "user-pool-test" --client-name "client-test2222" --generate-secret --allowed-o-auth-flows client_credentials --explicit-auth-flows "ALLOW_USER_PASSWORD_AUTH"  --allowed-o-auth-flows-user-pool-client 
  --allowed-o-auth-flows-user-pool-client --allowed-o-auth-flows "code" "implicit" --allowed-o-auth-scopes "openid" --callback-urls "["https://example.com"]" --supported-identity-providers "["MySAMLIdP", "LoginWithAmazon"]"`
- `aws --endpoint-url=http://localhost:9229 cognito-idp list-user-pool-clients --user-pool-id "user-pool-test"`
- `aws --endpoint-url=http://localhost:9229 cognito-idp admin-create-user --user-pool-id "user-pool-test" --username "testuser" --temporary-password "testpassword" --user-attributes Name=email,Value=testuser@humanforce.com Name=phone_number,Value="+61455587898"`
- `aws  --endpoint-url=http://localhost:9229  cognito-idp admin-set-user-password --user-pool-id "user-pool-test" --username testuser --password "testpassword"--permanent`
- `aws --endpoint-url=http://localhost:9229 cognito-idp initiate-auth --auth-flow USER_PASSWORD_AUTH --auth-parameters USERNAME=testuser,PASSWORD=testpassword --client-id 2xtkp25fbng4z7hquw2p44mzx`
  
**Documentation**
- https://docs.aws.amazon.com/cognito/latest/developerguide/token-endpoint.html
- https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-using-tokens-verifying-a-jwt.html
- https://aws.amazon.com/premiumsupport/knowledge-center/decode-verify-cognito-json-token
- https://github.com/jagregory/cognito-local
  
## Cloud Formation
- template.yaml: https://github.com/aws/serverless-application-model/blob/master/versions/2016-10-31.md

**Commands**
- `awslocal lambda list-functions`
- `awslocal lambda invoke --function-name helloLambda --cli-binary-format raw-in-base64-out response.json --log-type Tail`
- `awslocal lambda delete-function --function-name helloLambda`
- `awslocal apigatewayv2 get-apis`

## .NET Lambda Tools

**Commands**
`dotnet-lambda --help`

**Documentation**
- https://aws.amazon.com/developer/language/net/
- https://awslabs.github.io/aws-lambda-powertools-dotnet/
- https://docs.aws.amazon.com/lambda/latest/dg/csharp-image.html
- https://aws.amazon.com/blogs/compute/introducing-the-net-6-runtime-for-aws-lambda/
- https://aws.amazon.com/blogs/compute/building-serverless-net-applications-on-aws-lambda-using-net-7/
  
## Reference Material
- https://aws.amazon.com/getting-started/hands-on/control-your-costs-free-tier-budgets/
- https://calculator.aws
- https://aws.amazon.com/aws-cost-management/aws-budgets
- https://aws.amazon.com/faqs/
- https://aws.amazon.com/blogs/architecture/lets-architect-creating-resilient-architecture
- https://aws.amazon.com/blogs/architecture/modernization-pathways-for-a-legacy-net-framework-monolithic-application-on-aws
- https://aws.amazon.com/blogs/compute/best-practices-for-organizing-larger-serverless-applications/
- https://aws.amazon.com/blogs/architecture/throttling-a-tiered-multi-tenant-rest-api-at-scale-using-api-gateway-part-1
- https://aws.amazon.com/blogs/architecture/throttling-a-tiered-multi-tenant-rest-api-at-scale-using-api-gateway-part-2
- https://aws.amazon.com/cdk/
