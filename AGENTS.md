# Cedroid agent instructions

These instructions apply to the entire repository.

## Mission

Build a maintainable, evidence-driven Windows CE and Windows Mobile virtualization framework with a .NET-first control plane and a narrowly contained native data plane.

## User constraints

- Do not install software, SDKs, workloads, IDEs, system packages, or toolchains.
- Do not modify the user's system environment or PATH.
- If a required tool is unavailable, perform static validation, configure CI, and report the missing local verification.
- The preferred product stack is C#/.NET. Avoid C++.
- Native code is allowed only where QEMU or Windows CE kernel drivers require it; prefer C and keep the boundary small.

## Architectural invariants

- The .NET control plane must not include QEMU headers or depend on QEMU internals.
- QEMU is controlled through QMP and versioned Cedroid protocols.
- Platform capabilities are accessed through `Cedroid.Platform.Abstractions`.
- Guest-provided data and native emulator output are untrusted.
- Do not commit proprietary ROMs, firmware, CAB files, SDK content, BSP content, or extracted Microsoft binaries.
- A placeholder must never claim that a guest boots or a device works.

## Repository workflow

1. Read `.agents/context/project.md` and `.agents/plans/active.md` before material work.
2. Update `.agents/plans/active.md` when starting or completing a milestone-sized task.
3. Record lasting architecture decisions as ADRs under `docs/adr/`.
4. Put temporary handoff notes under `.agents/handoffs/`; do not use them as permanent documentation.
5. Keep native patches isolated under `native/` and document their upstream base.

## Quality gates

When a .NET 10 SDK is already available:

```text
dotnet restore Cedroid.slnx
dotnet build Cedroid.slnx --no-restore --configuration Release
dotnet test Cedroid.slnx --no-build --configuration Release
dotnet format Cedroid.slnx --verify-no-changes --no-restore
```

Do not install the SDK when it is absent. GitHub Actions is the authoritative clean-environment gate.

## Change discipline

- Prefer focused projects and explicit interfaces over generalized frameworks.
- Public contracts require tests and compatibility notes.
- Protocol changes require a versioning decision and schema update.
- Treat warnings as errors.
- Keep documentation factual and distinguish implemented, experimental, and planned behavior.
- Do not spawn subagents unless the user explicitly requests delegation or parallel agent work.
