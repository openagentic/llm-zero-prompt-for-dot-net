using Newtonsoft.Json;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents a target for an optimized prompt template.
/// </summary>
public class OptimisedPromptPackTarget
{
    /// <summary>
    /// Gets or sets the type of the target.
    /// </summary>
    [JsonProperty("targetType")]
    public string TargetType { get; set; }

    /// <summary>
    /// Gets or sets the input target type.
    /// </summary>
    [JsonProperty("inputTargetType")]
    public string InputTargetType { get; set; }

    /// <summary>
    /// Gets or sets the output target type.
    /// </summary>
    [JsonProperty("outputTargetType")]
    public string OutputTargetType { get; set; }

    /// <summary>
    /// Gets or sets the list of models for the target.
    /// </summary>
    [JsonProperty("models")]
    public List<OptimisedPromptPackModel> Models { get; set; }
}
