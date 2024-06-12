

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;

public class ChatCompletionTemplateMessageFunctionCallFunctionCallArgumentsDetailV2
{
    [JsonProperty("coworker")]
    public string Coworker { get; set; }

    [JsonProperty("ikTask")]
    public string Task { get; set; }

    [JsonProperty("context")]
    public string Context { get; set; }


}

