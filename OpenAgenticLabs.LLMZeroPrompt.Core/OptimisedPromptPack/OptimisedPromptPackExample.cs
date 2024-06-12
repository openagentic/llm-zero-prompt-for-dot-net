using Newtonsoft.Json;



namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents an example for a model.
/// </summary>
public class OptimisedPromptPackExample
{
    /// <summary>
    /// Gets or sets the example data.
    /// </summary>
    [JsonProperty("example")]
    public string Example { get; set; }
}
