using System.Text.Json;
using Cedroid.Core;

var output = new
{
    product = CedroidBuildInfo.ProductName,
    stage = CedroidBuildInfo.Stage,
    architecture = CedroidBuildInfo.Architecture,
    command = args.Length == 0 ? "about" : args[0],
};

if (args.Contains("--json", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine(JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = true }));
    return;
}

Console.WriteLine($"{output.product} — {output.stage}");
Console.WriteLine(output.architecture);
Console.WriteLine("No emulator backend is bundled yet. See docs/roadmap.md.");
