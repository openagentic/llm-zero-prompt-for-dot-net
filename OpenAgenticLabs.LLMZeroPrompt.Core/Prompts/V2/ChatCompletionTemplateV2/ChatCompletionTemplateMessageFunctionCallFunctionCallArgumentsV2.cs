
using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;

public class ChatCompletionTemplateMessageFunctionCallFunctionCallArgumentsV2
{
    [JsonProperty("tool_name")]
    public string ToolName { get; set; }

    [JsonProperty("arguments")]
    public ChatCompletionTemplateMessageFunctionCallFunctionCallArgumentsDetailV2 Arguments { get; set; }
}


