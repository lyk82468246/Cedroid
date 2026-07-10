# ADR 0002: Isolate QEMU behind QMP and Cedroid protocols

- Status: accepted
- Date: 2026-07-10

## Context

Directly linking application logic to QEMU internals would spread native dependencies through the .NET codebase, complicate upgrades, and make native crashes fatal to the UI.

## Decision

On Linux and desktop hosts, run QEMU out of process and control it through QMP. Use VNC as the initial display transport, then replace it with a local shared-memory path. On Android, retain the protocol boundary while loading QEMU in a dedicated native service process.

## Consequences

- QEMU can be upgraded and debugged independently.
- The control plane is testable with scripted streams and fake backends.
- VNC adds acceptable MVP overhead but is not the final low-latency path.
- Some high-frequency guest services require a separate local binary protocol.
