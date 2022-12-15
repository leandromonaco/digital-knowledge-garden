- Open a Command Prompt (cmd)
-
- https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-xp/bb490890(v=technet.10)
-
- ## Example with [[Angular CLI]]
-
-
-
- **AngularBuild.bat**
- ```
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