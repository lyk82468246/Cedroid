# Cedroid roadmap

Roadmap dates are deliberately omitted until the first QEMU smoke host is measured. Milestones are gated by observable outcomes.

## M0 — repository foundation

- .NET 10/Avalonia solution and CI.
- VM lifecycle state machine.
- QMP client foundation.
- Platform capability contracts.
- Agent, architecture, security, and contribution documentation.

## M1 — Raspberry Pi/Linux smoke host

- Supervise an externally installed QEMU process.
- QMP handshake, events, lifecycle, reset, pause, and shutdown.
- Initial VNC framebuffer and input forwarding.
- Overlay disk and snapshot workflow.
- Run a redistributable ARM test guest; Windows CE is not required for this gate.

## M2 — first Windows CE boot

- Select one legally obtained image and matching board/BSP.
- Implement only the devices required to reach serial output, then display.
- Capture deterministic boot traces.
- Boot to a stable shell or desktop repeatedly.
- Add touch and persistent storage.

## M3 — Device Emulator compatibility

- S3C2410-oriented machine profile.
- CE5/CE6 and WM5/WM6/WM6.5 compatibility matrix.
- Audio and NAT networking.
- ROM-container importer based on formats that can be documented legally.

## M4 — cevirt and CEBridge

- Freeze CEBridge transport v1.
- Rebuildable BSP for one CE generation.
- Display, input, block, network, audio, and shared-folder guest drivers.
- Extend to CE5, CE6, WEC7, and WEC2013 with version-specific driver projects.

## M5 — Android host

- Build QEMU as an APK native library without runtime code download.
- Dedicated VM service process.
- Avalonia Android UI and shared instance model.
- Surface/input/audio integration.
- Capability broker for networking, Bluetooth, WLAN, and Telecom.

## M6 — acceleration and hardening

- Shared-memory or zero-copy framebuffer.
- 2D blit acceleration and frame pacing.
- Conditional KVM for controlled compatible devices.
- Fuzz protocol parsers and image importers.
- Sandboxing, resource limits, and recovery from native crashes.
