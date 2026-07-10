# Architecture overview

## System shape

Cedroid separates a managed control plane from a native emulator data plane.

```text
┌──────────────────────────────────────────────────────────┐
│ Avalonia application / CLI                              │
│ instance library · settings · permissions · diagnostics │
├──────────────────────────────────────────────────────────┤
│ Cedroid application services                            │
│ lifecycle · manifests · snapshots · capability policy   │
├──────────────────────────────────────────────────────────┤
│ QMP + display/input transport + CEBridge host services  │
├──────────────────────────────────────────────────────────┤
│ QEMU                                                     │
│ TCG/KVM · machine models · memory · block · networking   │
├──────────────────────────────────────────────────────────┤
│ Windows CE / Windows Mobile                             │
│ stock BSP drivers or versioned Cedroid guest additions  │
└──────────────────────────────────────────────────────────┘
```

## Control plane

The control plane is C# and targets .NET 10. It owns product state rather than emulation state:

- VM definitions and lifecycle;
- image import and overlays;
- QMP negotiation and commands;
- user permissions and host capabilities;
- display/input presentation;
- logging, crash reporting, and diagnostics.

It must remain usable with different QEMU builds and must not include QEMU headers.

## Emulator data plane

QEMU supplies full-system ARM emulation, TCG, optional KVM, device infrastructure, block formats, networking, and migration primitives. Cedroid-owned native changes are maintained as a small patch series until their upstream strategy is settled.

Two machine families are planned:

1. `cedroid-devemu`: compatibility with Microsoft Device Emulator/S3C2410-oriented ROMs. Accuracy is more important than acceleration.
2. `cevirt`: a versioned virtual board for rebuildable CE BSPs. It exposes CEBridge and is the preferred acceleration/integration target.

## Host topology

### Linux and Raspberry Pi

QEMU runs as a child process. The UI communicates through Unix-domain sockets. Process isolation, ordinary package deployment, and debugging make this the first host target.

### Android

Android cannot rely on executing a file unpacked into writable app storage. The intended layout is a native library loaded by a dedicated .NET Android service process, with QMP retained as the control boundary. Sensitive Android APIs remain in a managed capability broker.

## Data ownership

- Base ROMs are read-only and user supplied.
- Mutable storage uses overlays.
- Instance state is separate from application settings.
- Protocol schemas are versioned and checked into `native/protocol`.
- Proprietary images never enter source control, test artifacts, or CI caches.
