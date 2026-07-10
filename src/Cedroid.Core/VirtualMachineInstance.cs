using Cedroid.Contracts;

namespace Cedroid.Core;

public sealed class VirtualMachineInstance
{
    private static readonly IReadOnlyDictionary<VirtualMachineState, HashSet<VirtualMachineState>> AllowedTransitions =
        new Dictionary<VirtualMachineState, HashSet<VirtualMachineState>>
        {
            [VirtualMachineState.Stopped] = [VirtualMachineState.Starting],
            [VirtualMachineState.Starting] = [VirtualMachineState.Running, VirtualMachineState.Faulted, VirtualMachineState.Stopping],
            [VirtualMachineState.Running] = [VirtualMachineState.Paused, VirtualMachineState.Stopping, VirtualMachineState.Faulted],
            [VirtualMachineState.Paused] = [VirtualMachineState.Running, VirtualMachineState.Stopping, VirtualMachineState.Faulted],
            [VirtualMachineState.Stopping] = [VirtualMachineState.Stopped, VirtualMachineState.Faulted],
            [VirtualMachineState.Faulted] = [VirtualMachineState.Stopped, VirtualMachineState.Starting],
        };

    public VirtualMachineInstance(string id, MachineProfile profile)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(profile);

        Id = id.Trim();
        Profile = profile;
    }

    public string Id { get; }

    public MachineProfile Profile { get; }

    public VirtualMachineState State { get; private set; } = VirtualMachineState.Stopped;

    public event EventHandler<VirtualMachineState>? StateChanged;

    public bool CanTransitionTo(VirtualMachineState requested) =>
        AllowedTransitions[State].Contains(requested);

    public void TransitionTo(VirtualMachineState requested)
    {
        if (!CanTransitionTo(requested))
        {
            throw new InvalidStateTransitionException(State, requested);
        }

        State = requested;
        StateChanged?.Invoke(this, requested);
    }
}
