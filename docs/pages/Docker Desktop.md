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

## Documentation

- [Developing on Amazon Linux 2 using Windows](https://aws.amazon.com/blogs/developer/developing-on-amazon-linux-2-using-windows/)
- Documentation: https://help.ubuntu.com
- Management: https://landscape.canonical.com
- Support: https://ubuntu.com/advantage
