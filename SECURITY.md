# Security policy

Cedroid is pre-alpha and is not suitable for production, safety-critical, or Internet-exposed workloads.

## Reporting

Please report vulnerabilities privately through GitHub Security Advisories for this repository. Do not publish exploit details before a fix or mitigation is available.

## Scope

Security-sensitive areas include QMP/VNC parsing, ROM and image import, native QEMU integration, CEBridge messages, shared folders, network forwarding, Android/Linux capability brokers, and guest-triggered host operations.

Windows CE and Windows Mobile are obsolete systems. Running them does not make them secure. Cedroid will default to NAT with no inbound forwarding and will isolate emulator processes where the host permits it.
