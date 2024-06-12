

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;



public class ChatCompletionResponsePayloadV2
{

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("choices")]
    public List<ChatCompletionResponseChoiceV2> Choices { get; set; }

    [JsonProperty("created")]
    public long? Created { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("system_fingerprint")]
    public string SystemFingerprint { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("usage")]
    public ChatCompletionResponseUsageV2 Usage { get; set; }

}
