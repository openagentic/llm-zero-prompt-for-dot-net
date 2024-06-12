using LLMZeroPrompt.Core.Tools;
using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


/// <summary>
/// This class is configuration required when creating and instance of LLMConnectorOpenAiV2.
/// </summary>
/// <param name="systemId">This is the ID of the system using the connector. Required.</param>
/// <param name="apiKey">This is the OpenAI API key, you will get this from OpenAI web. Required. portal.</param>
/// <param name="baseUrl">This is the base URL used for making API calls with OpenAI.Optional.</param>
/// <param name="model">This is the model to use when interacting with OpenAI service.Optional.</param>
/// <param name="tools">This is a list of tools the connector has access to and can call. Optional.</param>
/// <param name="maxLoop">This is a safeguard on the max number of retries the connector will preform in error situations.Optional.</param>
public class OpenAiConnectorSettingsV2(Guid systemId, string apiKey, IConnectorModelSettingsV2 modelSettings,  string? baseUrl = null, List<ITool>? tools = null, int? maxLoop = null) : IConnectorSettingsV2
{

    /// <summary>
    /// This si the ID that the OpenAI connector is part of.
    /// Required: This is a required property and can not be null.
    /// </summary>
    public Guid SystemId { get; init; } = systemId;


    /// <summary>
    /// LLM service API key. This will normally be able to create a key using service provider portal.
    /// In the case of OpenAI, this key can be created using the service provider portal.
    /// Required: This is a required property.
    /// </summary>
    public string? ApiKey { get; init; } = apiKey;

	/// <summary>
	/// Base URL to use for requests.
	/// Optional: This is an optional property and can be null or not provided.
	/// Default: https://api.openai.com/v1/chat/completions
	/// </summary>
	public string? BaseUrl { get; init; } = baseUrl ?? "https://api.openai.com/v1/chat/completions";


	/// <summary>
	/// This is a list of tools that can be used by the connector.
	/// Optional: This is an optional property and can be null or not provided.
	/// Default:
	/// </summary>
	public List<ITool>? Tools { get; init; } = tools;


    /// <summary>
    /// This is a safeguard that will prevent the connector from going into an infinite loop.
    /// It means that there is a maximum number of loops that can be done.
    /// Default is 3, this means you can not preform more than 3 tools interaction at a time.
    /// Optional: This is an optional property and can be null or not provided.
    /// Default: 3
    /// </summary>
    public int? MaxLoop { get; init; } = maxLoop ?? 3;


    /// <summary>
    /// These are the setting that will be used when invoking the model.
    /// </summary>
    public IConnectorModelSettingsV2 ModelSettings { get; init; } = modelSettings;
}

