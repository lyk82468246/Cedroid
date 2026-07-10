# Threat model

## Trust boundaries

Untrusted inputs include guest ROMs, disk images, guest memory, QMP/VNC traffic, CEBridge messages, file names and metadata, network packets, snapshots, and native emulator crashes.

## Assets

- Host files and credentials
- Microphone, camera, location, Bluetooth, and telephony permissions
- Local network access
- Integrity of VM instances and base images
- Availability of the host UI and operating system

## Required controls

- Run QEMU in a separate process where the platform permits it.
- Keep sensitive host APIs in a capability broker, not the emulator process.
- Validate every guest-provided offset, length, count, service, and opcode.
- Default to user-mode NAT with no inbound forwarding.
- Require explicit user selection for shared folders and removable media.
- Treat base images as read-only and write to overlays.
- Bound memory, CPU, queues, log growth, and snapshot sizes.
- Avoid shell command construction from instance metadata.
- Never expose unauthenticated QMP or VNC over a network interface.

## Out of scope

Cedroid cannot remediate vulnerabilities inside obsolete Windows CE/Windows Mobile systems or applications. Hardware pass-through and production multi-tenant isolation are not initial goals.
