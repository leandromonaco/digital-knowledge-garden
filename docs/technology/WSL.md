# WSL

Docker Desktop for Windows provides a development environment for building, shipping, and running dockerized apps. By enabling the WSL 2 based engine, you can run both Linux and Windows containers in Docker Desktop on the same machine.

![image](https://user-images.githubusercontent.com/5598150/171560772-3528ca14-e4be-40f9-8c7c-9c032c640e6e.png)


## Configure WSL2

1. Run ```wsl --shutdown```
2. Run ```notepad "$env:USERPROFILE/.wslconfig"```

```
[wsl2]
memory=5GB   
processors=1 
```
See all configuration options on https://docs.microsoft.com/en-us/windows/wsl/wsl-config#wsl-2-settings
