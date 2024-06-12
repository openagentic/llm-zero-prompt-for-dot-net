using LLMZeroPrompt.Core.Tools;
using OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;

/// <summary>
/// This is the base class for all large language connectors.
/// </summary>
/// <param name="settings">The connector settings, this is a required field.</param>
public abstract class ConnectorBaseForLlmV2(IConnectorSettingsV2 settings) : ChainBase
{

    /// <summary>
    /// This is the system id, it is the id of the system the connector is part of. 
    /// </summary>
    public abstract Guid SystemId { get; init; }

    /// <summary>
    /// This is a unique identifier of the connector.
    /// </summary>
    public abstract Guid Identifier { get; init; }

    /// <summary>
    /// The name of the connector.
    /// You have to provide a name for the connector as this is a required field. and an abstract class
    /// Required: This is a required field and must be provided.
    /// </summary>
    public abstract string Name { get; init; }

    /// <summary>
    /// The name of the connector.
    /// You have to provide a name for the connector as this is a required field. and an abstract class
    /// Required: This is a required field and must be provided.
    /// </summary>
    public abstract string Description { get; init; }

    /// <summary>
    /// The name of the connector.
    /// You have to provide a name for the connector as this is a required field. and an abstract class
    /// Required: This is a required field and must be provided.
    /// </summary>
    public abstract string Version { get; init; }

    /// <summary>
    /// The setting for the connector.
    /// Required: This is a required field and must be provided.
    /// </summary>
    public virtual IConnectorSettingsV2 ConnectorSettings { get; init; } = settings;


    /// <summary>
    /// This is a safeguard that will prevent the connector from going into an infinite loop.
    /// It means that there is a maximum number of loops that can be done.
    /// Default is 3, this means you can not preform more than 3 Tools interaction at a time.
    /// </summary>
    public int? MaxLoop { get; init; } = settings.MaxLoop;


    /// <summary>
    /// This is a list of Tools that can be used by the connector.
    /// </summary>
    public List<ITool>? Tools { get; init; } = settings.Tools;


}
