



namespace OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;

/// <summary>
/// This is the interface for the chain.
/// </summary>
public interface IChain
{
    IChain Add(IChain nextItem);

    Task<object> ChainInvokeAsync(object input, CancellationToken cancelToken = default);



}

