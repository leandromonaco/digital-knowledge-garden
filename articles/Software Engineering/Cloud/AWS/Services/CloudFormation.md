- template.yaml: https://github.com/aws/serverless-application-model/blob/master/versions/2016-10-31.md

**Commands**
- `awslocal lambda list-functions`
- `awslocal lambda invoke --function-name helloLambda --cli-binary-format raw-in-base64-out response.json --log-type Tail`
- `awslocal lambda delete-function --function-name helloLambda`
- `awslocal apigatewayv2 get-apis`