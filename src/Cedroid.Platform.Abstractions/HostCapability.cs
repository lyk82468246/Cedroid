namespace Cedroid.Platform.Abstractions;

[Flags]
public enum HostCapability
{
    None = 0,
    Display = 1 << 0,
    Touch = 1 << 1,
    Keyboard = 1 << 2,
    AudioOutput = 1 << 3,
    AudioInput = 1 << 4,
    Network = 1 << 5,
    WirelessLan = 1 << 6,
    Bluetooth = 1 << 7,
    TelephonyControl = 1 << 8,
    Location = 1 << 9,
    Sensors = 1 << 10,
}
