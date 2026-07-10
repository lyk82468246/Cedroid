using Cedroid.Contracts;

namespace Cedroid.Core;

public sealed class InvalidStateTransitionException : InvalidOperationException
{
    public InvalidStateTransitionException()
        : this(VirtualMachineState.Stopped, VirtualMachineState.Stopped)
    {
    }

    public InvalidStateTransitionException(string message)
        : base(message)
    {
    }

    public InvalidStateTransitionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidStateTransitionException(VirtualMachineState current, VirtualMachineState requested)
        : base($"Cannot transition a Cedroid virtual machine from {current} to {requested}.")
    {
        Current = current;
        Requested = requested;
    }

    public VirtualMachineState Current { get; }

    public VirtualMachineState Requested { get; }
}
