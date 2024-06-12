using Newtonsoft.Json;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePackN;

public class OptimisedPromptTemplateTarget
{
    [JsonProperty("targetType")]
    public string Type { get; set; }

    [JsonProperty("models")]
    public OptimisedPromptTemplateModel[] Models { get; set; }
}