using Newtonsoft.Json.Linq;



namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Configuration;


public class OpenAIConnectorSetting
{

    /// <summary>
    /// This si the ID that the OpenAI connector is part of.
    /// Required: This is a required property and can not be null.
    /// </summary>
    public Guid? SystemId { get; init; }


    /// <summary>
    /// LLM service API key. This will normally be able to create a key using service provider portal.
    /// In the case of OpenAI, this key can be created using the service provider portal.
    /// Required: This is a required property
    /// </summary>
    public string? ApiKey { get; init; }

    /// <summary>
    /// Base URL to use for requests.
    /// Optional: This is an optional property and can be null or not provided.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Gets or sets the model to be used.
    /// This specifies the OpenAI model to be used for generating responses.
    /// Optional: Ye
    /// Default: gpt-3.5-turbo
    /// </summary>
    public string? Model { get; set; } 

    /// <summary>
    /// Gets or sets the temperature.
    /// This parameter controls the randomness of the output. A higher value means more random completions.
    /// Optional: Yes
    /// </summary>
    public double? Temperature { get; set; } 

    /// <summary>
    /// Gets or sets the top_p value.
    /// This parameter controls diversity via nucleus sampling. A value of 0.5 means half of all likelihood-weighted options are considered.
    /// Optional: Yes
    /// </summary>
    public double? TopP { get; set; }

    /// <summary>
    /// Gets or sets the number of completions to generate.
    /// This specifies how many completions to generate for each prompt.
    /// Optional: Yes
    /// </summary>
    public int? N { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to stream responses.
    /// When true, responses are streamed back to the client as they are generated.
    /// Optional: Yes
    /// </summary>
    public bool? Stream { get; set; } 

    /// <summary>
    /// Gets or sets the stop sequence.
    /// Up to 4 sequences where the API will stop generating further tokens.
    /// </summary>
    public JToken? Stop { get; set; } 

    /// <summary>
    /// Gets or sets the maximum number of tokens.
    /// This limits the maximum number of tokens in the generated completion.
    /// Optional: Yes

    /// </summary>
    public int? MaxTokens { get; set; } 

    /// <summary>
    /// Gets or sets the presence penalty.
    /// This parameter penalizes new tokens based on whether they appear in the text so far, increasing the likelihood of exploring new topics.
    /// </summary>
    public double? PresencePenalty { get; set; } 

    /// <summary>
    /// Gets or sets the frequency penalty.
    /// This parameter penalizes new tokens based on their existing frequency in the text so far, reducing the likelihood of repeating the same line.
    /// </summary>
    public double? FrequencyPenalty { get; set; } 


    /// <summary>
    /// Gets or sets the user.
    /// This specifies the user ID to be sent with the request.
    /// </summary>
    public string? User { get; set; }
}