# Clean File Versions

This command line utility aggregates all files in a directory given a file naming convention of `{name}_{version}.{ext}`, where `version` is numeric. All files that share `name` and `ext` will be removed except for the highest number of `version`.

Given the following files:

* `fileA_01.png`
* `fileA_04.png`
* `fileA_01.txt`
* `fileA_02.txt`
* `fileB_01.txt`
* `fileB_03.txt`
* `some_file.txt`

The following files would be removed:

* `fileA_01.png`
* `fileA_01.txt`
* `fileB_01.txt`

> The utility is case-insensitive when comparing file names. So `FileA_01` would still be compared against `filea_02`.

## Arguments

`path`: The path in which to clean file versions. Optional. If no path is specified, the directory the utility is called from will be used.

### Example

```bash
# absolute path
CleanFileVersions.exe C:\files

# relative path
CleanFileVersions.exe .\files\
```

## Execute Globally

You can download [CleanFileVersions@1.0.0](https://github.com/JaimeStill/CleanFileVersions/releases/tag/v1.0.0) and place it anywhere that it can be seen from the `PATH` environment variable.

## Publishing

> You will need to have the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download) installed.

The following is used to publish this utility:

```pwsh
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -o {path-to-publish-to}
```