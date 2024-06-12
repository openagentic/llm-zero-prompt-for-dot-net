using Newtonsoft.Json;
using System.Reflection;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;



/// <summary>
/// Represents a collection of optimized prompt templates.
/// </summary>
public class OptimizedPromptPackItems
{
    /// <summary>
    /// Gets or sets the list of optimized prompt templates.
    /// </summary>
    [JsonProperty("optimizedPromptPackItem")]
    public List<OptimizedPromptPackItem> OptimizedPromptPackItem { get; set; }



    /// <summary>
    /// Reads the optimized prompt templates from an embedded resource.
    /// </summary>
    /// <param name="resourceName">The name of the embedded resource.</param>
    /// <returns>An <see cref="OperationResult{TR,TF,TE}"/> containing the loaded optimized prompt templates.</returns>
    public static OperationResult<OptimizedPromptPackItems, string, string> ReadFromEmbeddedResource(Assembly assembly, string resourceName)
    {
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                return OperationResult<OptimizedPromptPackItems, string, string>.Failure($"Embedded resource '{resourceName}' not found.");
            }

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var optimizedPromptPackItems = JsonConvert.DeserializeObject<OptimizedPromptPackItems>(json);
                return OperationResult<OptimizedPromptPackItems, string, string>.Success(optimizedPromptPackItems);
            }
        }
    }
}

