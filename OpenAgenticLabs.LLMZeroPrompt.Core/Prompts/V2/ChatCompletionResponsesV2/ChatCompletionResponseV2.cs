

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;



public class ChatCompletionResponseV2(ChatCompletionResponsePayloadV2 payload) : IChatCompletionResponseV2
{

    public ChatCompletionResponsePayloadV2 Payload { get; init; } = payload;


}

