using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


public abstract class LLMTaskBase<TInp, TOut>(ILLMConnectorV2 llmConnector)
{

    /// <summary>
    /// The LlmConnector is the communication between your code and the
    /// LLS services provider or the LLM service. 
    /// </summary>
    protected virtual ILLMConnectorV2 LlmConnector { get; init; } = llmConnector;


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<string, string, string>> ExAsSingleWordAsync()
    {
        var input = GetInput();
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<TInp, TOut>(target, LLMTaskDescriptionInputFormats.Sentence, LLMTaskDescriptionOutputFormats.SingleWord, LlmConnector);
        var result = await tdca.InvokeAsync(input);

        return OperationResult<string, string, string>.Success("");
    }


    /// <summary>
    /// You will need to override this method and provide
    /// TInp as the return value. 
    /// </summary>
    /// <returns></returns>
    public abstract TInp GetInput();



}

