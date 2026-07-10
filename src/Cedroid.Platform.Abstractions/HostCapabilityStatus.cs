namespace Cedroid.Platform.Abstractions;

public sealed record HostCapabilityStatus(
    HostCapability Capability,
    bool IsAvailable,
    bool RequiresPermission,
    string? Detail = null);
