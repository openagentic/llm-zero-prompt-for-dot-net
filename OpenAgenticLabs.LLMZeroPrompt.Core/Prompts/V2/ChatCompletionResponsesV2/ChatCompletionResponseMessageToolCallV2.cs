

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;




public class ChatCompletionResponseMessageToolCallV2 
{

    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("function")]
    public ChatCompletionResponseMessageToolCallFunctionV2? Function { get; set; }

}

