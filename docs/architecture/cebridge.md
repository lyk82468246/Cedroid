# CEBridge architecture

CEBridge is the planned paravirtual host/guest protocol for rebuildable BSPs and optional guest additions.

## Transport

Version 1 is expected to use:

- a small MMIO configuration page;
- capability and protocol-version negotiation;
- bounded TX and RX descriptor rings in guest RAM;
- a doorbell register;
- interrupt delivery to the guest;
- explicit reset and cancellation semantics.

The QEMU device implements transport only. Host services are forwarded to the .NET capability broker over a local authenticated channel.

## Initial services

| ID | Service | First responsibility |
|---:|---|---|
| 1 | Display | Mode metadata and dirty rectangles |
| 2 | Input | Absolute pointer, touch, keys, wheel |
| 3 | Block | Paravirtual removable storage |
| 4 | Network | Ethernet-like packet transport |
| 5 | Audio | PCM playback and capture |
| 6 | Shared folder | Explicit host directory mount |
| 7 | WLAN | Semantic scan/connect proxy |
| 8 | Bluetooth | RFCOMM/GATT proxy, not raw HCI |
| 9 | Telephony | Call state and control, not cellular PCM |
| 10 | Location | Position and satellite metadata |

## Compatibility

- Unknown capability bits are ignored.
- Unknown service IDs are rejected without resetting the bus.
- Every message starts with size, service, opcode, flags, and request ID.
- Breaking wire changes require a new major protocol version.
- Service extensions use feature bits or new opcodes.
- All guest-provided lengths, offsets, and counts are validated before access.

The initial machine-readable sketch is `native/protocol/cebridge.schema.json`; it is not yet a frozen ABI.
