using Newtonsoft.Json.Linq;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


public class OpenAiConnectorModelSettingsV2(string? model = null,
                                    double? temperature = null,
                                    double? topP = null,
                                    int? n = null,
                                    bool? stream = null,
                                    JToken? stop = null,
                                    int? maxTokens = null,
                                    double? presencePenalty = null,
                                    double? frequencyPenalty = null,
                                    JObject? logitBias = null,
                                    string user = null) : IConnectorModelSettingsV2
{
    /// <summary>
    /// Gets or sets the model to be used.
    /// This specifies the OpenAI model to be used for generating responses.
    /// Optional: Ye
    /// Default: gpt-3.5-turbo
    /// </summary>
    public string Model { get; set; } = model ?? "gpt-3.5-turbo";

    /// <summary>
    /// Gets or sets the temperature.
    /// This parameter controls the randomness of the output. A higher value means more random completions.
    /// Optional: Yes
    /// </summary>
    public double? Temperature { get; set; } = temperature;

    /// <summary>
    /// Gets or sets the top_p value.
    /// This parameter controls diversity via nucleus sampling. A value of 0.5 means half of all likelihood-weighted options are considered.
    /// Optional: Yes
    /// </summary>
    public double? TopP { get; set; } = topP;

    /// <summary>
    /// Gets or sets the number of completions to generate.
    /// This specifies how many completions to generate for each prompt.
    /// Optional: Yes
    /// </summary>
    public int? N { get; set; } = n;

    /// <summary>
    /// Gets or sets a value indicating whether to stream responses.
    /// When true, responses are streamed back to the client as they are generated.
    /// Optional: Yes
    /// </summary>
    public bool? Stream { get; set; } = stream;

    /// <summary>
    /// Gets or sets the stop sequence.
    /// Up to 4 sequences where the API will stop generating further tokens.
    /// </summary>
    public JToken? Stop { get; set; } = stop;

    /// <summary>
    /// Gets or sets the maximum number of tokens.
    /// This limits the maximum number of tokens in the generated completion.
    /// Optional: Yes

    /// </summary>
    public int? MaxTokens { get; set; } = maxTokens;

    /// <summary>
    /// Gets or sets the presence penalty.
    /// This parameter penalizes new tokens based on whether they appear in the text so far, increasing the likelihood of exploring new topics.
    /// </summary>
    public double? PresencePenalty { get; set; } = presencePenalty;

    /// <summary>
    /// Gets or sets the frequency penalty.
    /// This parameter penalizes new tokens based on their existing frequency in the text so far, reducing the likelihood of repeating the same line.
    /// </summary>
    public double? FrequencyPenalty { get; set; } = frequencyPenalty;

    /// <summary>
    /// Gets or sets the logit bias.
    /// This parameter allows biasing the probability of specific tokens appearing in the completion.
    /// </summary>
    public JObject? LogitBias { get; set; } = logitBias;

    /// <summary>
    /// Gets or sets the user.
    /// This specifies the user ID to be sent with the request.
    /// </summary>
    public string? User { get; set; } = user;



}
