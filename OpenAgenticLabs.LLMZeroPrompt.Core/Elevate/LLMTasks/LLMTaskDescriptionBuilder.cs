using System.Text;
using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;
using OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TInp"></typeparam>
/// <typeparam name="TOut"></typeparam>
public class LLMTaskDescriptionBuilder<TInp, TOut>(string target, LLMTaskDescriptionInputFormats inputFormat, LLMTaskDescriptionOutputFormats outputFormat, ILLMConnectorV2 connector)
{

    private string _target = target;
    private LLMTaskDescriptionInputFormats _inputFormat = inputFormat;
    private LLMTaskDescriptionOutputFormats _outputFormat = outputFormat;
    private readonly ILLMConnectorV2 _connector = connector;
    private int? NumberOfWordsReturned;


    public async Task<OperationResult<TOut, string, string>> InvokeAsync(TInp input, int? numberOfWordsReturned = null)
    {
        if (numberOfWordsReturned != null) NumberOfWordsReturned = numberOfWordsReturned;

        var getTaskDescriptionResult = GeTaskDescriptionUsingTheConnectorOptimizedPromptPack(input);
        if (getTaskDescriptionResult.OperationStatus != OperationResultOperationStatus.Success)
            return OperationResult<TOut, string, string>.Failure(getTaskDescriptionResult.FailureValue);

        var promptText = getTaskDescriptionResult.SuccessValue.BuildPrompt();

        var chatCompletionTemplate = new ChatCompletionTemplateV2();
        chatCompletionTemplate.AddMessageAsUser(promptText);


        var result = await _connector.InvokeAsync(chatCompletionTemplate, CancellationToken.None);
        if (result.OperationStatus != OperationResultOperationStatus.Success)
            return OperationResult<TOut, string, string>.Failure(result.FailureValue);

        var textResponse = result.SuccessValue.Payload.Choices[0].Message.Content;
        if (textResponse == null)
            return OperationResult<TOut, string, string>.Failure("textResponse cannot be null.");

        var validationResult = TypeFormatValidator.ValidateXCanBeY(textResponse, outputFormat);
        if (validationResult.OperationStatus != OperationResultOperationStatus.Success)
            return OperationResult<TOut, string, string>.Failure(validationResult.FailureValue);

        var convertResult = TypeFormatConverter.ConvertXtoY(textResponse, outputFormat);

        if (convertResult.OperationStatus != OperationResultOperationStatus.Success)
            return OperationResult<TOut, string, string>.Failure(convertResult.FailureValue);

        if (convertResult.SuccessValue is TOut)
        {
            return OperationResult<TOut, string, string>.Success((TOut)convertResult.SuccessValue);
        }
        else
        {
            return OperationResult<TOut, string, string>.Failure("Conversion result is not of type TOut.");
        }
    }


    /// <summary>
    /// This will use the connector to get the LLMTaskDescription based on the connector optimized prompt pack. 
    /// </summary>
    /// <param name="connector"></param>
    /// <returns></returns>
    private OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string> GeTaskDescriptionUsingTheConnectorOptimizedPromptPack(TInp input)
    {

        var modelResult = _connector.GetCurrentModel();
        if(modelResult.OperationStatus != OperationResultOperationStatus.Success)
                            return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string>.Failure(modelResult.FailureValue);
        

        var promptPacksForModelResult = _connector.GetPromptPacksForModel(modelResult.SuccessValue);
        if (modelResult.OperationStatus != OperationResultOperationStatus.Success)
                            return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string>.Failure(modelResult.FailureValue);

        if(promptPacksForModelResult.SuccessValue.Count == 0)
                         return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string>.Failure("No prompt packs found for model.");
        

        var promptPackForInputOutputTypesAndFormatResult = GetPromptPackForInputOutputTypesAndFormat(_target, promptPacksForModelResult.SuccessValue);

        var inputResult = GetTaskDescriptionInputFromOptimizedPromptPack(input, promptPackForInputOutputTypesAndFormatResult.SuccessValue);

        var outputResult = GetTaskDescriptionOutputFromOptimizedPromptPack(promptPackForInputOutputTypesAndFormatResult.SuccessValue);

        var taskDescriptionResult = GetLLMTaskDescriptionFromOptimizedPromptPack(promptPackForInputOutputTypesAndFormatResult.SuccessValue, inputResult.SuccessValue, outputResult.SuccessValue);

        return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string>.Success(taskDescriptionResult.SuccessValue);
    }


    private OperationResult<OptimizedPromptPackItem, string, string> GetPromptPackForInputOutputTypesAndFormat(string targetInput,
        List<OptimizedPromptPackItems> optimizedPromptPackItemList)
    {

        var newTarget = GetTextAfterLastPeriod(targetInput).Trim().ToLower();

        foreach (var item in optimizedPromptPackItemList)
        {

            foreach (var promptPackItem in item.OptimizedPromptPackItem)
            {

                foreach (var target in promptPackItem.Targets)
                {
                    if ((inputFormat.ToString().Trim().ToLower() == target.InputTargetType.Trim().ToLower())
                        && (outputFormat.ToString().Trim().ToLower() == target.OutputTargetType.Trim().ToLower())
                        && (newTarget == target.TargetType.Trim().ToLower())
                        )
                    {
                        return OperationResult<OptimizedPromptPackItem, string, string>.Success(promptPackItem);
                    }
                }

            }

        }

        return OperationResult<OptimizedPromptPackItem, string, string>.Failure("No prompt pack found for input and output types.");
    }

    private OperationResult<OptimisedPromptPackTarget, string, string> GetTargetForSpesficModel(string modelInput, OptimizedPromptPackItem optimizedPromptPackItem)
    {

        foreach (var target in optimizedPromptPackItem.Targets)
        {

            if ((inputFormat.ToString().Trim().ToLower() == target.InputTargetType.Trim().ToLower())
                && (outputFormat.ToString().Trim().ToLower() == target.OutputTargetType.Trim().ToLower()))
            {
                foreach (var model in target.Models)
                {
                    if (model.ModelName.Trim().ToLower() == modelInput.Trim().ToLower())
                    {
                        return OperationResult<OptimisedPromptPackTarget, string, string>.Success(target);
                    }
                }
            }
        }


        return OperationResult<OptimisedPromptPackTarget, string, string>.Failure("No prompt pack found for input and output types.");
    }


    private OperationResult<LLMTaskDescriptionInput<TInp>, string, string> GetTaskDescriptionInputFromOptimizedPromptPack(TInp question, OptimizedPromptPackItem optimizedPromptPackItem)
    {

        var modelResult = _connector.GetCurrentModel();
        if (modelResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescriptionInput<TInp>, string, string>.Failure(modelResult.FailureValue);
        }

        var targetResult = GetTargetForSpesficModel(modelResult.SuccessValue, optimizedPromptPackItem);
        if (targetResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescriptionInput<TInp>, string, string>.Failure(targetResult.FailureValue);
        }

        if (targetResult.SuccessValue.Models.Count > 1)
        {
            return OperationResult<LLMTaskDescriptionInput<TInp>, string, string>.Failure("Can only have a single model per target JSON.");
        }

        var inputTag = targetResult.SuccessValue.Models[0].Inputs[0].Tag;
        var inputDescription = targetResult.SuccessValue.Models[0].Inputs[0].Description;
        var inputFormat = targetResult.SuccessValue.Models[0].Inputs[0].Format;

        var inputFormatAsEnum = (LLMTaskDescriptionInputFormats)Enum.Parse(typeof(LLMTaskDescriptionInputFormats), inputFormat, true);

        var input = new LLMTaskDescriptionInput<TInp>(question,
                                                        inputTag,
                                                        inputDescription,
                                                        inputFormatAsEnum);


        return OperationResult<LLMTaskDescriptionInput<TInp>, string, string>.Success(input);
    }

    private OperationResult<LLMTaskDescriptionOutput<TOut>, string, string> GetTaskDescriptionOutputFromOptimizedPromptPack(OptimizedPromptPackItem optimizedPromptPackItem)
    {

        var modelResult = _connector.GetCurrentModel();
        if (modelResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescriptionOutput<TOut>, string, string>.Failure(modelResult.FailureValue);
        }

        var targetResult = GetTargetForSpesficModel(modelResult.SuccessValue, optimizedPromptPackItem);
        if (targetResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescriptionOutput<TOut>, string, string>.Failure(targetResult.FailureValue);
        }

        if (targetResult.SuccessValue.Models.Count > 1)
        {
            return OperationResult<LLMTaskDescriptionOutput<TOut>, string, string>.Failure("Can only have a single model per target JSON.");
        }


        var outputTag = targetResult.SuccessValue.Models[0].Outputs[0].Tag;
        var outputDescription = targetResult.SuccessValue.Models[0].Outputs[0].Description;
        var outputFormat = targetResult.SuccessValue.Models[0].Outputs[0].Format;


        var outputFormatAsEnum = (LLMTaskDescriptionOutputFormats)Enum.Parse(typeof(LLMTaskDescriptionOutputFormats), outputFormat, true);

        var output = new LLMTaskDescriptionOutput<TOut>(outputTag, outputDescription, outputFormatAsEnum);

        return OperationResult<LLMTaskDescriptionOutput<TOut>, string, string>.Success(output);
    }


    private OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string> GetLLMTaskDescriptionFromOptimizedPromptPack(OptimizedPromptPackItem optimizedPromptPackItem, LLMTaskDescriptionInput<TInp> input, LLMTaskDescriptionOutput<TOut> output)
    {
        var modelResult = _connector.GetCurrentModel();
        if (modelResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>,
                string, string>.Failure(modelResult.FailureValue);
        }

        var targetResult = GetTargetForSpesficModel(modelResult.SuccessValue, optimizedPromptPackItem);
        if (targetResult.OperationStatus != OperationResultOperationStatus.Success)
        {
            return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>,
                string, string>.Failure(targetResult.FailureValue);
        }

        if (targetResult.SuccessValue.Models.Count > 1)
        {
            return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>,
                string, string>.Failure("Can only have a single model per target JSON.");
        }


        var name = targetResult.SuccessValue.TargetType;
        var context = targetResult.SuccessValue.Models[0].Context;
        var examples = targetResult.SuccessValue.Models[0].Examples;
        var template = targetResult.SuccessValue.Models[0].PromptTemplate;

        var exampleString = GetExamplesFromFromOptimizedPromptPack(examples);

        var taskDescription =
            new LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>(name, input,
                output, context, exampleString.SuccessValue, template, NumberOfWordsReturned);

        return OperationResult<LLMTaskDescription<LLMTaskDescriptionInput<TInp>, LLMTaskDescriptionOutput<TOut>>, string, string>.Success(taskDescription);
    }

    private OperationResult<string, string, string> GetExamplesFromFromOptimizedPromptPack(List<OptimisedPromptPackExample> examples)
    {

        StringBuilder sb = new StringBuilder();

        sb.AppendLine();
        foreach (var item in examples)
        {
            sb.Append(item.Example);
            sb.AppendLine();
        }

        return OperationResult<string, string, string>.Success(sb.ToString());
    }


    private string GetTextAfterLastPeriod(string input)
    {

        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        int lastPeriodIndex = input.LastIndexOf('.');
        if (lastPeriodIndex == -1 || lastPeriodIndex == input.Length - 1)
        {
            return input;
        }

        return input.Substring(lastPeriodIndex + 1);
    }
}
