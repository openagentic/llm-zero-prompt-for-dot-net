using Newtonsoft.Json;



namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;


public class ChatCompletionResponseMessageToolCallFunctionV2 
{

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("arguments")]
    public string arguments  { get; set; }

}

