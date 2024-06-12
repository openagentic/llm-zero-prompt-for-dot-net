using LLMZeroPrompt.Core.Tools;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;


/// <summary>
/// This defines the ConnectorSettings contract.
/// </summary>
public interface IConnectorSettingsV2
{

    /// <summary>
    /// This si the ID that the OpenAI connector is part of.
    /// Required: This is a required property and can not be null.
    /// </summary>
    public Guid SystemId { get; init; }


    /// <summary>
    /// LLM service API key. This will normally be able to create a key using service provider portal.
    /// In the case of OpenAI, this key can be created using the service provider portal.
    /// Required: This is a required property
    /// </summary>
    public string ApiKey { get; init; }

    /// <summary>
    /// Base URL to use for requests.
    /// Optional: This is an optional property and can be null or not provided.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// This is a list of tools that can be used by the connector.
    /// Optional: This is an optional property and can be null or not provided.
    /// </summary>
    public List<ITool>? Tools { get; init; }


    /// <summary>
    /// This is a safeguard that will prevent the connector from going into an infinite loop.
    /// It means that there is a maximum number of loops that can be done.
    /// Default is 3, this means you can not preform more than 3 tools interaction at a time.
    /// Optional: This is an optional property and can be null or not provided.
    /// </summary>
    public int? MaxLoop { get; init; }

    /// <summary>
    /// These are the setting that will be used when invoking the model.
    /// </summary>
    public IConnectorModelSettingsV2 ModelSettings { get; init; }

}