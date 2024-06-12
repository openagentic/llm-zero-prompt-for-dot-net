using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


/// <summary>
/// A straightforward question that demands a factual response,
/// the answer.The answer can take many forms and by selecting the form
/// you expect the result in will be used to guide the answer
/// expected from the LLM. It is important to understand
/// the return elevate type 'ElevateOperationResult'type.
/// ElevateOperationResult is a magical type, in its
/// will return Success, Failure or Exit and with each of these
/// there is also a value and message. The idea is to indicate
/// Success, Failure or Exit and also other information like
/// in the case of Failure, this could be the value returned by the LLM
/// but Failed because the format was incorrect. This way a simple
/// failure turns into information you may be able to use.
/// </summary>
/// <param name="llmConnector">The connector to be used to make a call to LLM to get an answer.</param>
public class QuestionAnswer(ILLMConnectorV2 llmConnector)
{

    private string _question = string.Empty;
    private string _context = string.Empty;
    private readonly ILLMConnectorV2 _llmConnector = llmConnector;

    public QuestionAnswer Inp(string question, string context)
    {
        _question = question;
        _context = context;
        return this;
    }


    /// <summary>
    /// Calling this method will invoke the LLM with the input and return a single word response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<string, string, string>> ExAsSingleWordAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, string>(target, LLMTaskDescriptionInputFormats.Sentence, LLMTaskDescriptionOutputFormats.SingleWord, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<string, string, string>.Success(result.SuccessValue);
    }


    /// <summary>
    /// Calling this method will invoke the LLM with the input and return sentence response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<string, string, string>> ExAsASentenceAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, string>(target, LLMTaskDescriptionInputFormats.Sentence, LLMTaskDescriptionOutputFormats.Sentence, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<string, string, string>.Success(result.SuccessValue);
    }



    /// <summary>
    /// Calling this method will invoke the LLM with the input and return sentence response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<double, string, string>> ExAsAsDoubleAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, double>(target, LLMTaskDescriptionInputFormats.Sentence, LLMTaskDescriptionOutputFormats.Double, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<double, string, string>.Success(result.SuccessValue);
    }


    /// <summary>
    /// Calling this method will invoke the LLM with the input and return sentence response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<bool, string, string>> ExAsAsBooleanAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, bool>(target, LLMTaskDescriptionInputFormats.Sentence, LLMTaskDescriptionOutputFormats.Boolean, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<bool, string, string>.Success(result.SuccessValue);
    }

}



