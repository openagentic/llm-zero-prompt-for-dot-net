using Newtonsoft.Json;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents an optimized prompt template.
/// </summary>
public class OptimizedPromptPackItem
{
    /// <summary>
    /// Gets or sets the name of the optimized prompt template.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the optimized prompt template.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the owner of the optimized prompt template.
    /// </summary>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or sets the version of the optimized prompt template.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets the vendor of the optimized prompt template.
    /// </summary>
    [JsonProperty("vendor")]
    public string Vendor { get; set; }

    /// <summary>
    /// Gets or sets the creator of the optimized prompt template.
    /// </summary>
    [JsonProperty("createdBy")]
    public string CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the optimized prompt template.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the update date of the optimized prompt template.
    /// </summary>
    [JsonProperty("updatedDate")]
    public string UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets the updater of the optimized prompt template.
    /// </summary>
    [JsonProperty("updatedBy")]
    public string UpdatedBy { get; set; }

    ///// <summary>
    ///// Gets or sets the list of targets for the optimized prompt template.
    ///// </summary>
    [JsonProperty("targets")]
    public List<OptimisedPromptPackTarget> Targets { get; set; }
}
