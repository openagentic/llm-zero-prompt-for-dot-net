using System.Net.Http.Headers;
using System.Net;
using System.Text;
using LLMZeroPrompt.Core.Tools;
using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.LlmN;
using OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.ChatCompletionBuilder;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.OptimisedPromptPack;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


/// <summary>
/// This is the OpenAI connector class and implements
/// the IConnector interface for the family of OpenAI LLMs. It provides
/// functionality for interacting with Open AI LLM.The connector also
/// implements the IChain interface to enable the connector to be part
/// of a chain that can be invoked. It also provides prompt packs that
/// have been optimized for the LLM models supported by the connector.
/// The optimized prompt packs enable you to prompt the LLM and get the
/// response you intended as the packs have been tuned for the LLM models
/// supported by the connector.
/// </summary>
public class ConnectorOpenForAiV2 : ConnectorBaseForLlmV2, ILLMConnectorV2
{
    /// <summary>
    /// This system id, is normally the id of the system using the connector.
    /// If the system was called "MySystem" then the system id would be the
    /// id of "MySystem".
    /// </summary>
    public override Guid SystemId { get; init; }

    /// <summary>
    /// This is a unique identifier of the connector.
    /// If you create you own connector by inheriting
    /// from this class you should override this Identifier
    /// by generating a new compatible  Guid and assigning  it

    /// </summary>
    public override Guid Identifier { get; init; } = Guid.Parse("3fd4c1c6-7a2d-4e2c-8f6b-1c8e1f4c8f6b");

    /// <summary>
    /// This is the name of the connector.
    /// </summary>
    public override string Name { get; init; } = "ConnectorOpenAi";

    /// <summary>
    /// This will get a description of this connector.
    /// </summary>
    public override string Description { get; init; } = "This is OpenAI connector v2 for interacting with the OpenAI family of LLM.";

    /// <summary>
    /// This is the current connector version. If you inherit from this class
    /// you show override this property and update its version.
    /// </summary>
    public override string Version { get; init; } = "2.0.0";


    /// <summary>
    /// This is the ApiKey for interacting with OpenAI.
    /// You cna get this key by going to the Open API
    /// playground and creating an account and getting the key.
    /// The playground is located here: https://bit.ly/oaipg
    /// Require: Yes
    /// </summary>
    public string ApiKey { get; init; }

    /// <summary>
    /// Base URL to use for interacting with OpenAI.
    /// The base URL will default to https://api.openai.com/v1/chat/completions
    /// if not provided.
    /// Required: Yes
    /// Default: https://api.openai.com/v1/chat/completions
    /// </summary>
    public string BaseUrl { get; init; }


    /// <summary>
    /// These are the settings been used with the connector.
    /// </summary>
    public IConnectorSettingsV2 Settings { get; init; }


    private const string DefaultBaseUrl = "https://api.openai.com/v1/chat/completions";



    /// <summary>
    /// Constructor for the OpenAI connector.
    /// </summary>
    /// <param name="settings"></param>
    public ConnectorOpenForAiV2(IConnectorSettingsV2 settings) : base(settings)
    {
        SystemId = settings.SystemId;

        ApiKey = settings.ApiKey;


        Tools = new List<ITool>();
        if (settings.Tools != null)
        {
            Tools.AddRange(settings.Tools);
        }

        BaseUrl = settings.BaseUrl ?? DefaultBaseUrl;

        Settings = settings;

    }

    /// <summary>
    /// Invoking this will return the current mode been used by the connector.
    /// </summary>
    /// <returns></returns>
    public OperationResult<string, string, string> GetCurrentModel()
    {
        return OperationResult<string, string, string>.Success(Settings.ModelSettings.Model);
    }


    /// <summary>
    /// Get a list of LLM models supported by this connector.
    /// </summary>
    /// <returns>ModelInformationList contains a list of all the LLM models supported by this connector.</returns>
    public OperationResult<ModelInformationList, string, string> GetSupportedModels()
    {
        return OptimisedPromptPackForOpenAi.GetSupportedModels();
    }

    /// <summary>
    /// Get optimised prompt pack for a model.
    /// </summary>
    /// <param name="modelName">The name of the model to get the optimized prompt packs for.</param>
    /// <returns>The return will be a list of optimized prompt packs for the model described in modelName input field.</returns>
    public OperationResult<List<OptimizedPromptPackItems>, string, string> GetPromptPacksForModel(string modelName)
    {
        return OptimisedPromptPackForOpenAi.GetPromptPackForModels(modelName);
    }


    /// <summary>
    /// Get all optimized prompt packs support by this connector.
    /// </summary>
    /// <returns>OptimizedPromptPackItems</returns>
    public OperationResult<OptimizedPromptPackItems, string, string> GetSupportedPromptPacks()
    {
        return OptimisedPromptPackForOpenAi.GetPromptPackForAllModels();
    }


    ///// <summary>
    ///// Calling this method will invoke the LLL by sending the data provided in the input.
    ///// </summary>
    ///// <param name="input"></param>
    ///// <param name="cancelToken"></param>
    ///// <returns></returns>
    public override async Task<object> ChainInvokeAsync(object input, CancellationToken cancelToken = default)
    {

        return new object();
    }


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
    public virtual async Task<OperationResult<IChatCompletionResponseV2, string, string>> InvokeAsync(ChatCompletionTemplateV2 chatCompletionTemplate, CancellationToken cancelToken)
    {
        try
        {
            var payLoadResult = await InvokeAsync(chatCompletionTemplate, Settings.ModelSettings, cancelToken);
            if (payLoadResult.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<IChatCompletionResponseV2, string, string>.Failure(payLoadResult.FailureValue);

            return OperationResult<IChatCompletionResponseV2, string, string>.Success(payLoadResult.SuccessValue);

        }
        catch (Exception ex)
        {
            return OperationResult<IChatCompletionResponseV2, string, string>.Failure(ex.Message, ex);
        }

    }


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
    public virtual async Task<OperationResult<IChatCompletionResponseV2, string, string>> InvokeAsync(ChatCompletionTemplateV2 chatCompletionTemplate, IConnectorModelSettingsV2 modelSettings, CancellationToken cancelToken)
    {
        try
        {

            var payLoadResult = RequestBuilderForOpenAI.Build(chatCompletionTemplate, modelSettings);
            if (payLoadResult.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<IChatCompletionResponseV2, string, string>.Failure(payLoadResult.FailureValue);


            var sendPayloadResult = await SendPayloadToLLMAsync(payLoadResult.SuccessValue, cancelToken);
            if (sendPayloadResult.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<IChatCompletionResponseV2, string, string>.Failure(sendPayloadResult.FailureValue);


            var chatCompletionResponse = ResponseBuilderForOpenAI.Build(sendPayloadResult.SuccessValue);
            if (chatCompletionResponse.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<IChatCompletionResponseV2, string, string>.Failure(chatCompletionResponse.FailureValue);

            return OperationResult<IChatCompletionResponseV2, string, string>.Success(chatCompletionResponse.SuccessValue);

        }
        catch (Exception ex)
        {
            return OperationResult<IChatCompletionResponseV2, string, string>.Failure(ex.Message, ex);
        }

    }



    //private  async Task<OperationResult<string, string, string>> SendPayloadToLLMAsync(string payLoad, CancellationToken cancelToken)
    //{


    //    try
    //    {
    //        var httpClient = new HttpClient();
    //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
    //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //        var content = new StringContent(payLoad, Encoding.UTF8, "application/json");

    //        var httpResponseMessage = await httpClient.PostAsync(this.BaseUrl, content, cancelToken);
    //        if (httpResponseMessage.StatusCode != HttpStatusCode.OK) return OperationResult<string, string, string>.Failure($"Status code returned was: {httpResponseMessage.StatusCode.ToString()}");

    //        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(cancelToken);

    //        return OperationResult<string, string, string>.Success(responseContent);
    //    }
    //    catch (Exception ex)
    //    {
    //        return OperationResult<string, string, string>.Failure(ex.Message, ex);
    //    }

    //}


    private async Task<OperationResult<string, string, string>> SendPayloadToLLMAsync(string payLoad, CancellationToken cancelToken)
    {


        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestVersion = new Version(2, 0);
            httpClient.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(payLoad, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync(this.BaseUrl, content, cancelToken);
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK) return OperationResult<string, string, string>.Failure($"Status code returned was: {httpResponseMessage.StatusCode.ToString()}");

            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(cancelToken);

            return OperationResult<string, string, string>.Success(responseContent);
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure(ex.Message, ex);
        }

    }

}


