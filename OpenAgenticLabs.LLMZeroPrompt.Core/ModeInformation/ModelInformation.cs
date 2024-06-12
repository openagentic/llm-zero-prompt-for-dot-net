using Newtonsoft.Json;
using System.Reflection;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.LlmN;




/// <summary>
/// Provides information about the LLM model.
/// </summary>
public class ModelInformation(Guid id, string vendor, string name, string version, double parameterSize, double contextLength, bool gqa, DateTime knowledgeCutoff, bool HasOptimizedPromptPack, string description, string family, string fileName)
{

    /// <summary>
    /// Global unique identifier for the model.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; } = id;

    /// <summary>
    /// This is the vendor responsable for creating/owning the LLM model.
    /// </summary>
    [JsonProperty("vendor")]
    public string Vendor { get; set; } = vendor;

    /// <summary>
    /// This is the name of the model.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = name;

    /// <summary>
    /// Description of the LLM model.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = description;


    /// <summary>
    /// The name of the family the model belong to
    /// </summary>
    [JsonProperty("family")]
    public string family { get; set; } = family;

    /// <summary>
    /// This is the vendor responsable for creating/owning the LLM model.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; } = version;

    /// <summary>
    /// This is the size of the model, like 1 billion, 8 billion.
    /// Example: 1000000000f is 1B
    /// </summary>
    [JsonProperty("parameterSize")]
    public double ParameterSize { get; set; } = parameterSize;

    /// <summary>
    /// This is the length of the context window.
    /// </summary>
    [JsonProperty("contextLength")]
    public double ContextLength { get; set; } = contextLength;

    /// <summary>
    /// This is the GQA for the model
    /// </summary>
    [JsonProperty("gqa")]
    public bool GQA { get; set; } = gqa;

    /// <summary>
    /// This is the date when the cutoff was for the Model training data.
    /// </summary>
    [JsonProperty("knowledgeCutoff")]
    public DateTime KnowledgeCutoff { get; set; } = knowledgeCutoff;


    /// <summary>
    /// True if there is an optimized prompt pack available.
    /// </summary>
    [JsonProperty("fileName")]
    public string FileName { get; set; } = fileName;


    /// <summary>
    /// Reads the optimized prompt templates from an embedded resource.
    /// </summary>
    /// <param name="resourceName">The name of the embedded resource.</param>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    public static OperationResult<ModelInformationList, string, string> GetAllSupportedModels(Assembly assembly, string resourceName)
    {
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                return OperationResult<ModelInformationList, string, string>.Failure($"Embedded resource '{resourceName}' not found.");
            }

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var optimizedPromptTemplates = JsonConvert.DeserializeObject<ModelInformationList>(json);
                return OperationResult<ModelInformationList, string, string>.Success(optimizedPromptTemplates);
            }
        }
    }
}


