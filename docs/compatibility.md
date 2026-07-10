# Compatibility matrix

Nothing in this table is implemented unless marked otherwise.

| Guest | Architecture | Planned machine | Current state |
|---|---|---|---|
| Windows CE 5 | ARMv4I/ARMv5 | Device Emulator / board-specific | Planned |
| Windows CE 6 | ARMv4I/ARMv5 | Device Emulator / cevirt | Planned |
| Windows Embedded Compact 7 | ARMv7 | cevirt / selected OMAP board | Planned |
| Windows Embedded Compact 2013 | ARMv7 | cevirt | Planned |
| Windows Mobile 5 | ARMv4I | Device Emulator S3C2410 | Planned |
| Windows Mobile 6 | ARMv4I | Device Emulator S3C2410 | Planned |
| Windows Mobile 6.5 | ARMv4I | Device Emulator S3C2410 | Planned |

| Host | Architecture | UI | Emulator integration | Current state |
|---|---|---|---|---|
| Raspberry Pi OS | ARM64 | Avalonia DRM/X11 | QEMU process | Foundation |
| Desktop Linux | x64/ARM64 | Avalonia X11 | QEMU process | Foundation |
| Windows | x64/ARM64 | Avalonia | QEMU process | Foundation |
| Android | ARM64/ARMv7 | Avalonia Android | Native service | Planned |
