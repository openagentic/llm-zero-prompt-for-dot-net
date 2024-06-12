

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.PromptTemplateV2;


/// <summary>
/// This class represents a collection of PromptTemplateInput objects.
/// </summary>
public class BasePromptTemplateInputCollectionV2
{


    private List<BasePromptTemplateInputV2> inputList;


    /// <summary>
    /// Constructor for the PromptTemplateInputCollection class.
    /// </summary>
    /// <param name="input"></param>
    public BasePromptTemplateInputCollectionV2()
    {
        this.inputList = new List<BasePromptTemplateInputV2>();

    }

    /// <summary>
    /// Constructor for the PromptTemplateInputCollection class.
    /// </summary>
    /// <param name="input"></param>
    public BasePromptTemplateInputCollectionV2(string input)
    {
        this.inputList = new List<BasePromptTemplateInputV2>();

    }

    /// <summary>
    /// Constructor for the PromptTemplateInputCollection class.
    /// </summary>
    /// <param name="input"></param>
  
    public BasePromptTemplateInputCollectionV2(BasePromptTemplateInputV2 input)
    {
        this.inputList = new List<BasePromptTemplateInputV2>();
        this.inputList.Add(input);
    }


    /// <summary>
    /// This method returns a new instance of PromptTemplateInput.
    /// </summary>
    /// <returns></returns>
    public static BasePromptTemplateInputCollectionV2 New()
    {
        return new BasePromptTemplateInputCollectionV2();
    }

    /// <summary>
    /// This method returns a new instance of PromptTemplateInput.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static BasePromptTemplateInputCollectionV2 New(string input)
    {
        return new BasePromptTemplateInputCollectionV2(input);
    }


    /// <summary>
    /// This method adds a new input to the input list.
    /// </summary>
    /// <param name="input"></param>
    public void Add(BasePromptTemplateInputV2 input)
    {
        this.inputList.Add(input);
    }

    /// <summary>
    /// This method returns the list the input list.
    /// </summary>
    /// <returns></returns>
    public List<BasePromptTemplateInputV2> GetInputList()
    {
        return this.inputList;
    }
}
