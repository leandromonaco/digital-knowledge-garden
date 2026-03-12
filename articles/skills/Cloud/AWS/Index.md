### Services
- [[CloudFormation]]
- [[Cognito]]
- [[DynamoDB]]
- [[Lambda]]

## Tools

- [[AWS CLI]]
- [[SAM CLI]]
- [[Moto]]
- [[LocalStack]]
- [[Lambda Tools]]
- [[CDK]]

### Installation

- `winget install -e --id Amazon.AWSCLI`
- `winget install -e --id Amazon.SAM-CLI`
- `winget install -e --id Amazon.NoSQLWorkbench`
- `npm install -g aws-cdk`
- `dotnet tool install -g Amazon.Lambda.Tools`
-  `npm install -g aws-cdk-local aws-cdk` (ECR is a PRO feature https://github.com/localstack/localstack/issues/5382)
- [AWS Application Composer](https://aws.amazon.com/blogs/aws/aws-application-composer-now-generally-available-visually-build-serverless-applications-quickly/)


  ### Upgrade
  
- `winget upgrade -e --id Amazon.SAM-CLI`
- `sam --version`
- `winget upgrade -e --id Amazon.AWSCLI`
- `aws --version`
- `npm upgrade -g aws-cdk`
- `cdk --version`
- `dotnet tool update -g Amazon.Lambda.Tools`

 
### Credentials

1. Run `aws configure`
2. AWS Access Key ID: `test`
3. AWS Secret Access Key: `test`
4. Default region name: `ap-southeast-2`
5. Default output format: `json`
6. Run `aws configure list` to verify the newly configured credentials (stored in `C:\Users\{USER}\.aws\credentials`)









  



  



  
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
