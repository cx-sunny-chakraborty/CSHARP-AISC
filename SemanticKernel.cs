using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace AiCsharpSample;

// Semantic Kernel - native to .NET. This is the retest of the Python SK miss.
public static class SkDemo
{
    public static Kernel BuildKernel()
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(
            modelId: "gpt-4.1",
            apiKey: System.Environment.GetEnvironmentVariable("OPENAI_API_KEY")!);
        return builder.Build();
    }

    public static async System.Threading.Tasks.Task<string> Ask(string prompt)
    {
        var kernel = BuildKernel();
        var chat = kernel.GetRequiredService<IChatCompletionService>();
        var history = new ChatHistory();
        history.AddUserMessage(prompt);
        var result = await chat.GetChatMessageContentAsync(history);
        return result.Content ?? string.Empty;
    }
}
