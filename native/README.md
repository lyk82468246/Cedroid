# Native boundary

This directory is intentionally small. It will contain Cedroid-owned C code and patch metadata required for QEMU and Windows CE guests.

- `qemu/` documents the upstream integration and patch series.
- `guest/` documents version-specific CEBridge guest drivers.
- `protocol/` contains machine-readable protocol sketches.

Do not vendor a QEMU source tree here. Use a pinned submodule or reproducible fetch/patch workflow only after an ADR records the exact strategy.
