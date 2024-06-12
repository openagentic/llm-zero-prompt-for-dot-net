using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.ChatCompletionBuilder;


/// <summary>
/// This extension implements build functionality for OpenAI connector.
/// The resulting JSON object is used to send a request to OpenAI API.
/// </summary>
public static class RequestBuilderForOpenAI
{


    public static OperationResult<string, string, string> Build(ChatCompletionTemplateV2 chatCompletionTemplate, IConnectorModelSettingsV2 modelSettings)
    {
        try
        {
            var getMessageCollectionResult = chatCompletionTemplate.GetMessageCollection();
            if(getMessageCollectionResult.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<string, string, string>.Failure(getMessageCollectionResult.FailureValue);

            var buildPayLoad = BuildPayLoad(getMessageCollectionResult.SuccessValue, modelSettings);
            if (buildPayLoad.OperationStatus != OperationResultOperationStatus.Success) return OperationResult<string, string, string>.Failure(buildPayLoad.FailureValue);

            return OperationResult<string, string, string>.Success(buildPayLoad.SuccessValue);
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure(ex.Message, ex);
        }
    }

    public static OperationResult<string, string, string> BuildPayLoad(ChatCompletionTemplateMessageCollectionV2 messageCollection, IConnectorModelSettingsV2 modelSettings)


    {
        var messageArray = new JArray();

        foreach (var message in messageCollection.Messages)
        {
            var messageObject = new JObject
            {
                { "role", message.Role.AsString().Trim().ToLower() },
                { "content", message.Content }
            };
            messageArray.Add(messageObject);
        }



        var jsonObject = new JObject();

        jsonObject.Add("model", modelSettings.Model);

        jsonObject.Add("messages", messageArray);
        

        if (modelSettings.Temperature != null)
        {
            jsonObject.Add("temperature", modelSettings.Temperature);
        }

        if (modelSettings.TopP != null)
        {
            jsonObject.Add("top_p", modelSettings.TopP);
        }



        if (modelSettings.N != null)
        {
            jsonObject.Add("n", modelSettings.N);
        }


        if (modelSettings.Stream != null)
        {
            jsonObject.Add("stream", modelSettings.Stream);
        }


        if (modelSettings.Stop != null)
        {
            jsonObject.Add("stop", modelSettings.Stop);
        }
       

        if (modelSettings.MaxTokens != null)
        {
            jsonObject.Add("max_tokens", modelSettings.MaxTokens);
        }

        if (modelSettings.PresencePenalty != null)
        {
            jsonObject.Add("presence_penalty", modelSettings.PresencePenalty);
        }

        if (modelSettings.FrequencyPenalty != null)
        {
            jsonObject.Add("frequency_penalty", modelSettings.FrequencyPenalty);
        }

        if (modelSettings.LogitBias != null)
        {
            jsonObject.Add("logit_bias", modelSettings.LogitBias);
        }
        
        if (modelSettings.User != null)
        {
            jsonObject.Add("user", modelSettings.User);
        }

        string jsonString = jsonObject.ToString(Formatting.None);

        return OperationResult<string, string, string>.Success(jsonString);

    }
}

