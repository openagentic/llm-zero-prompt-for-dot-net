

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;




public class ChatCompletionResponseUsageV2 
{

    [JsonProperty("completion_tokens")]
    public int? PromptTokens { get; set; }


    [JsonProperty("prompt_tokens")]
    public int? CompletionTokens { get; set; }


    [JsonProperty("total_tokens")]
    public int? TotalTokens { get; set; }

}

