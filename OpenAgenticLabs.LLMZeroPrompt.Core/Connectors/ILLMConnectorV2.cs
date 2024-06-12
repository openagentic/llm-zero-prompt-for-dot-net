using OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.LlmN;
using OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;


/// <summary>
/// This is the interface for the connector.
/// </summary>
public interface ILLMConnectorV2 : IChain
{

    /// <summary>
    /// This will return the connector name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// This is the description of the connector.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// This is the version of the connector.
    /// </summary>
    string Version { get; }


    /// <summary>
    /// This will be the settings for the connector.
    /// </summary>
    IConnectorSettingsV2 ConnectorSettings { get; }


    /// <summary>
    /// Invoking this will return the current mode been used by the connector.
    /// </summary>
    /// <returns></returns>
    OperationResult<string, string, string> GetCurrentModel();



    /// <summary>
    /// Get a list of LLM models supported by this connector.
    /// </summary>
    /// <returns>ModelInformationList contains a list of all the LLM models supported by this connector.</returns>
    OperationResult<ModelInformationList, string, string> GetSupportedModels();

    /// <summary>
    /// Get optimised prompt pack for a model.
    /// </summary>
    /// <param name="modelName">The name of the model to get the optimized prompt packs for.</param>
    /// <returns>The return will be a list of optimized prompt packs for the model described in modelName input field.</returns>
    OperationResult<List<OptimizedPromptPackItems>, string, string> GetPromptPacksForModel(string modelName);



    /// <summary>
    /// Get all optimized prompt packs support by this connector.
    /// </summary>
    /// <returns>OptimizedPromptPackItems</returns>
    OperationResult<OptimizedPromptPackItems, string, string> GetSupportedPromptPacks();
 

    ///// <summary>
    ///// Calling this method will invoke the LLL by sending the data provided in the input.
    ///// </summary>
    ///// <param name="input"></param>
    ///// <param name="cancelToken"></param>
    ///// <returns></returns>
    Task<object> ChainInvokeAsync(object input, CancellationToken cancelToken = default);


    /// <summary>
    /// Invoking this method will have the connector send information provided using the input
    /// arguments sent to the LLM and a response created. The response is provided using the
    /// OperationResult. It is important to understand OperationResult, this type has three states,
    /// Successful, Failure and Exit, each state also provides other values that may be useful.
    /// Success will return the ChatCompletionResponse type.
    /// </summary>
    /// <param name="chatCompletionPromptTemplate">This is the chat completion prompt template that forms the information sent to the LLM</param>
    /// <param name="cancelToken">This is the cancel token that will enable the async operation to be canceled. </param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<OperationResult<IChatCompletionResponseV2, string, string>> InvokeAsync(
        ChatCompletionTemplateV2 chatCompletionTemplate, CancellationToken cancelToken);



    // <summary>
    /// Invoking this method will have the connector send information provided using the input
    /// arguments sent to the LLM and a response created. The response is provided using the
    /// OperationResult. It is important to understand OperationResult, this type has three states,
    /// Successful, Failure and Exit, each state also provides other values that may be useful.
    /// Success will return the ChatCompletionResponse type.
    /// </summary>
    /// <param name="chatCompletionPromptTemplate">This is the chat completion prompt template that forms the information sent to the LLM</param>
    /// <param name="cancelToken">This is the cancel token that will enable the async operation to be canceled. </param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<OperationResult<IChatCompletionResponseV2, string, string>> InvokeAsync(
        ChatCompletionTemplateV2 chatCompletionTemplate, IConnectorModelSettingsV2 modelSettings,
        CancellationToken cancelToken);



}