# Cedroid agent workspace

This directory keeps durable context for programming agents without mixing it into product code.

- `context/` describes the project and its non-negotiable constraints.
- `plans/` contains the active execution plan and prioritized backlog.
- `roles/` defines review perspectives, not autonomous background processes.
- `handoffs/` contains short-lived continuation notes.

Permanent design knowledge belongs in `docs/`; code truth belongs in `src/`, `native/`, and tests.
