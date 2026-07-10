# Getting started

## Prerequisites

- Git
- A preinstalled .NET 10 SDK

Visual Studio is optional. Repository automation must not install SDKs, workloads, IDEs, QEMU, or system packages.

## Build and test

```powershell
./eng/build.ps1
```

or:

```bash
./eng/build.sh
```

The scripts fail with an actionable message when the SDK is absent.

## Run

```text
dotnet run --project src/Cedroid.App/Cedroid.App.csproj
dotnet run --project src/Cedroid.Cli/Cedroid.Cli.csproj -- --json
```

## Working without a local SDK

Edit the repository normally and push a branch. GitHub Actions restores, builds, tests, and checks formatting in a clean hosted environment. Do not weaken CI because a local tool is unavailable.

## ROMs and instances

Create local `roms/` and `instances/` directories as needed. Both are ignored by Git. Never rename a proprietary image to bypass ignore rules or include it in fixtures.
