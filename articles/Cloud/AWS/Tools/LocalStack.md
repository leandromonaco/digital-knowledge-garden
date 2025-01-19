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
  


