# Docker and dotnet

[Built-in container support for the .NET SDK](https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk/)

```
# create a new project and move to its directory
dotnet new mvc -n my-awesome-container-app
cd my-awesome-container-app

# add a reference to a (temporary) package that creates the container
dotnet add package Microsoft.NET.Build.Containers

# publish your project for linux-x64
dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer

# run your app using the new container
docker run -it --rm -p 5010:80 my-awesome-container-app:1.0.0
```

Now you can go to `http://localhost:5010` and you should see the sample MVC application, rendered in all its glory.

# Build and Run container

1. Navigate to the folder where the Dockerfile is stored
2. Run ```docker build -t angular-container:1.0 .```
3. Search ImageID by running ```docker images```
4. Run ```docker run -p 80:80 469b3a773ed7```

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
# Images
- https://hub.docker.com/_/microsoft-windows-nanoserver
- https://hub.docker.com/_/nginx
- https://hub.docker.com/_/microsoft-mssql-server
- https://hub.docker.com/_/redis


# Useful Commands

- Display containers' resource usage statistics ```docker stats --all --no-stream```
- Stop running containers ```docker kill $(docker ps -q)```
- Remove all containers ```docker rm $(docker ps -a -q)```
- Remove all images ```docker rmi $(docker images -q)```
