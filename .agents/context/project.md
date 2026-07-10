# Project context

Cedroid aims to run Windows CE 5/6, Windows Embedded Compact 7/2013, and Windows Mobile 5/6/6.5 guests on modern hosts.

## Product direction

- Raspberry Pi OS ARM64 is the first implementation target.
- Android is the second target, after the core has stable process, display, input, and storage contracts.
- Avalonia is the shared .NET UI framework.
- QEMU is the intended CPU/system emulation backend.
- Original Device Emulator compatibility and a custom `cevirt` BSP are separate machine tracks.

## Engineering preferences

- C# first.
- No C++ in new Cedroid code.
- Small amounts of C are acceptable for QEMU and WinCE drivers.
- Out-of-process boundaries are preferred on desktop/Linux.
- No software installation by agents.

## Reality checks

- A WinCE ROM is board/BSP specific; matching CPU architecture is insufficient.
- KVM is an optional acceleration path, never the universal baseline.
- Android hardware integration is API-level proxying, not arbitrary controller passthrough.
- GPU acceleration requires guest drivers; virtio-gpu is not automatically usable by WinCE.
- ROM redistribution rights must not be inferred from public download availability.
