# WSL
  
  Docker Desktop for Windows provides a development environment for building, shipping, and running dockerized apps. By enabling the WSL 2 based engine, you can run both Linux and Windows containers in Docker Desktop on the same machine.
-
## Install Ubuntu
- 1. Open Powershell window with admin rights
  2. Run ``wsl --install -d Ubuntu``
  3. Create a default UNIX user account
-
## Windows Process
- ![image](https://user-images.githubusercontent.com/5598150/171560772-3528ca14-e4be-40f9-8c7c-9c032c640e6e.png)
-
## Configure WSL2

1. Run ```wsl --shutdown```
2. Run ```notepad "$env:USERPROFILE/.wslconfig"```

```
[wsl2]
memory=5GB   
processors=1 
```
See all configuration options on https://docs.microsoft.com/en-us/windows/wsl/wsl-config#wsl-2-settings
-
## Documentation
- [Developing on Amazon Linux 2 using Windows](https://aws.amazon.com/blogs/developer/developing-on-amazon-linux-2-using-windows/)
  Documentation: https://help.ubuntu.com
- Management: https://landscape.canonical.com
- Support: https://ubuntu.com/advantage