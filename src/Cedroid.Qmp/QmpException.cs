using System.Text.Json;

namespace Cedroid.Qmp;

public class QmpException : Exception
{
    public QmpException()
    {
    }

    public QmpException(string message)
        : base(message)
    {
    }

    public QmpException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

internal sealed class QmpCommandException : QmpException
{
    public QmpCommandException(string command, JsonElement error)
        : base($"QMP command '{command}' failed: {error.GetRawText()}")
    {
        Command = command;
        Error = error.Clone();
    }

    public string Command { get; }

    public JsonElement Error { get; }
}
