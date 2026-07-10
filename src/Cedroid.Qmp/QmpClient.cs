using System.Text;
using System.Text.Json;

namespace Cedroid.Qmp;

public sealed class QmpClient : IAsyncDisposable
{
    private static readonly JsonElement EmptyObject = JsonSerializer.SerializeToElement(new Dictionary<string, object?>());

    private readonly StreamReader reader;
    private readonly StreamWriter writer;
    private readonly Func<string> idFactory;
    private readonly SemaphoreSlim commandLock = new(1, 1);
    private bool disposed;

    public QmpClient(Stream duplexStream)
        : this(duplexStream, duplexStream)
    {
    }

    public QmpClient(Stream input, Stream output, Func<string>? idFactory = null)
    {
        ArgumentNullException.ThrowIfNull(input);
        ArgumentNullException.ThrowIfNull(output);

        reader = new StreamReader(input, new UTF8Encoding(false), leaveOpen: true);
        writer = new StreamWriter(output, new UTF8Encoding(false), leaveOpen: true)
        {
            AutoFlush = true,
            NewLine = "\n",
        };
        this.idFactory = idFactory ?? (() => Guid.NewGuid().ToString("N"));
    }

    public bool IsConnected { get; private set; }

    public QmpGreeting? Greeting { get; private set; }

    public event EventHandler<JsonElement>? EventReceived;

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        if (IsConnected)
        {
            return;
        }

        JsonElement greetingMessage = await ReadMessageAsync(cancellationToken).ConfigureAwait(false);
        Greeting = ParseGreeting(greetingMessage);
        _ = await ExecuteCoreAsync("qmp_capabilities", null, cancellationToken).ConfigureAwait(false);
        IsConnected = true;
    }

    public async Task<JsonElement> ExecuteAsync(
        string command,
        object? arguments = null,
        CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(command);
        if (!IsConnected)
        {
            throw new InvalidOperationException("The QMP capabilities negotiation has not completed.");
        }

        return await ExecuteCoreAsync(command, arguments, cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync()
    {
        if (disposed)
        {
            return;
        }

        disposed = true;
        IsConnected = false;
        commandLock.Dispose();
        await writer.DisposeAsync().ConfigureAwait(false);
        reader.Dispose();
    }

    private static QmpGreeting ParseGreeting(JsonElement message)
    {
        try
        {
            JsonElement qmp = message.GetProperty("QMP");
            JsonElement version = qmp.GetProperty("version");
            JsonElement qemu = version.GetProperty("qemu");
            string package = version.TryGetProperty("package", out JsonElement packageElement)
                ? packageElement.GetString() ?? string.Empty
                : string.Empty;

            return new QmpGreeting(
                qemu.GetProperty("major").GetInt32(),
                qemu.GetProperty("minor").GetInt32(),
                qemu.GetProperty("micro").GetInt32(),
                package);
        }
        catch (Exception exception) when (exception is KeyNotFoundException or InvalidOperationException)
        {
            throw new QmpException("The peer did not send a valid QMP greeting.", exception);
        }
    }

    private async Task<JsonElement> ExecuteCoreAsync(
        string command,
        object? arguments,
        CancellationToken cancellationToken)
    {
        await commandLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            string id = idFactory();
            var request = new Dictionary<string, object?>
            {
                ["execute"] = command,
                ["id"] = id,
            };

            if (arguments is not null)
            {
                request["arguments"] = arguments;
            }

            await writer.WriteLineAsync(JsonSerializer.Serialize(request).AsMemory(), cancellationToken).ConfigureAwait(false);

            while (true)
            {
                JsonElement response = await ReadMessageAsync(cancellationToken).ConfigureAwait(false);
                if (response.TryGetProperty("event", out _))
                {
                    EventReceived?.Invoke(this, response.Clone());
                    continue;
                }

                if (!response.TryGetProperty("id", out JsonElement responseId) || responseId.GetString() != id)
                {
                    continue;
                }

                if (response.TryGetProperty("error", out JsonElement error))
                {
                    throw new QmpCommandException(command, error);
                }

                return response.TryGetProperty("return", out JsonElement result)
                    ? result.Clone()
                    : EmptyObject.Clone();
            }
        }
        finally
        {
            commandLock.Release();
        }
    }

    private async Task<JsonElement> ReadMessageAsync(CancellationToken cancellationToken)
    {
        string? line = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false);
        if (line is null)
        {
            throw new EndOfStreamException("The QMP peer closed the connection.");
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(line);
            return document.RootElement.Clone();
        }
        catch (JsonException exception)
        {
            throw new QmpException("The QMP peer sent malformed JSON.", exception);
        }
    }
}
