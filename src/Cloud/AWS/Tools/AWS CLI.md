## AWS CLI

**Commands**
- `aws --endpoint-url=http://localhost:4566 dynamodb create-table --table-name ServiceName_Setting --attribute-definitions AttributeName=TenantId,AttributeType=S --key-schema AttributeName=TenantId,KeyType=HASH --billing-mode PAY_PER_REQUEST`
- `aws --endpoint-url=http://localhost:4566 sqs create-queue --queue-name sample-queue2`
- `aws --endpoint-url=http://localhost:4566 kms --region ap-southeast-2 create-key --tags TagKey=Purpose,TagValue=Test --description "Development test key"`
- `aws --endpoint-url=http://localhost:4566 kms encrypt --region ap-southeast-2 --key-id 1cc95196-acb1-4279-9063-a3daa3d9a20d --plaintext fileb://C:\TEMP\connectionstring.txt`

**Documentation**
- [AWS CLI Command Reference](https://awscli.amazonaws.com/v2/documentation/api/latest/index.html)
- [dynamodb](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/dynamodb/index.html)