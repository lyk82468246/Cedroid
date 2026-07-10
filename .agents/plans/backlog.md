# Prioritized backlog

## P0 — foundation

- CI green on Linux and Windows.
- QMP command correlation, event routing, timeouts, and disconnect handling.
- Instance manifest schema and validation.
- QEMU process supervisor for Linux.
- VNC framebuffer proof of concept.

## P1 — first Windows CE boot

- Choose legally available development image and matching board target.
- Create the S3C2410/Device Emulator compatibility-machine plan.
- Add trace-based differential testing against a known-good emulator.
- Implement interrupt controller, timer, UART, RAM map, and display in that order.

## P2 — CEBridge and cevirt

- Freeze CEBridge v1 transport.
- Implement `cevirt` QEMU transport device.
- Build version-specific guest driver plans for CE5, CE6, WEC7, and WEC2013.
- Add framebuffer, input, block, network, and audio services.

## P3 — host integrations

- Linux: PipeWire/ALSA, NetworkManager, BlueZ, ModemManager, libinput.
- Android: Surface, AAudio, ConnectivityManager, Bluetooth APIs, Telecom.
- Security broker and capability permission model.

## P4 — performance

- Profile TCG before custom optimization.
- Evaluate KVM only on supported controlled hardware.
- Add shared-memory framebuffer and 2D command acceleration.
