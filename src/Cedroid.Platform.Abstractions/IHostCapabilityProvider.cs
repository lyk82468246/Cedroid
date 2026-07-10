namespace Cedroid.Platform.Abstractions;

public interface IHostCapabilityProvider
{
    ValueTask<IReadOnlyList<HostCapabilityStatus>> GetStatusAsync(CancellationToken cancellationToken = default);
}
