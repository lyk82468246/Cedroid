using Cedroid.Contracts;
using Cedroid.Core;

namespace Cedroid.Core.Tests;

public sealed class VirtualMachineInstanceTests
{
    private static readonly MachineProfile Profile = MachineProfile.Create(
        "devemu-wm6",
        "Device Emulator / Windows Mobile 6",
        GuestArchitecture.ArmV4,
        GuestOperatingSystem.WindowsMobile6,
        128,
        "roms/wm6.bin");

    [Fact]
    public void ValidLifecycleTransitionsReachRunning()
    {
        var instance = new VirtualMachineInstance("test", Profile);

        instance.TransitionTo(VirtualMachineState.Starting);
        instance.TransitionTo(VirtualMachineState.Running);

        Assert.Equal(VirtualMachineState.Running, instance.State);
    }

    [Fact]
    public void InvalidTransitionIsRejected()
    {
        var instance = new VirtualMachineInstance("test", Profile);

        InvalidStateTransitionException exception = Assert.Throws<InvalidStateTransitionException>(
            () => instance.TransitionTo(VirtualMachineState.Paused));

        Assert.Equal(VirtualMachineState.Stopped, exception.Current);
        Assert.Equal(VirtualMachineState.Paused, exception.Requested);
    }
}
