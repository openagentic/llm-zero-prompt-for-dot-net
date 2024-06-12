
using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;

public class ChatCompletionTemplateMessageFunctionCallV2
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("arguments")]
    public ChatCompletionTemplateMessageFunctionCallFunctionCallArgumentsV2 Arguments { get; set; }

}

