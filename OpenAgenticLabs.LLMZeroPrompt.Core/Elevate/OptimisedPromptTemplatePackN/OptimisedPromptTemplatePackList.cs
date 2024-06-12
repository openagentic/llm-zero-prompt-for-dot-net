using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePack;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.OptimisedPromptTemplatePackN;



public class OptimisedPromptTemplatePackList(List<OptimisedPromptTemplatePackTemplatePack>? list = null) : IOptimisedPromptTemplatePackList
{

    public List<OptimisedPromptTemplatePackTemplatePack> List { get; set; } = list ?? [];


}


