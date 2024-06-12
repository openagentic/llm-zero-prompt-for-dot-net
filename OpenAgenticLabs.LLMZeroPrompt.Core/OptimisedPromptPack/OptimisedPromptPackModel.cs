using Newtonsoft.Json;



namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents a model for a target.
/// </summary>
public class OptimisedPromptPackModel
{
    /// <summary>
    /// Gets or sets the vendor name of the model.
    /// </summary>
    [JsonProperty("modelVendorName")]
    public string ModelVendorName { get; set; }

    /// <summary>
    /// Gets or sets the family of the model.
    /// </summary>
    [JsonProperty("modelFamily")]
    public string ModelFamily { get; set; }

    /// <summary>
    /// Gets or sets the name of the model.
    /// </summary>
    [JsonProperty("modelName")]
    public string ModelName { get; set; }

    /// <summary>
    /// Gets or sets the temperature of the model.
    /// </summary>
    [JsonProperty("tempature")]
    public double Temperature { get; set; }

    /// <summary>
    /// Gets or sets the ptop value of the model.
    /// </summary>
    [JsonProperty("ptop")]
    public int Ptop { get; set; }

    /// <summary>
    /// Gets or sets the list of inputs for the model.
    /// </summary>
    [JsonProperty("Input")]
    public List<OptimisedPromptPackInput> Inputs { get; set; }

    /// <summary>
    /// Gets or sets the list of outputs for the model.
    /// </summary>
    [JsonProperty("Output")]
    public List<OptimisedPromptPackOutput> Outputs { get; set; }

    /// <summary>
    /// Gets or sets the context of the model.
    /// </summary>
    [JsonProperty("context")]
    public string Context { get; set; }

    /// <summary>
    /// Gets or sets the list of examples for the model.
    /// </summary>
    [JsonProperty("examples")]
    public List<OptimisedPromptPackExample> Examples { get; set; }

    /// <summary>
    /// Gets or sets the prompt template of the model.
    /// </summary>
    [JsonProperty("promptTemplate")]
    public string PromptTemplate { get; set; }
}
