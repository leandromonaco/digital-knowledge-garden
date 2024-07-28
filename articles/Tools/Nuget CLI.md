
## Installation
`winget install -e --id Microsoft.NuGet`

## Feed
```
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

## Commands
You can list the local caches with this command:

```
nuget locals all -list
```

You can clear all caches with this command:

```
nuget locals all -clear
```