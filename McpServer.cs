using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

namespace AiCsharpSample;

// MCP server
public static class McpServerDemo
{
    public static void Start(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services
            .AddMcpServer()
            .WithStdioServerTransport()
            .WithToolsFromAssembly();
        builder.Build().Run();
    }
}

[McpServerToolType]
public static class WeatherTool
{
    [McpServerTool, Description("get weather for a city")]
    public static string GetWeather(string city) => $"{city}: sunny";
}
