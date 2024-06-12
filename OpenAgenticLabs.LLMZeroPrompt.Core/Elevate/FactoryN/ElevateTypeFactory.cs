using Microsoft.Extensions.DependencyInjection;
using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.FactoryN;


public class IllmActionFactory(IServiceProvider serviceProvider) : ILLMActionFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;


    public QuestionAnswer QuestionAnswer()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new QuestionAnswer(connectorToUse);
    }

    public SentimentClassification SentimentClassification()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new SentimentClassification(connectorToUse);
    }



    public TextSummarization TextSummarization()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new TextSummarization(connectorToUse);
    }


    public NamedEntityRecognition NamedEntityRecognition()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new NamedEntityRecognition(connectorToUse);
    }


    public TextCompletion TextCompletion()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new TextCompletion(connectorToUse);
    }



    public Paraphrasing Paraphrasing()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new Paraphrasing(connectorToUse);
    }



    public GrammarCorrection GrammarCorrection()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new GrammarCorrection(connectorToUse);
    }


    public TextSimplification TextSimplification()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new TextSimplification(connectorToUse);
    }


    public CreateMicrosoftBICEPTemplate CreateMicrosoftBICEPTemplate()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new CreateMicrosoftBICEPTemplate(connectorToUse);
    }


    public ValidateAzureBicep ValidateAzureBicep()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new ValidateAzureBicep(connectorToUse);
    }


    public CreateAzurePowerShellScript CreateAzurePowerShellScript()
    {

        var result = TryGetConnectorForLlm();
        if (result.IsSuccess == false)
        {
            result = TryGetDefaultConnectorForLlm();
        }

        if (result.IsSuccess == false)
        {
            throw new InvalidOperationException("No connector found to be registered");
        }

        if (result.Result == null)
        {
            throw new InvalidOperationException($"The connector is been returned as null.");
        }

        var connectorToUse = result.Result;

        return new CreateAzurePowerShellScript(connectorToUse);
    }


    private ReturnResult<ILLMConnectorV2, string> TryGetConnectorForLlm()
    {

        try
        {
            var connectorToUse = _serviceProvider.GetService<ILLMConnectorV2>();
            if (connectorToUse == null)
            {
                return ReturnResult<ILLMConnectorV2, string>.Failure("The 'connector service is not registered.");
            }

            return ReturnResult<ILLMConnectorV2, string>.Success(connectorToUse);
        }
        catch (Exception e)
        {
            return ReturnResult<ILLMConnectorV2, string>.Failure(e.Message);
        }

    }




    private ReturnResult<ILLMConnectorV2, string> TryGetDefaultConnectorForLlm()
    {

        try
        {
            var connectorToUse = _serviceProvider.GetKeyedService<ILLMConnectorV2>("default");
            if (connectorToUse == null)
            {
                return ReturnResult<ILLMConnectorV2, string>.Failure("The 'default' connector service is not registered.");
            }

            return ReturnResult<ILLMConnectorV2, string>.Success(connectorToUse);
        }
        catch (Exception e)
        {
            return ReturnResult<ILLMConnectorV2, string>.Failure(e.Message);
        }

    }
}
