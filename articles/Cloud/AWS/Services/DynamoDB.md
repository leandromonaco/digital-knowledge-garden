 
**AWS CLI**
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