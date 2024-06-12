

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.PromptTemplateV2;



/// <summary>
/// This is the class for prompt template input.
/// </summary>
public class BasePromptTemplateInputV2
{

    ///// <summary>
    /////  This is the prompt template input; 
    ///// </summary>
    public BasePromptTemplateInputCollectionV2 InputCollection { get; }


    /// <summary>
    /// Constructor for the PromptTemplateInput class.
    /// </summary>
    /// <param name="input"></param>
    public BasePromptTemplateInputV2(BasePromptTemplateInputCollectionV2 input)
    {
        this.InputCollection = input;
    }

    /// <summary>
    /// Constructor for the PromptTemplateInput class.
    /// </summary>
    /// <param name="input"></param>
    public BasePromptTemplateInputV2()
    {

    }


    /// <summary>
    /// Calling this static method will create a new instance of PromptTemplateInput. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static BasePromptTemplateInputV2 New() 
    {
        return new BasePromptTemplateInputV2();

    }

    /// <summary>
    /// Calling this static method will create a new instance of PromptTemplateInput. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static BasePromptTemplateInputV2 New(BasePromptTemplateInputCollectionV2 input)
    {
        return new BasePromptTemplateInputV2(input);

    }

}

