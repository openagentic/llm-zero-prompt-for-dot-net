

namespace OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;


/// <summary>
/// This class is the base class for all chains.
/// </summary>
public  class ChainBase : IChain
{

    /// <summary>
    /// Next item in the chain.
    /// </summary>
    public IChain? nextItemInChain { get; private set; }

    /// <summary>
    /// Add next item in the chain.
    /// </summary>
    /// <param name="nextItem"></param>
    /// <returns></returns>
    public IChain Add(IChain nextItem)
    {
        nextItemInChain = nextItem;
        return this;
    }

    /// <summary>
    /// Invoke the chain, causing all items in the chain to preform their operation,
    /// and pass it to the next chain until the last item in the chain is reached and the result is
    /// passed back through the chain to the first item in the chain.
    /// </summary>
    /// <param name="input">The input object to the chain.</param>
    /// <param name="cancelToken">As the chail is Async a cancel token is passed to cancel lon preform ing operations</param>
    /// <returns>The result from the chain operation.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual Task<object> ChainInvokeAsync(object input, CancellationToken cancelToken = default)
    {
       throw new NotImplementedException();

    }
}
