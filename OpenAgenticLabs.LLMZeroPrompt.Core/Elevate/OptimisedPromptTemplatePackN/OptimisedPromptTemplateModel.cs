

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePackN;

public class OptimisedPromptTemplateModel
{
    [JsonProperty("modelName")]
    public string ModelName { get; set; }

    [JsonProperty("tempature")]
    public double Temperature { get; set; }

    [JsonProperty("ptop")]
    public int PTop { get; set; }

    [JsonProperty("promptTemplate")]
    public string PromptTemplate { get; set; }
}
