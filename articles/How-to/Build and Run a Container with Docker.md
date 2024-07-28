

1. Navigate to the folder where the Dockerfile is stored
2. Run `docker build -t angular-container:1.0 .`
3. Search ImageID by running `docker images`
4. Run `docker run -p 80:80 469b3a773ed7`

- ## Running Docker Windows and Linux Containers Simultaneously
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
-
## Images
- https://hub.docker.com/_/microsoft-windows-nanoserver
- https://hub.docker.com/_/nginx
- https://hub.docker.com/_/microsoft-mssql-server
- https://hub.docker.com/_/redis

- ## Docker Pull
- `docker pull jagregory/cognito-local:latest`
- `docker pull localstack/localstack:latest`
- `docker pull amazon/dynamodb-local:latest`
- `docker pull redis:latest`
- `docker pull mcr.microsoft.com/mssql/server:2019-latest`
- `docker pull datalust/seq:latest`

### Tags

- #Docker 


