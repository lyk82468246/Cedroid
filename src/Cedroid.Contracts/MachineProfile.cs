namespace Cedroid.Contracts;

public sealed record MachineProfile(
    string Id,
    string DisplayName,
    GuestArchitecture Architecture,
    GuestOperatingSystem OperatingSystem,
    int MemoryMiB,
    string RomPath)
{
    public static MachineProfile Create(
        string id,
        string displayName,
        GuestArchitecture architecture,
        GuestOperatingSystem operatingSystem,
        int memoryMiB,
        string romPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(displayName);
        ArgumentException.ThrowIfNullOrWhiteSpace(romPath);
        ArgumentOutOfRangeException.ThrowIfLessThan(memoryMiB, 16);

        return new MachineProfile(
            id.Trim(),
            displayName.Trim(),
            architecture,
            operatingSystem,
            memoryMiB,
            romPath);
    }
}
