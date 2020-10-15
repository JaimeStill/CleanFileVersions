# Clean File Versions

This command line utility aggregates all files in a directory given a file naming convention of `{name}_{version}.{ext}`, where `version` is numeric. All files that share `name` and `ext` will be removed except for the highest number of `version`.

## Arguments

`path`: The path in which to clean file versions. Optional. If no path is specified, the directory the utility is called from will be used.

### Example

```pwsh
CleanFileVersions.exe "C:\\files"
```

## Publishing

You will need to have the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download) installed.

```pwsh
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -o {path-to-publish-to}
```