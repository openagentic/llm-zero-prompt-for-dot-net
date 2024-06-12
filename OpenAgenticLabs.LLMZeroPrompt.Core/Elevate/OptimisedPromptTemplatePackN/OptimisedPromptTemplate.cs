

using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePackN;


public class OptimisedPromptTemplate
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("vendor")]
    public string Vendor { get; set; }

    [JsonProperty("createdBy")]
    public string CreatedBy { get; set; }

    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public string UpdatedDate { get; set; }

    [JsonProperty("updatedBy")]
    public string UpdatedBy { get; set; }

    [JsonProperty("targetTypes")]
    public OptimisedPromptTemplateTarget[] TargetTypes { get; set; }
}