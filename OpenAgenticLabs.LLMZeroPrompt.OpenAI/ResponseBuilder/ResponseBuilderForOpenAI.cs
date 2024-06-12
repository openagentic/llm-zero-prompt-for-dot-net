using Newtonsoft.Json;
using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.ChatCompletionBuilder;


/// <summary>
/// This extension implements build functionality for OpenAI connector.
/// The resulting JSON object is used to send a request to OpenAI API.
/// </summary>
public static class ResponseBuilderForOpenAI
{


    public static OperationResult<IChatCompletionResponseV2, string, string> Build(string responsePayload)
    {
        try
        {
            var chatCompletionResponsePayload = JsonConvert.DeserializeObject<ChatCompletionResponsePayloadV2>(responsePayload);

            var response = new ChatCompletionResponseV2(chatCompletionResponsePayload);

            return OperationResult<IChatCompletionResponseV2, string, string>.Success(response);
        }
        catch (Exception ex)
        {
            return OperationResult<IChatCompletionResponseV2, string, string>.Failure(ex.Message, ex);
        }
    }

}

