## Reference Material
- [Documentation](https://github.com/dotnet/tye/blob/main/docs/README.md)
- [Schema](https://github.com/dotnet/tye/blob/main/docs/reference/schema.md)
- [Getting Started](https://github.com/dotnet/tye/blob/main/docs/getting_started.md)
- [Recipes](https://github.com/dotnet/tye/tree/main/docs/recipes)
- [Samples](https://github.com/dotnet/tye/tree/main/samples)
- [Tye Command](https://github.com/dotnet/tye/blob/main/docs/reference/commandline/tye-run.md)

## Installation

```
dotnet tool uninstall -g Microsoft.Tye
dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"
tye --version
```

## Create ```tye.yaml```

1. Go to the solution folder
2. Run ```tye init``` to generate ```tye.yaml```
3. Run ```tye run --port 10000 --dashboard``` (where the ```tye.yaml``` file is located)
- Add ```--watch``` to watch file changes in all projects.
- Add ```--debug *``` to debug (and attach the debugger to the application process)

## ```tye.yaml``` Example

```yaml

# tye application configuration file
# read all about it at https://github.com/dotnet/tye
#
# when you've given us a try, we'd love to know what you think:
#    https://aka.ms/AA7q20u
#

extensions:
- name: seq
  logPath: ./.logs

name: servicetemplate
#registry: exampleuser (required for Kubernetes)
#namespace: examplenamespace
network: tye-network
ingress:
    - name: Ingress
      bindings:
        - port: 51000
          protocol: https
          ip: '127.0.0.1'
      rules:
        - host: notifications.domain.com
          service: servicename-api

services:
    - name: servicename-api
      project: ServiceName.API/ServiceName.API.csproj
      bindings:
      - port: 51001
        protocol: https
      #replicas: 2

    - name: SqlServer
      image: mcr.microsoft.com/mssql/server:2019-latest
      bindings:
      - connectionString: Data Source=host.docker.internal,1433;Initial Catalog=ServiceDB;Persist Security Info=True;User ID=sa;Password=${env:SA_PASSWORD}
        port: 1433
      env:
      - name: SA_PASSWORD
        value: M3rz0ug4!!!!
      - name: ACCEPT_EULA
        value: "Y"

    - name: Redis
      image: redis
      bindings:
      - port: 6379
        connectionString: "${host}:${port}"
      #args: "redis-cli -h redis MONITOR"

    # https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DynamoDBLocal.DownloadingAndRunning.html (Docker Tab)
    # https://docs.amazonaws.cn/en_us/amazondynamodb/latest/developerguide/DynamoDBLocal.UsageNotes.html
    # aws --endpoint-url=http://localhost:8000 dynamodb list-tables
    # aws --endpoint-url=http://localhost:8000 dynamodb create-table --table-name ServiceName_Setting --attribute-definitions AttributeName=TenantId,AttributeType=S --key-schema AttributeName=TenantId,KeyType=HASH --billing-mode PAY_PER_REQUEST
    # -inMemory and -dbPath cannot be set at the same time
    # Local DynamoDB has serious performance issues when not using -inMemory parameter
    - name: DynamoDB
      image: "amazon/dynamodb-local:latest"
      args: -jar DynamoDBLocal.jar -inMemory -sharedDb
      #args: -jar DynamoDBLocal.jar -sharedDb -dbPath /mnt/c/Temp/DynamoDB
      #volumes:
      #   - source: "./"
      #     target: "/mnt/c/Temp/DynamoDB"
      bindings:
      - port: 8000
      env:
      - name: AWS_ACCESS_KEY_ID
        value: test
      - name: AWS_SECRET_ACCESS_KEY
        value: test
      - name: REGION
        value: ap-southeast-2
        
    #aws --endpoint-url=http://localhost:52002 kms --region ap-southeast-2 create-key --key-spec RSA_4096 --key-usage ENCRYPT_DECRYPT
    #aws --endpoint-url=http://localhost:52002 kms --region ap-southeast-2 list-keys
    - name: KMS
      image: nsmithuk/local-kms
      volumes:
         - source: "./"
           target: "/mnt/c/Temp/Kms"
      bindings:
      - port: 52002

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


```

## Troubleshooting

### An attempt was made to access a socket in a way forbidden by its access permissions
Run ```net stop hns``` and ```net start hns```

### Could not find an available, non-overlapping IPv4 address pool among the defaults to assign to the network
1. Stop running containers ```docker kill $(docker ps -q)```
2. Remove all containers ```docker rm $(docker ps -a -q)```
3. Remove unused networks ```docker network prune```
