[CmdletBinding()]
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw "A preinstalled .NET 10 SDK is required. This script does not install software."
}

$sdks = & dotnet --list-sdks
if (-not ($sdks -match '^10\.')) {
    throw "A preinstalled .NET 10 SDK is required. This script does not install software."
}

Push-Location $root
try {
    & dotnet restore Cedroid.slnx
    & dotnet build Cedroid.slnx --no-restore --configuration $Configuration
    & dotnet test Cedroid.slnx --no-build --configuration $Configuration
    & dotnet format Cedroid.slnx --verify-no-changes --no-restore
}
finally {
    Pop-Location
}
