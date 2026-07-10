# Open-source survey

Research snapshot: 2026-07-10.

## QEMU

QEMU is the selected system-emulation foundation. It provides ARM system emulation, TCG, optional KVM, QMP, block formats, and network backends. It does not provide a turnkey Windows CE machine. Recent upstream releases have also removed several obsolete PDA board models and 32-bit host support, so Cedroid must keep host and machine compatibility explicit.

- <https://github.com/qemu/qemu>
- <https://www.qemu.org/docs/master/system/introduction.html>
- <https://www.qemu.org/docs/master/about/removed-features.html>

## CERF

CE Runtime Foundation is the most relevant behavioral reference found. Its published compatibility list includes multiple CE and Windows Mobile boards, guest additions, display, input, audio, and networking. The inspected 2026-07-09 tree targets Win32/x86 and emits x86 machine code; it is not an Android/ARM-portable backend. The inspected tree also had no root license file, so Cedroid must not copy its code without explicit permission.

- <https://github.com/gweslab/cerf>

## Limbo

Limbo demonstrates packaging a QEMU-derived emulator for Android. Its latest listed release is old relative to current QEMU and Android, so it is a migration reference rather than the Cedroid base.

- <https://github.com/limboemu/limbo>

## Microsoft Device Emulator

The Device Emulator is valuable as a compatibility oracle for its S3C2410-oriented images, but its shared-source history and Windows/x86 design do not make it an appropriate Cedroid code base. Any use of SDK images remains subject to their original licenses.

## WCECL and SkyEye

WCECL explored API compatibility for a small set of x86 CE applications and is deprecated. SkyEye is an older full-system simulator with limited device coverage. Neither meets Cedroid's compatibility and maintenance goals.

## Conclusion

No maintained open-source project currently combines Cedroid's target guests, Android/Raspberry Pi hosts, ARM performance goals, and hardware-proxy requirements. Cedroid therefore uses QEMU for the execution substrate, independent .NET product code, and new board/guest integration work.
