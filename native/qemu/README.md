# QEMU integration

No QEMU source or binary is currently bundled.

The first integration milestone uses an externally installed QEMU process and QMP. Later work will maintain a small patch series for:

- `cedroid-devemu` board and required S3C2410 devices;
- `cevirt` board/device transport;
- local framebuffer and CEBridge host channels;
- Android library entry and lifecycle glue.

Every patch must record its upstream base commit and supporting hardware/BSP evidence.
