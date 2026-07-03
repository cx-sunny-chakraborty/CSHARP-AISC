using System;
using System.Threading.Tasks;

namespace AiCsharpSample;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine(Sdks.AskOpenAI("hello"));
        Console.WriteLine(await SkDemo.Ask("hello"));
        Console.WriteLine(await McpClientDemo.CallTool());
    }
}
