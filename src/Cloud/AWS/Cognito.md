```
aws --endpoint-url=http://localhost:52007 cognito-idp create-user-pool --pool-name "localcloud"
aws --endpoint-url=http://localhost:52007 cognito-idp list-user-pools --max-results 20
```

Copy user pool id

```
aws --endpoint-url=http://localhost:52007 cognito-idp create-user-pool-client --user-pool-id "ap-southeast-2_366f47d5c8fd1bbefcf3afec577af68d09ebfa7d5" --client-name msnotification --generate-secret
```

Copy Client Id

```
aws --endpoint-url=http://localhost:52007 cognito-idp admin-create-user --user-pool-id "ap-southeast-2_366f47d5c8fd1bbefcf3afec577af68d09ebfa7d5" --username "testuser"

aws --endpoint-url=http://localhost:52007 cognito-idp admin-set-user-password --user-pool-id "ap-southeast-2_366f47d5c8fd1bbefcf3afec577af68d09ebfa7d5" --username "testuser" --password "Hum4nF0rc3!" --permanent

aws --endpoint-url=http://localhost:52007 cognito-idp initiate-auth --auth-flow USER_PASSWORD_AUTH --auth-parameters USERNAME=testuser,PASSWORD=Hum4nF0rc3! --client-id {INSERT_NEW_CLIENTID} --region ap-southeast-2
```