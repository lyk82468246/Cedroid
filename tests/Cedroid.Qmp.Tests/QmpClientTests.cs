using System.Text;

namespace Cedroid.Qmp.Tests;

public sealed class QmpClientTests
{
    [Fact]
    public async Task ConnectNegotiatesCapabilitiesAndExecutesCommand()
    {
        const string script = """
            {"QMP":{"version":{"qemu":{"major":10,"minor":2,"micro":4},"package":"cedroid"},"capabilities":[]}}
            {"return":{},"id":"id-1"}
            {"return":{"status":"running"},"id":"id-2"}
            """;

        await using var input = new MemoryStream(Encoding.UTF8.GetBytes(script));
        await using var output = new MemoryStream();
        Queue<string> ids = new(["id-1", "id-2"]);
        await using var client = new QmpClient(input, output, ids.Dequeue);

        CancellationToken cancellationToken = TestContext.Current.CancellationToken;
        await client.ConnectAsync(cancellationToken);
        System.Text.Json.JsonElement result = await client.ExecuteAsync("query-status", cancellationToken: cancellationToken);

        Assert.True(client.IsConnected);
        Assert.Equal(10, client.Greeting?.Major);
        Assert.Equal("running", result.GetProperty("status").GetString());

        string requests = Encoding.UTF8.GetString(output.ToArray());
        Assert.Contains("qmp_capabilities", requests, StringComparison.Ordinal);
        Assert.Contains("query-status", requests, StringComparison.Ordinal);
    }

    [Fact]
    public async Task ExecuteBeforeConnectIsRejected()
    {
        await using var stream = new MemoryStream();
        await using var client = new QmpClient(stream);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => client.ExecuteAsync("query-status", cancellationToken: TestContext.Current.CancellationToken));
    }
}
