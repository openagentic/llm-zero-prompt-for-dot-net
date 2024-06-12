using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePackN;



/// <summary>
/// Represents a collection of optimized prompt templates.
/// </summary>
[JsonObject]
public class OptimisedPromptTemplatePackTemplatePack
{
    /// <summary>
    /// Gets or sets the list of optimized prompt templates.
    /// </summary>
    [JsonProperty("optimizedPromptTemplates")]
    public OptimisedPromptTemplate[] OptimizedPromptTemplates { get; set; }

    /// <summary>
    /// Parses the specified JSON string into an instance of <see cref="OptimisedPromptTemplatePackTemplates"/>.
    /// </summary>
    /// <param name="jsonString">The JSON string to parse.</param>
    /// <returns>An instance of <see cref="OptimisedPromptTemplatePackTemplates"/> parsed from the JSON string.</returns>
    public OptimisedPromptTemplatePackTemplatePack Parse(string jsonString)
    {
        return JsonConvert.DeserializeObject<OptimisedPromptTemplatePackTemplatePack>(jsonString);
    }

    /// <summary>
    /// Loads an instance of <see cref="OptimisedPromptTemplatePackTemplates"/> from a JSON file.
    /// </summary>
    /// <param name="filePath">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="OptimisedPromptTemplatePackTemplates"/> loaded from the JSON file.</returns>
    public static OptimisedPromptTemplatePackTemplatePack LoadFromFile(string filePath)
    {
        string jsonFromFile = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<OptimisedPromptTemplatePackTemplatePack>(jsonFromFile);
    }
}