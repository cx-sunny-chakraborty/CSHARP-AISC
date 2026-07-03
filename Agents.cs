using AutoGen.Core;
using AutoGen.OpenAI;

namespace AiCsharpSample;

// AutoGen for .NET
public static class Agents
{
    public static IAgent BuildAgent()
    {
        var openAIClient = new global::OpenAI.OpenAIClient(
            System.Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        var agent = new OpenAIChatAgent(
            chatClient: openAIClient.GetChatClient("gpt-4.1"),
            name: "assistant",
            systemMessage: "You are a helpful assistant.")
            .RegisterMessageConnector();

        return agent;
    }
}
