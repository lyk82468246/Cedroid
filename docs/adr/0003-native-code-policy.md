# ADR 0003: Minimize native code and prohibit new C++

- Status: accepted
- Date: 2026-07-10

## Context

The project maintainer strongly prefers .NET and does not want a C++ product codebase. Full-system emulation and Windows CE kernel drivers nevertheless require native integration.

## Decision

Cedroid-owned product logic is C#. Native code is limited to QEMU machine/device patches, tiny host entry shims, and Windows CE drivers. New Cedroid native code uses C, not C++. High-level hardware behavior belongs in managed platform brokers when latency and correctness allow it.

## Consequences

- Native review can focus on a small, security-sensitive boundary.
- QEMU remains viable because it is predominantly C.
- CERF cannot be adopted as the main implementation because its current architecture is C++/Win32/x86-specific.
- Guest-driver work may require external contributors with Windows CE C experience.
