## Intro

Docker Desktop for Windows provides a development environment for building, shipping, and running dockerized apps. By enabling the WSL 2 based engine, you can run both Linux and Windows containers in Docker Desktop on the same machine.


## Configuration

> **Warning**
> This process requires reboot

1. Ensure [Hyper-V has been enabled](https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v)
2. Run `winget install -e --id Docker.DockerDesktop`
3. Click Settings
4. Tick the “Start Docker Desktop when you log in“ option
5. Run `systeminfo | find "System Type"` to check if your system is x64 (if so, [download wsl_update_x64.msi](https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi))
6. Run `wsl --set-default-version 2`
7. Run `wsl --install -d Ubuntu`
8. Create a default UNIX user account

## WSL Process
![image](https://user-images.githubusercontent.com/5598150/171560772-3528ca14-e4be-40f9-8c7c-9c032c640e6e.png)

## Configure WSL2

1. Run ```wsl --shutdown```
2. Run ```notepad "$env:USERPROFILE/.wslconfig"```

```
[wsl2]
memory=5GB   
processors=1 
```

See all configuration [options](https://docs.microsoft.com/en-us/windows/wsl/wsl-config#wsl-2-settings)

## Build and Run a Container

1. Navigate to the folder where the Dockerfile is stored
2. Run `docker build -t angular-container:1.0 .`
3. Search ImageID by running `docker images`
4. Run `docker run -p 80:80 469b3a773ed7`

## Running Docker Windows and Linux Containers Simultaneously
- https://devblogs.microsoft.com/premier-developer/running-docker-windows-and-linux-containers-simultaneously/
  
## Dockerfile example
```
FROM node:lts as node

RUN npm install -g @angular/cli

WORKDIR /usr/src/app
COPY src/TeamHub.UI/ ./my-app/

WORKDIR /usr/src/app/my-app
RUN npm install
RUN npm run build

FROM nginx:alpine
COPY --from=node /usr/src/app/my-app/dist/team-hub.ui /usr/share/nginx/html
```

## Images
- https://hub.docker.com/_/microsoft-windows-nanoserver
- https://hub.docker.com/_/nginx
- https://hub.docker.com/_/microsoft-mssql-server
- https://hub.docker.com/_/redis

```
docker pull jagregory/cognito-local:latest
docker pull localstack/localstack:latest
docker pull amazon/dynamodb-local:latest
docker pull redis:latest
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker pull datalust/seq:latest
docker pull motoserver/moto:latest
docker pull jijiechen/papercut:latest
```

## Commands

- Display containers' resource usage statistics `docker stats --all --no-stream`
- Stop running containers `docker kill $(docker ps -q)`
- Remove all containers `docker rm $(docker ps -a -q)`
- Remove all images `docker rmi $(docker images -q)`

## Security

https://docs.docker.com/scout/

## Documentation

- [Developing on Amazon Linux 2 using Windows](https://aws.amazon.com/blogs/developer/developing-on-amazon-linux-2-using-windows/)
- Documentation: https://help.ubuntu.com
- Management: https://landscape.canonical.com
- Support: https://ubuntu.com/advantage