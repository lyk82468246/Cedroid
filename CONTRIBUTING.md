# Contributing to Cedroid

Cedroid is pre-alpha. Early contributions should make the architecture more testable and the emulator behavior more evidence-based.

## Before coding

1. Read `AGENTS.md`, `docs/architecture/overview.md`, and relevant ADRs.
2. Check `docs/roadmap.md` and `.agents/plans/active.md`.
3. Open an issue before adding a new machine, public protocol, or platform dependency.

## Development

- Use a preinstalled .NET 10 SDK. Repository scripts never install dependencies.
- Keep changes focused and include tests.
- Use conventional commit subjects where practical: `feat:`, `fix:`, `docs:`, `test:`, `build:`, `chore:`.
- Do not commit ROMs or proprietary SDK/BSP content.
- Do not add C++ to Cedroid-owned code. Native QEMU and guest-driver work should use C.

## Pull requests

Describe what changed, why, how it was verified, supported hosts/guests, protocol compatibility impact, and remaining limitations. A green CI run is required before merge.

## Native contributions

Native changes must state the upstream QEMU base commit, data-sheet or BSP evidence, test image provenance, and differential trace used for validation. Keep patches suitable for upstream submission when possible.
