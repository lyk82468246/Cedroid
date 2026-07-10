# Cedroid

[简体中文](README.zh-CN.md)

Cedroid is an early-stage, cross-platform framework for running Microsoft Windows CE and Windows Mobile guests on modern ARM devices. Raspberry Pi OS is the first host target; Android follows after the portable emulator control plane and machine model are stable.

> **Status:** foundation only. The repository currently contains the .NET/Avalonia control plane, lifecycle model, QMP client, platform abstractions, tests, documentation, and CI. It does **not** boot Windows CE yet and does not bundle QEMU or any proprietary ROM.

## Goals

- Run CE 5, CE 6, Windows Embedded Compact 7/2013, and Windows Mobile 5/6/6.5 guests.
- Keep product and platform-integration code in modern C#.
- Treat QEMU as an isolated C data plane controlled through QMP and Cedroid protocols.
- Support Raspberry Pi OS ARM64 first, then desktop Linux, Windows, and Android.
- Provide a compatibility machine for original Device Emulator ROMs and a paravirtualized `cevirt` machine for rebuildable BSPs.
- Bridge display, touch, audio, networking, WLAN, Bluetooth, telephony control, location, and sensors through a versioned guest protocol.

## Non-goals for the first releases

- Shipping Microsoft or OEM ROM images, SDKs, BSPs, or binaries.
- Claiming near-native performance on ordinary unprivileged Android devices.
- Raw cellular baseband, Bluetooth HCI, or Wi-Fi controller passthrough.
- Full Direct3D Mobile acceleration before framebuffer and 2D paths are correct.

## Architecture

```text
Avalonia UI / CLI (.NET)
        |
Application + lifecycle model
        |
QMP client + Cedroid control protocol
        |
isolated QEMU process / Android native service
        |
S3C2410 compatibility machine | cevirt machine
        |
CEBridge guest additions and WinCE drivers
```

The control plane never depends on QEMU internals. QEMU and Windows CE drivers remain native C components; high-level host integrations live behind .NET interfaces.

See [architecture overview](docs/architecture/overview.md) and [roadmap](docs/roadmap.md).

## Repository layout

```text
.agents/          Agent context, plans, roles, and handoff conventions
.github/          CI, issue templates, and dependency automation
docs/             Architecture, ADRs, research, security, and roadmap
eng/              Build entry points; they never install dependencies
native/           QEMU patch boundary, CEBridge schema, guest-driver plans
src/              .NET product projects
tests/            Unit and integration-test projects
```

## Build

Cedroid requires a .NET 10 SDK. The repository never installs it automatically.

```powershell
./eng/build.ps1
```

```bash
./eng/build.sh
```

Both scripts restore, build, and test `Cedroid.slnx`. The same gates run in GitHub Actions. Visual Studio is optional; VS Code, Rider, or the command line are sufficient.

## Legal and safety

- Do not commit or redistribute proprietary ROM, NK, OEM, SDK, BSP, CAB, or firmware files.
- Test with legally obtained images supplied by the user.
- Windows CE systems are obsolete and unsafe on hostile networks. Cedroid will default to NAT, no inbound forwarding, and least-privilege host brokers.
- Native emulator input is untrusted. See the [threat model](docs/security/threat-model.md).

## Contributing

Read [CONTRIBUTING.md](CONTRIBUTING.md) and [AGENTS.md](AGENTS.md). Architectural decisions are recorded under [docs/adr](docs/adr).

## License

Cedroid is licensed under GPL-2.0-only. Third-party components retain their own licenses. No Microsoft or OEM software is included.
