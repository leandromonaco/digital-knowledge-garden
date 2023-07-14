> [# Command-line reference A-Z](https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-xp/bb490890(v=technet.10))

## Example with [[Angular]]

- **AngularParallelBuild.bat**
```
  start AngularBuild.bat C:\Dev\App1
  start AngularBuild.bat C:\Dev\App2
  start AngularBuild.bat C:\Dev\App3
  start AngularBuild.bat C:\Dev\App3
  ```

- **AngularBuild.bat**
```
  cd %1  
  ECHO Removing node_modules folder  
  RMDIR /s /q node_modules  
  ECHO Building Angular App  
  call npm cache clean -f  
  call npm install  
  call npm ci  
  call ng build  
  ECHO Build Finished  
  ```