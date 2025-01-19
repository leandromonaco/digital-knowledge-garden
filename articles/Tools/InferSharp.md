## Getting started with Infer

With Infer# v1.4 you can identify [[Security]] and [[Performance]] issues with a single click, all in VS2022 and VSCode. First, make sure that [Windows Subsystem for Linux (WSL)](https://learn.microsoft.com/windows/wsl/install) is properly installed. Then, download and install the InferSharp extension from the [Visual Studio](https://marketplace.visualstudio.com/items?itemName=matthew-jin.infersharp) or [Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=matthew-jin.infersharp-ext) marketplaces. In this article, we’ll show the VS experience, which is mimicked in VS Code. You can also use Infer# directly in [WSL](https://github.com/microsoft/infersharp/blob/main/RUNNING_INFERSHARP_ON_WINDOWS.md) and [Docker](https://github.com/microsoft/infersharp/blob/main/RUNNING_IN_DOCKER.md).

The extension adds an *Infer# Analysis* menu item to the Tools  menu. The first time it’s selected, it will complete setup by downloading and installing the Infer# custom WSL distro from Github.
- ![image.png](../assets/image_1667865010674_0.png)
-
## Analyze your code

After waiting for setup to complete, selecting the *Infer# Analysis* menu item again will prompt you to provide a directory tree (defaulting  to the solution directory, if it exists) containing the DLLs and PDBs you want to analyze. Your selection is automatically saved for future runs in the *.infersharpconfig* file created in your project directory. The analysis will then run, displaying the warnings in the Error List pane. Additionally, information about the analysis steps is shown in a pane on the right side of the editor, with clickable links to the relevant lines of code.
- ![image.png](../assets/image_1667865053544_0.png)
# References
- https://devblogs.microsoft.com/dotnet/slaying-zombie-no-repo-crashes-with-infersharp/
- https://devblogs.microsoft.com/dotnet/infer-interprocedural-memory-safety-analysis-for-c/
- https://github.com/microsoft/infersharp