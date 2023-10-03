https://docs.docker.com/engine/install/

- Display containers' resource usage statistics `docker stats --all --no-stream`
- Stop running containers `docker kill $(docker ps -q)`
- Remove all containers `docker rm $(docker ps -a -q)`
- Remove all images `docker rmi $(docker images -q)`

### docker init [Example of selecting ASP.NET](https://docs.docker.com/engine/reference/commandline/init/#example-of-selecting-aspnet)

The following example shows the prompts that appear after selecting `ASP.NET` and example input. The ASP.NET template also creates a `README.Docker.md` file with additional information about building and deploying your application.

```console
? What application platform does your project use? ASP.NET
? What's the name of your solution's main project? myapp
? What version of .NET do you want to use? 6.0
? What local port do you want to use to access your server? 8000

CREATED: .dockerignore
CREATED: Dockerfile
CREATED: compose.yaml
CREATED: README.Docker.md

✔ Your Docker files are ready!

Take a moment to review them and tailor them to your application.

When you're ready, start your application by running: docker compose up --build

Your application will be available at http://localhost:8000
```
### Tags

- #Docker 

