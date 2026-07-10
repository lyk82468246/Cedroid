namespace Cedroid.Qmp;

public sealed record QmpGreeting(
    int Major,
    int Minor,
    int Micro,
    string Package);
