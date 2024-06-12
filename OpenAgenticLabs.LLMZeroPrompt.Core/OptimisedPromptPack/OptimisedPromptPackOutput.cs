using Newtonsoft.Json;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;

public class OptimisedPromptPackOutput
{
    /// <summary>
    /// Gets or sets the type of the output.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the tag of the output.
    /// </summary>
    [JsonProperty("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// Gets or sets the description of the output.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the format of the output.
    /// </summary>
    [JsonProperty("format")]
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of characters for the output.
    /// </summary>
    [JsonProperty("maxChar")]
    public int MaxChar { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of characters for the output.
    /// </summary>
    [JsonProperty("minChar")]
    public int MinChar { get; set; }

    /// <summary>
    /// Gets or sets the minimum number of words for the output.
    /// </summary>
    [JsonProperty("minWords")]
    public int MinWords { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of words for the output.
    /// </summary>
    [JsonProperty("maxWords")]
    public int MaxWords { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the output should be in all uppercase.
    /// </summary>
    [JsonProperty("allUperCase")]
    public bool AllUpperCase { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the output should be in all lowercase.
    /// </summary>
    [JsonProperty("allLowerCase")]
    public bool AllLowerCase { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the output should end with a full stop.
    /// </summary>
    [JsonProperty("endWitFullStop")]
    public bool EndWithFullStop { get; set; }
}
