using Cedroid.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Cedroid.App.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    public string ProductName => CedroidBuildInfo.ProductName;

    public string Stage => CedroidBuildInfo.Stage;

    public string Architecture => CedroidBuildInfo.Architecture;

    public IReadOnlyList<FoundationItem> FoundationItems { get; } =
    [
        new("Control plane", "Avalonia 12 / .NET 10", true),
        new("VM lifecycle", "Validated state machine", true),
        new("QMP transport", "Async JSON protocol client", true),
        new("QEMU backend", "Planned native integration", false),
        new("Windows CE boot", "Planned compatibility milestone", false),
    ];
}

public sealed record FoundationItem(string Name, string Detail, bool Ready);
