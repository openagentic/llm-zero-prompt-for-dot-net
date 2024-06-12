

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;




public class ChatCompletionResponseChoiceV2 
{


    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }

    [JsonProperty("index")]
    public int? Index { get; set; }

    [JsonProperty("message")]
    public ChatCompletionResponseMessageV2 Message { get; set; }

    [JsonProperty("logprobs")]
    public ChatCompletionResponseLogprobsV2? Logprobs { get; set; }


}

