

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;




public class ChatCompletionResponseMessageV2 
{

    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("tool_calls")]
    public List<ChatCompletionResponseMessageToolCallV2>? ToolCalls { get; set; }

    [JsonProperty("role")]
    public string Role { get; set; }

  

}

