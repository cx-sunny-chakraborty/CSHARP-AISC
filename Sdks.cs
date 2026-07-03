using System;
using System.ClientModel;
using OpenAI;
using OpenAI.Chat;
using Azure.AI.OpenAI;
using Anthropic.SDK;
using Anthropic.SDK.Messaging;

namespace AiCsharpSample;

public static class Sdks
{
    // openai
    public static string AskOpenAI(string prompt)
    {
        ChatClient client = new("gpt-4.1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        ChatCompletion completion = client.CompleteChat(prompt);
        return completion.Content[0].Text;
    }

    // azure openai
    public static ChatClient AzureClient()
    {
        var azure = new AzureOpenAIClient(
            new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")!),
            new ApiKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY")!));
        return azure.GetChatClient("gpt-4.1");
    }

    // anthropic
    public static async System.Threading.Tasks.Task<string> AskClaude(string prompt)
    {
        var client = new AnthropicClient(Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"));
        var parameters = new MessageParameters
        {
            Model = "claude-sonnet-4-5",
            MaxTokens = 256,
            Messages = new System.Collections.Generic.List<Message>
            {
                new Message(RoleType.User, prompt)
            }
        };
        var res = await client.Messages.GetClaudeMessageAsync(parameters);
        return res.Message.ToString();
    }
}
