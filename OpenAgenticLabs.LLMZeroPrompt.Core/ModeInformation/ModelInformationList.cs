using Newtonsoft.Json;
using System.Reflection;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.LlmN;


/// <summary>
/// Provides information about the LLM model.
/// </summary>
public class ModelInformationList()
{

    public List<ModelInformationList> List { get; set; }


    /// <summary>
    /// Reads the optimized prompt templates from an embedded resource.
    /// </summary>
    /// <param name="resourceName">The name of the embedded resource.</param>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    public static OperationResult<List<ModelInformation>, string, string> ReadFromEmbeddedResource(Assembly assembly, string resourceName)
    {
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                return OperationResult<List<ModelInformation>, string, string>.Failure($"Embedded resource '{resourceName}' not found.");
            }

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var optimizedPromptTemplates = JsonConvert.DeserializeObject<List<ModelInformation>>(json);
                return OperationResult<List<ModelInformation>, string, string>.Success(optimizedPromptTemplates);
            }
        }
    }
}


