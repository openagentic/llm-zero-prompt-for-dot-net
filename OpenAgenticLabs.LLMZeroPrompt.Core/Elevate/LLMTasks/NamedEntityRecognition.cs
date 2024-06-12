using Newtonsoft.Json.Linq;
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
public class NamedEntityRecognition(ILLMConnectorV2 llmConnector)
{

    private string _question = string.Empty;
    private string _context = string.Empty;
    private ILLMConnectorV2 _llmConnector = llmConnector;

    public NamedEntityRecognition Inp(string question, string context)
    {
        _question = question;
        _context = context;
        return this;
    }

    /// <summary>
    /// Calling this method will invoke the LLM with the input and return sentence response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<JArray, string, string>> ExAsJsonAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, JArray>(target, LLMTaskDescriptionInputFormats.Paragraph, LLMTaskDescriptionOutputFormats.JsonArrayKeyValuePairs, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<JArray, string, string>.Success(result.SuccessValue);
    }


    /// <summary>
    /// Calling this method will invoke the LLM with the input and return sentence response.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<string, string, string>> ExAsJsonStringAsync()
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, JArray>(target, LLMTaskDescriptionInputFormats.Paragraph, LLMTaskDescriptionOutputFormats.JsonArrayKeyValuePairs, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<string, string, string>.Success(result.SuccessValue.ToString());
    }

}



