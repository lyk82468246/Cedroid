# ADR 0001: Use Avalonia for the shared UI

- Status: accepted
- Date: 2026-07-10

## Context

Cedroid must target Raspberry Pi OS/Linux and later Android while keeping the product stack centered on .NET. .NET MAUI does not officially target Linux. Qt supports the targets but moves primary UI development to C++/QML.

## Decision

Use Avalonia 12 for the shared UI and CommunityToolkit.Mvvm for presentation logic. Keep platform capabilities behind interfaces so Android and Linux implementations can differ.

## Consequences

- Raspberry Pi ARM32/ARM64 and Android can share C#/XAML UI code.
- Native display embedding still requires platform-specific transport work.
- Older Android versions may require a separately evaluated compatibility track.
- The emulator core remains independent of Avalonia.
