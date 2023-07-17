**Tag: #Cognito**

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
