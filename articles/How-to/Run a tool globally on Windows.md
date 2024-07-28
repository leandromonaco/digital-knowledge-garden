To add a folder to the `PATH` environment variable:

1. In Windows File Explorer, navigate to the folder containing the EXE.
2. Copy the full path to the folder from the address bar.
3. Open the Start menu, search for "Environment Variables", and select "Edit the system environment variables".
4. Click the "Environment Variables" button.
5. Under "System Variables", scroll down and select "Path", then click "Edit".
6. Click "New", paste the path to the folder containing the EXE, and click "OK" on all open windows.
7. Open a command prompt window and type the name of the EXE. It should run from any folder because the folder is included in the `PATH` environment variable.


The folder must be under `C:\Program Files\local-dev-cli`, then you can run `localdev` (`localdev.exe`) from anywhere

```csharp
//Make the tool accesible globally
string folderPathToAdd = @"C:\Program Files\local-dev-cli";
string pathVariable = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) ?? "";
if (!pathVariable.Contains(folderPathToAdd))
{
	pathVariable = $@"{folderPathToAdd};{pathVariable}";
	Environment.SetEnvironmentVariable("Path", pathVariable, EnvironmentVariableTarget.Machine);
}
```
