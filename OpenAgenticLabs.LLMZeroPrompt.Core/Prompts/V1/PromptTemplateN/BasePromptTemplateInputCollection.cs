

//namespace OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.PromptTemplateN;


///// <summary>
///// This class represents a collection of PromptTemplateInput objects.
///// </summary>
//public class BasePromptTemplateInputCollection
//{


//    private List<BasePromptTemplateInput> inputList;


//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
//    public BasePromptTemplateInputCollection()
//    {
//        this.inputList = new List<BasePromptTemplateInput>();

//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
//    public BasePromptTemplateInputCollection(string input)
//    {
//        this.inputList = new List<BasePromptTemplateInput>();

//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
  
//    public BasePromptTemplateInputCollection(BasePromptTemplateInput input)
//    {
//        this.inputList = new List<BasePromptTemplateInput>();
//        this.inputList.Add(input);
//    }


//    /// <summary>
//    /// This method returns a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <returns></returns>
//    public static BasePromptTemplateInputCollection New()
//    {
//        return new BasePromptTemplateInputCollection();
//    }

//    /// <summary>
//    /// This method returns a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <returns></returns>
//    public static BasePromptTemplateInputCollection New(string input)
//    {
//        return new BasePromptTemplateInputCollection(input);
//    }


//    /// <summary>
//    /// This method adds a new input to the input list.
//    /// </summary>
//    /// <param name="input"></param>
//    public void Add(BasePromptTemplateInput input)
//    {
//        this.inputList.Add(input);
//    }

//    /// <summary>
//    /// This method returns the list the input list.
//    /// </summary>
//    /// <returns></returns>
//    public List<BasePromptTemplateInput> GetInputList()
//    {
//        return this.inputList;
//    }
//}
