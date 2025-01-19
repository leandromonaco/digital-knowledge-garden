## Intro

Docker Desktop for Windows provides a development environment for building, shipping, and running dockerized apps. By enabling the WSL 2 based engine, you can run both Linux and Windows containers in Docker Desktop on the same machine.


## Configuration

> **Warning**
> This process requires reboot

1. Run `Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All`
2. Run `Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux`
3. Run `winget install -e --id Docker.DockerDesktop`
4. Run `winget install -e --id Docker.DockerCLI
5. Click Settings
6. Tick the “Start Docker Desktop when you log in“ option
7. Run `systeminfo | find "System Type"` to check if your system is x64 (if so, [download wsl_update_x64.msi](https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi))
8. Run `wsl --set-default-version 2`
9. Run `wsl --install -d Ubuntu` (This is optional - Docker will configure `docker-desktop-data` as the default distro)
10. Create a default UNIX user account
11. Check WSL2 Settings

**Documentation:**
https://learn.microsoft.com/en-us/windows/wsl/wsl-config#wsl-2-settings
https://learn.microsoft.com/en-us/windows/wsl/install
https://learn.microsoft.com/en-us/windows/wsl/install-manual


### Reinstall Distribution

```
wsl --list
wsl --unregister Ubuntu
wsl --list
wsl --install -d Ubuntu
```

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
- [Install Hyper-V on Windows 10](https://learn.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v)
- Documentation: https://help.ubuntu.com
- Management: https://landscape.canonical.com
- Support: https://ubuntu.com/advantage
- [Comparing WSL Versions](https://learn.microsoft.com/en-us/windows/wsl/compare-versions)


### Tags

- #Docker 

