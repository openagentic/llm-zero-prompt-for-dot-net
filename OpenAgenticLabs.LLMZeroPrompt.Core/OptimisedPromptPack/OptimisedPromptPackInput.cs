using Newtonsoft.Json;



namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents an input for a model.
/// </summary>
public class OptimisedPromptPackInput
{
    /// <summary>
    /// Gets or sets the type of the input.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the tag of the input.
    /// </summary>
    [JsonProperty("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// Gets or sets the description of the input.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the format of the input.
    /// </summary>
    [JsonProperty("format")]
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of characters for the input.
    /// </summary>
    [JsonProperty("maxChar")]
    public int MaxChar { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of characters for the input.
    /// </summary>
    [JsonProperty("minChar")]
    public int MinChar { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of words for the input.
    /// </summary>
    [JsonProperty("minWords")]
    public int MinWords { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of words for the input.
    /// </summary>
    [JsonProperty("maxWords")]
    public int MaxWords { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input should be in all uppercase.
    /// </summary>
    [JsonProperty("allUperCase")]
    public bool AllUpperCase { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input should be in all lowercase.
    /// </summary>
    [JsonProperty("allLowerCase")]
    public bool AllLowerCase { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the input should end with a full stop.
    /// </summary>
    [JsonProperty("endWitFullStop")]
    public bool EndWithFullStop { get; set; }
}
