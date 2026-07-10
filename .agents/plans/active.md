# Active plan

Last updated: 2026-07-10

## Current milestone: M0 repository foundation

Status: in progress

### Exit criteria

- [x] .NET 10 solution and central package management
- [x] Avalonia application shell
- [x] VM lifecycle domain model
- [x] QMP client foundation
- [x] Platform capability abstractions
- [x] Initial unit tests
- [x] Agent context and planning structure
- [ ] Clean GitHub Actions build and test
- [ ] Initial repository pushed to GitHub

## Next milestone: M1 QEMU smoke host

- Launch an externally supplied QEMU executable on Raspberry Pi/Linux.
- Connect through a Unix-domain QMP socket.
- Display a low-resolution guest through an initial VNC transport.
- Forward pointer and keyboard input.
- Prove stop, reset, pause, resume, and snapshot flows.
- Do not implement Windows CE hardware until this host/control path is reliable.
