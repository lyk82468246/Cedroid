#!/usr/bin/env sh
set -eu

configuration="${CONFIGURATION:-Release}"
root="$(CDPATH= cd -- "$(dirname -- "$0")/.." && pwd)"

if ! command -v dotnet >/dev/null 2>&1; then
    echo "A preinstalled .NET 10 SDK is required. This script does not install software." >&2
    exit 1
fi

if ! dotnet --list-sdks | grep -q '^10\.'; then
    echo "A preinstalled .NET 10 SDK is required. This script does not install software." >&2
    exit 1
fi

cd "$root"
dotnet restore Cedroid.slnx
dotnet build Cedroid.slnx --no-restore --configuration "$configuration"
dotnet test Cedroid.slnx --no-build --configuration "$configuration"
dotnet format Cedroid.slnx --verify-no-changes --no-restore
