using System.Collections.Generic;
using System.Threading.Tasks;
using ModelContextProtocol.Client;

namespace AiCsharpSample;

// MCP client
public static class McpClientDemo
{
    public static async Task<string> CallTool()
    {
        var transport = new StdioClientTransport(new StdioClientTransportOptions
        {
            Name = "demo-server",
            Command = "dotnet",
            Arguments = new[] { "run" }
        });

        var client = await McpClientFactory.CreateAsync(transport);

        var tools = await client.ListToolsAsync();
        var result = await client.CallToolAsync(
            "GetWeather",
            new Dictionary<string, object?> { ["city"] = "Pune" });

        return result.Content[0].Text ?? string.Empty;
    }
}
