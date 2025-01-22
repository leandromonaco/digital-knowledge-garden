**Tags: #Cognito**

Execute `POST http://localhost:52009/moto-api/seed?a=42` to ensure the resulting state will always be the same.


```
aws --endpoint-url=http://localhost:52009 cognito-idp create-user-pool --pool-name "LocalDev"

aws --endpoint-url=http://localhost:52009 cognito-idp create-user-pool-client --user-pool-id "ap-southeast-2_2ee240fa04d40b5bbea96b2b752cb0b26dc4366b8" --client-name msnotification --generate-secret

aws --endpoint-url=http://localhost:52009 cognito-idp admin-create-user --user-pool-id "ap-southeast-2_2ee240fa04d40b5bbea96b2b752cb0b26dc4366b8" --username "testuser"

aws --endpoint-url=http://localhost:52009 cognito-idp admin-set-user-password --user-pool-id "ap-southeast-2_2ee240fa04d40b5bbea96b2b752cb0b26dc4366b8" --username "testuser" --password "L0c4lD3v!!!" --permanent

aws --endpoint-url=http://localhost:52009 cognito-idp initiate-auth --auth-flow USER_PASSWORD_AUTH --auth-parameters USERNAME=testuser,PASSWORD=L0c4lD3v!!! --client-id 71hfe86y5r215dew1zcyqesh0a --region ap-southeast-2
```


### Troubleshoot

```
aws --endpoint-url=http://localhost:52009 cognito-idp list-user-pools --max-results 20

aws --endpoint-url=http://localhost:52009 cognito-idp list-user-pool-clients --user-pool-id ap-southeast-2_2ee240fa04d40b5bbea96b2b752cb0b26dc4366b8
```

### Documentation

- https://docs.aws.amazon.com/cognito/latest/developerguide/token-endpoint.html
- https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-using-tokens-verifying-a-jwt.html
- https://aws.amazon.com/premiumsupport/knowledge-center/decode-verify-cognito-json-token
- https://github.com/jagregory/cognito-local

## To Review
  
**Commands**
  
- `aws --endpoint-url=http://localhost:9229 cognito-idp create-user-pool-client --user-pool-id "user-pool-test" --client-name "client-test2222" --generate-secret --allowed-o-auth-flows client_credentials --explicit-auth-flows "ALLOW_USER_PASSWORD_AUTH"  --allowed-o-auth-flows-user-pool-client 
  --allowed-o-auth-flows-user-pool-client --allowed-o-auth-flows "code" "implicit" --allowed-o-auth-scopes "openid" --callback-urls "["https://example.com"]" --supported-identity-providers "["MySAMLIdP", "LoginWithAmazon"]"`
- `aws --endpoint-url=http://localhost:9229 cognito-idp list-user-pool-clients --user-pool-id "user-pool-test"`
- `aws --endpoint-url=http://localhost:9229 cognito-idp admin-create-user --user-pool-id "user-pool-test" --username "testuser" --temporary-password "testpassword" --user-attributes Name=email,Value=testuser@humanforce.com Name=phone_number,Value="+61455587898"`
- `aws  --endpoint-url=http://localhost:9229  cognito-idp admin-set-user-password --user-pool-id "user-pool-test" --username testuser --password "testpassword"--permanent`
- `aws --endpoint-url=http://localhost:9229 cognito-idp initiate-auth --auth-flow USER_PASSWORD_AUTH --auth-parameters USERNAME=testuser,PASSWORD=testpassword --client-id 2xtkp25fbng4z7hquw2p44mzx`
  
