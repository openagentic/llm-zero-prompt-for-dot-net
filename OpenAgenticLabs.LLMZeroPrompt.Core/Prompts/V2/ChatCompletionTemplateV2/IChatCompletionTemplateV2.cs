using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.PromptTemplateV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;


public interface IChatCompletionTemplateV2 : IPromptTemplateV2
{

    /// <summary>
    /// This will build the prompt template and return the collection of messages.
    /// <param name="inputVariables"></param>
    /// <returns></returns>
    OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string> GetMessageCollection(Dictionary<string, string> inputVariables);


    /// <summary>
    /// This will build the prompt template and return the collection of messages.
    /// </summary>
    /// <returns></returns>
    OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string> GetMessageCollection();
}
