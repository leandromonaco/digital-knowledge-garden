# References
- [GiHub Project](https://github.com/dotnet/tye)
- [Documentation](https://github.com/dotnet/tye/blob/main/docs/README.md)
- [Schema](https://github.com/dotnet/tye/blob/main/docs/reference/schema.md)
- [Getting Started](https://github.com/dotnet/tye/blob/main/docs/getting_started.md)
- [Recipes](https://github.com/dotnet/tye/tree/main/docs/recipes)
- [Samples](https://github.com/dotnet/tye/tree/main/samples)
- [Tye Command](https://github.com/dotnet/tye/blob/main/docs/reference/commandline/tye-run.md)
# Installation

```
dotnet tool uninstall -g Microsoft.Tye
dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"
tye --version
```
-
# Create ``tye.yaml``
- [Tye Schema File](https://raw.githubusercontent.com/dotnet/tye/main/src/schema/tye-schema.json)
  
  1. Go to the solution folder
  2. Run ```tye init``` to generate ```tye.yaml```
## ```tye.yaml``` Example
extensions:
- name: seq
  logPath: ./.logs

name: servicetemplate
network: tye-network
ingress:
    - name: Ingress
      bindings:
        - port: 50000
          protocol: https
          ip: '127.0.0.1'
      rules:
        - host: authentication-api.domain.com
          service: authentication-api
services:

    - name: authentication-api
      project: src/Authentication.API/Authentication.API.csproj
      bindings:
      - port: 51001
        protocol: https
      #replicas: 2

    - name: servicename-api
      project: src/ServiceName.API/ServiceName.API.csproj
      bindings:
      - port: 51005
        protocol: https
      #replicas: 2

    - name: mock-api
      project: src/Mock.API/Mock.API.csproj
      bindings:
      - port: 51003
        protocol: https
      #replicas: 2

    - name: featuremanagement-api
      project: src/FeatureManagement.API/FeatureManagement.API.csproj
      bindings:
      - port: 51004
        protocol: https
      #replicas: 2

    - name: analytics-api
      project: src/Analytics.API/Analytics.API.csproj
      bindings:
      - port: 51006
        protocol: https
      #replicas: 2

    - name: SqlServer
      image: mcr.microsoft.com/mssql/server:2019-latest
      bindings:
      - connectionString: Data Source=localhost,1433;Initial Catalog=ServiceDB;Persist Security Info=True;User ID=sa;Password=${env:SA_PASSWORD}
        port: 1433
      env:
      - name: SA_PASSWORD
        value: secret
      - name: ACCEPT_EULA
        value: "Y"

    - name: Redis
      image: redis
      bindings:
      - port: 6379
        connectionString: "${host}:${port}"
      args: "--requirepass secret"

    - name: DynamoDB
      image: "amazon/dynamodb-local:latest"
      args: -jar DynamoDBLocal.jar -inMemory -sharedDb
      bindings:
      - port: 8000
      env:
      - name: AWS_ACCESS_KEY_ID
        value: test
      - name: AWS_SECRET_ACCESS_KEY
        value: test
      - name: REGION
        value: ap-southeast-2
        
    - name: KMS
      image: nsmithuk/local-kms
      volumes:
         - source: "C:/"
           target: "/mnt/c"
      bindings:
      - port: 52002
      env:
      - name: KMS_REGION
        value: "ap-southeast-2"
      - name: KMS_SEED_PATH
        value: "/mnt/c/Dev/local-kms-seed.yaml"

    - name: Cognito
      image: jagregory/cognito-local:latest
      volumes:
         - source: "C:/Dev/.cognito"
           target: "/app/.cognito"
      bindings:
      - port: 9229
      env:
      - name: NODE_TLS_REJECT_UNAUTHORIZED
        value: "0"

    - name: LocalStack
      image: "localstack/localstack:latest"
      bindings:
      - port: 4566
      env:
      - name: DEBUG
        value: "1"
      - name: SERVICES
        value: "logs"

    - name: Zipkin
      image: "openzipkin/zipkin"
      bindings:
      - port: 9411
        protocol: http
```yaml
-
- https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DynamoDBLocal.DownloadingAndRunning.html ([[Docker]] Tab)
- https://docs.amazonaws.cn/en_us/amazondynamodb/latest/developerguide/DynamoDBLocal.UsageNotes.html
-
- **DynamoDB Container Note**
- ``-inMemory`` and ``-dbPath`` cannot be set at the same time
- Local [[DynamoDB]] has serious performance issues when not using ``-inMemory`` parameter
# Run Tye
- 1. Run ``tye run --port 10000 --dashboard`` (where the ``tye.yaml`` file is located)
  2. Add ``--watch`` to watch file changes in all projects.
  3. Add ``--debug *`` to debug (and attach the debugger to the application process)
-
- ```
  aws --endpoint-url=http://localhost:8000 dynamodb list-tables  
  aws --endpoint-url=http://localhost:8000 dynamodb create-table --table-name ServiceName_Setting --attribute-definitions AttributeName=TenantId,AttributeType=S --key-schema AttributeName=TenantId,KeyType=HASH --billing-mode PAY_PER_REQUEST  
  ```
-
# Troubleshooting
- **An attempt was made to access a socket in a way forbidden by its access permissions**
  Run ``net stop hns`` and ``net start hns``
-
- **Could not find an available, non-overlapping IPv4 address pool among the defaults to assign to the network**
  1. Stop running containers ``docker kill $(docker ps -q)``
  2. Remove all containers ``docker rm $(docker ps -a -q)``
  3. Remove unused networks ``docker network prune``