using LLMZeroPrompt.Core.Tools;
using OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.PromptTemplateV2;

/// <summary>
///  This is the base class for prompt templates.
/// </summary>
public partial class BasePromptTemplateV2 : object, IBasePromptTemplateV2, IChain
{
    /// <summary>
    /// How many chat completion choices to generate for each input message. 
    /// Note that you will be charged based on the number of generated tokens across all of the choices. Keep n as 1 to minimize costs.
    /// </summary>
    public virtual int? N { get; set; }

    /// <summary>
    /// The maximum number of tokens that can be generated.
    /// Default is null and will be ignored
    /// </summary>
    public virtual int? MaxTokens { get; set; }


    /// <summary>
    /// Setting this will force this tool to be used.
    /// Bt default is is null and will be ignored
    /// </summary>
    public virtual ITool? ToolChoice { get; set; } 

    /// <summary>
    /// The list f Tools associated with the prompt template.
    /// </summary>
    public virtual List<ITool>? Tools { get;  set; }

    /// <summary>
    /// When this is set to true, the first available tool
    /// in Tools will be called with the LLM. If other Tools
    /// are added they will be ignored.
    /// </summary>
    public virtual bool ForceToolCall { get;  set; }


    /// <summary>
    /// This is the model the should be be used with this chat completion prompt template.
    /// If the connector does not support the model, an exception will be thrown.
    /// If this is not set the connector will use its default model.
    /// If Tools have a requirement to use this model wil be ignored.
    /// </summary>
    public virtual string? Model { get; private set; }

    /// <summary>
    /// This is the stop trigger words that should be used with this chat completion prompt template.
    /// This will instruct the LLM to stop processing once a stop trigger word is found.
    /// If no stop words are present then the LLM will process the entire prompt.
    /// </summary>
    public virtual List<string>? Stop { get;  set; }


    /// <summary>
    /// This is the Temperature to use for the LLM.
    /// Its default is null and will be ignored.
    /// Setting it will mean it will be sent to LLM by connector.
    /// </summary>
    public virtual double? Temperature { get; set; }


    /// <summary>
    /// This is a list of variables that are applied to the prompt template during build.
    /// </summary>
    public virtual Dictionary<string, string>? PromptTemplateCollectionVariables { get; init; }


    ///// <summary>
    /////  This is the prompt template input; 
    ///// </summary>
    public virtual BasePromptTemplateInputCollectionV2 PromptTemplateCollection { get; }


    /// <summary>
    /// Metadata to be used for tracing.
    /// </summary>
    public virtual Dictionary<string, object> Metadata { get; }
    
    /// <summary>
    ///  Tags to be used for tracing.
    /// </summary>
    public virtual List<string> Tags { get; }

    /// <summary>
    /// When set this will instruct the code not to handle function calling on LLM responce.
    /// This parameter is not sent to the OpenAI API.
    /// </summary>
    public bool DoNotHandleFunctionCalling { get; set; } = false;

    /// <summary>
    /// Next item in the chain.
    /// </summary>
    private IChain? nextItemInChain;


    
    
    
    public BasePromptTemplateV2()
    {
        this.Metadata = new Dictionary<string, object>();
        this.PromptTemplateCollection = new BasePromptTemplateInputCollectionV2();
        this.Tags = new List<string>();
        this.Metadata = new Dictionary<string, object>();

    }

    public static BasePromptTemplateV2 New(BasePromptTemplateInputV2 promptTemplate)
    {
        var newBasePromptTemplate = new BasePromptTemplateV2(promptTemplate);
        return newBasePromptTemplate;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    public BasePromptTemplateV2(string promptTemplateString)
    {
        this.Metadata = new Dictionary<string, object>();
        this.PromptTemplateCollection = new BasePromptTemplateInputCollectionV2(promptTemplateString);
        this.Tags = new List<string>();
        this.Metadata = new Dictionary<string, object>();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="inputVariables"></param>
    public BasePromptTemplateV2(BasePromptTemplateInputV2 promptTemplate)
    {
        this.Metadata = new Dictionary<string, object>();
        this.PromptTemplateCollection = new BasePromptTemplateInputCollectionV2(promptTemplate);
        this.Tags = new List<string>();
        this.Metadata = new Dictionary<string, object>();


    }

    /// <summary>
    /// This will build the output from the PromptTemplate template variables and return the output.
    /// </summary>
    /// <returns></returns>
    public virtual BasePromptTemplateInputCollectionV2 GetMessages()
    {
        return this.PromptTemplateCollection;
    }



    /// <summary>
    /// This will build the output from the PromptTemplate template variables and return the output.
    /// </summary>
    /// <param name="inputVariables"></param>
    /// <returns></returns>
    public virtual BasePromptTemplateInputCollectionV2 GetMessages(Dictionary<string, string> promptTemplateVariables)
    {

        return this.PromptTemplateCollection;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextItem"></param>
    /// <returns></returns>
    public IChain Add(IChain nextItem)
    {
        nextItemInChain = nextItem;
        return this;
    }


    public async Task<object> ChainInvokeAsync(object input, CancellationToken cancelToken = default)
    {
        var returnObject = await InvokeRouterAsync(input, cancelToken);

        return returnObject;
    }

    /// <summary>
    /// This method will add stop words to template.
    /// </summary>
    /// <param name="stopWord"></param>
    public void AddStop(List<string> stopWords)
    {
        if (this.Stop is null)
        {
            this.Stop = new List<string>();
        }

        this.Stop.AddRange(stopWords);
    }
    

    
    /// <summary>
    /// This method will add stop words to template.
    /// </summary>
    /// <param name="stopWord"></param>
    public void AddStop(string stopWord)
    {
        if (this.Stop is null)
        {
            this.Stop = new List<string>();
        }

        this.Stop.Add(stopWord);
    }

    /// <summary>
    /// This method will clear stop words from template.
    /// </summary>
    public void ClearStop()
    {
        if (this.Stop != null)
        {
            this.Stop.Clear();
        }

    }

    /// <summary>
    /// This will return the stop words for the template.
    /// If stop is null, an empty list will be returned.
    /// </summary>
    /// <returns></returns>
    public List<string> GetStop()
    {
        return this.Stop ?? new List<string>();
    }


    /// <summary>
    /// This will set the model for the prompt template.
    /// </summary>
    /// <param name="model"></param>
    public void SetModel(string model)
    {
        this.Model = model;
    }


    /// <summary>
    /// This will route the input to the correct handler for the input type.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<object> InvokeRouterAsync(object input, CancellationToken cancellationToken = default)
    {

        if (input is string)
        {
            var result = await InvokeRouterHandleInputAsStringAsync(input, cancellationToken);

            return result;

        }

        throw new ArgumentException("The input of the chain must be must be a string.");

    }

    /// <summary>
    /// This will handle input as a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<object> InvokeRouterHandleInputAsStringAsync(object input, CancellationToken cancellationToken = default)
    {

        if ((input is string) == false)
        {
            throw new ArgumentException("The input of the chain must be must be a string.");
        }

        if (nextItemInChain is null)
        {

            return input;

        }
        else
        {
            var returnObject = await nextItemInChain.ChainInvokeAsync(input, cancellationToken);

            return returnObject;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public IChain Next => nextItemInChain;


}


