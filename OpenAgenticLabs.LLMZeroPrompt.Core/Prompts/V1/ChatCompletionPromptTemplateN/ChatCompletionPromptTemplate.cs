//using HandlebarsDotNet;
//using System.Text.RegularExpressions;
//using LLMZeroPrompt.Core.Tools;
//using OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.PromptTemplateN;
//using OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.ToolsN;


//namespace OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.ChatCompletionTemplateN;



///// <summary>
///// `
///// </summary>
//public class ChatCompletionPromptTemplate : BasePromptTemplate, IChatCompletionPromptTemplate
//{


//    ///// <summary>
//    /////  This is the prompt template input; 
//    ///// </summary>
//    public new virtual ChatCompletionPromptTemplateMessageCollection PromptTemplateCollection { get; init; }

    
//    /// <summary>
//    ///  This is the constructor for the ChatCompletionPromptTemplate class.
//    /// </summary>
//    public ChatCompletionPromptTemplate() : base()
//    {

//        PromptTemplateCollection = new ChatCompletionPromptTemplateMessageCollection();
//        PromptTemplateCollectionVariables = new Dictionary<string, string>();
//    }


//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="input"></param>
//    public ChatCompletionPromptTemplate(string input) : base()
//    {
//        this.PromptTemplateCollection = new ChatCompletionPromptTemplateMessageCollection(input);
//        this.PromptTemplateCollectionVariables = new Dictionary<string, string>();


//    }

    
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="inputVariables"></param>
//    public ChatCompletionPromptTemplate(string input, Dictionary<string, string> inputVariables) : base()
//    {
//        this.PromptTemplateCollection = new ChatCompletionPromptTemplateMessageCollection(input);
//        this.PromptTemplateCollectionVariables = inputVariables;

//    }

//    /// <summary>
//    /// This will new an instance of ChatCompletionPromptTemplate and return it.
//    /// </summary>
//    /// <returns>Instance of ChatCompletionPromptTemplate</returns>
//    public static ChatCompletionPromptTemplate New()
//    {
//        var newChatCompletionPromptTemplate = new ChatCompletionPromptTemplate();
//        return newChatCompletionPromptTemplate;
//    }


//    /// <summary>
//    /// This will new an instance of ChatCompletionPromptTemplate and return it.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplate New(string input)
//    {
//        var newChatCompletionPromptTemplate = new ChatCompletionPromptTemplate(input);
//        return newChatCompletionPromptTemplate;
//    }


   
//    /// <summary>
//    /// This will build the output from the PromptTemplate template variables and return the output.
//    /// </summary>
//    /// <param name="inputVariables"></param>
//    /// <returns></returns>
//    public new virtual ChatCompletionPromptTemplateMessageCollection Build(Dictionary<string, string> inputVariables)
//    {
//        CheckPlaceHoldersAreAlsoInInputVariables(this.PromptTemplateCollection, inputVariables);

//        HandlebarsTemplate<object, object> handlebarsTemplate;
//        string result;
//        var inputCollection = ChatCompletionPromptTemplateMessageCollection.New();
//        var newInputCollection = ChatCompletionPromptTemplateMessageCollection.New();


//        foreach (var item in this.PromptTemplateCollection.GetInputList())
//        {
//            handlebarsTemplate = Handlebars.Compile(item.Content);
//            result = handlebarsTemplate(inputVariables);
//            inputCollection.Add(result, item.Role);
//        }

//        foreach (var item in inputCollection.Templates)
//        {
//            handlebarsTemplate = Handlebars.Compile(item.Content);
//            result = handlebarsTemplate(this.PromptTemplateCollectionVariables);
//            newInputCollection.Add(result, item.Role);
//        }
//        return newInputCollection;
//    }


   
//    /// <summary>
//    /// This will build the output from the PromptTemplate template variables and return the output.
//    /// </summary>
//    /// <returns></returns>
//    public new virtual ChatCompletionPromptTemplateMessageCollection Build()
//    {
//        CheckPlaceHoldersAreAlsoInInputVariables(this.PromptTemplateCollection, this.PromptTemplateCollectionVariables);

//        HandlebarsTemplate<object, object> handlebarsTemplate;
//        string result;
//        var inputCollection = ChatCompletionPromptTemplateMessageCollection.New();
//        var newInputCollection = ChatCompletionPromptTemplateMessageCollection.New();

//        var inputList = this.PromptTemplateCollection.GetInputList();
//        foreach (var item in inputList)
//        {
//            handlebarsTemplate = Handlebars.Compile(item.Content);
//            var inputVariablesXX = this.PromptTemplateCollectionVariables;
//            result = handlebarsTemplate(inputVariablesXX);
//            inputCollection.Add(result, item.Role);
//        }

//        foreach (var item in inputCollection.Templates)
//        {
//            handlebarsTemplate = Handlebars.Compile(item.Content);
//            result = handlebarsTemplate(this.PromptTemplateCollectionVariables);
//            newInputCollection.Add(result, item.Role);
//        }
//        return newInputCollection;
//    }


//    /// <summary>
//    /// This will add a new input to the PromptTemplateCollection
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="role"></param>
//    public ChatCompletionPromptTemplate AddPromptTemplateMessage(string input, string role)
//    {
//        var roleToUse = ChatCompletionPromptTemplateMessageRoles.NewFromString(role);

//        this.PromptTemplateCollection.Add(input, roleToUse);

//        return this;
//    }



//    /// <summary>
//    /// This will add a new input to the PromptTemplateCollection
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="messageRole"></param>
//    public ChatCompletionPromptTemplate AddPromptTemplateMessage(string input, ChatCompletionPromptTemplateMessageRoles messageRole)
//    {
//        this.PromptTemplateCollection.Add(input, messageRole);

//        return this;
//    }

//    /// <summary>
//    /// This will add a new message to the prompt template message collection.
//    /// </summary>
//    /// <param name="content">The content of the message to add.</param>
//    /// <param name="role">The role to use for the message</param>
//    public ChatCompletionPromptTemplate Add(string content, string role)
//    {
//        var messageRole = ChatCompletionPromptTemplateMessageRoles.NewFromString(role);

//        this.PromptTemplateCollection.Add(content, messageRole);
        
//        return this;
//    }

//    /// <summary>
//    /// This will add a new message to the prompt template message collection.
//    /// The role will default to the user role.
//    /// </summary>
//    /// <param name="content">The content of the message to add.</param>
//    public ChatCompletionPromptTemplate Add(string content)
//    {
//        var messageRole = ChatCompletionPromptTemplateMessageRoles.NewAsUser();

//        this.PromptTemplateCollection.Add(content, messageRole);

//        return this;
//    }
    

//    /// <summary>
//    /// This will return the PromptStringCollection
//    /// </summary>
//    /// <returns></returns>
//    public ChatCompletionPromptTemplateMessageCollection GetPromptStrings()
//    {
//        return this.PromptTemplateCollection;
//    }

    
//    /// <summary>
//    /// This will add a new input to the input variables.
//    /// </summary>
//    /// <param name="key"></param>
//    /// <param name="value"></param>
//    public ChatCompletionPromptTemplate AddPromptStringVariable(string key, string value)
//    {
//         this.PromptTemplateCollectionVariables.Add(key, value);

//        return this;
//    }


//    /// <summary>
//    /// This will add a new input to the input variables.
//    /// </summary>
//    /// <param name="inputVariables"></param>
//    public ChatCompletionPromptTemplate AddPromptStringVariables(Dictionary<string, string>? inputVariables)
//    {
//        if(inputVariables == null) return this;

//        foreach (var item in inputVariables)
//        {
//            this.PromptTemplateCollectionVariables.Add(item.Key, item.Value);
//        }

//        return this;

//    }

//    /// <summary>
//    /// This will clear the PromptTemplateCollectionVariables
//    /// </summary>
//    public void ClearPromptStringVariables()
//    {
//       this.PromptTemplateCollectionVariables.Clear();
//    }

//    /// <summary>
//    /// This will clear the PromptTemplateCollectionVariables
//    /// </summary>
//    public void ClearPromptString()
//    {
//        this.PromptTemplateCollection.Clear();
//    }

//    /// <summary>
//    /// This will add a tool for the ChatCompletionPromptTemplate.
//    /// </summary>
//    /// <param name="key"></param>
//    /// <param name="value"></param>
//    public ChatCompletionPromptTemplate AddTool(ITool? tool)
//    {
//        if (tool == null)
//        {
//            throw new Exception("The tool cannot be null");
//        }

//        if(this.Tools == null)
//        {
//            this.Tools = new List<ITool>();
//        }

//        this.Tools.Add(tool);

//        return this;
//    }

//    // <summary>
//    /// This will add a tool for the ChatCompletionPromptTemplate
//    /// and force it to be called. 
//    /// </summary>
//    /// <param name="key"></param>
//    /// <param name="value"></param>
//    public ChatCompletionPromptTemplate AddToolAndForceCall(ITool? tool)
//    {
//        if (tool == null)
//        {
//            throw new Exception("The tool cannot be null");
//        }

//        if (this.Tools == null)
//        {
//            this.Tools = new List<ITool>();
//        }

//        this.Tools.Add(tool);
//        this.ForceToolCall = true;
//        return this;
//    }


//    /// <summary>
//    /// This will add a list of Tools for the ChatCompletionPromptTemplate.
//    /// </summary>
//    /// <param name="toolList"></param>
//    /// <returns></returns>
//    /// <exception cref="Exception"></exception>
//    public ChatCompletionPromptTemplate AddTools(List<ITool>? toolList)
//    {
//       if(toolList == null)
//        {
//            toolList = new List<ITool>();
//        }

//        if (this.Tools == null)
//        {
//            this.Tools = new List<ITool>();
//        }

//        foreach (var item in toolList)
//        {
//            this.Tools.Add(item);
//        }

//        return this;
//    }


//    // <summary>
//    /// This will clear the Tools from the ChatCompletionPromptTemplate.
//    /// </summary>
//    /// <param name="key"></param>
//    /// <param name="value"></param>
//    public ChatCompletionPromptTemplate ClearTools()
//    {

//        if (this.Tools != null)
//        {
//            this.Tools.Clear();
//        }

       
//        return this;
//    }


//    // <summary>
//    /// This will remove a tool from the ChatCompletionPromptTemplate.
//    /// </summary>
//    /// <param name="key"></param>
//    /// <param name="value"></param>
//    public ChatCompletionPromptTemplate RemoveTool(ITool? tool)
//    {
//        if (tool == null)
//        {
//            throw new Exception("The tool cannot be null");
//        }

//        if (this.Tools != null)
//        {
//            this.Tools.Remove(tool);
//        }

//        return this;
//    }



//    /// <summary>
//    /// This will check that the place holders in the messageCollection strings are available in the template variables,
//    /// if not it will throw an exception
//    /// </summary>
//    /// <param name="messageCollection"></param>
//    /// <param name="inputVariables"></param>
//    /// <exception cref="Exception"></exception>
//    private void CheckPlaceHoldersAreAlsoInInputVariables(ChatCompletionPromptTemplateMessageCollection messageCollection, Dictionary<string, string> inputVariables)
//    {
//        var inputList = messageCollection.GetInputList();

//        foreach (var item in inputList)
//        {

//            var stringTemplatePlaceHolderList = GetVerablePlaceholdersFromStringTemplate(item.Content);

//            foreach (var variable in stringTemplatePlaceHolderList)
//            {
//                if (inputVariables != null)
//                {
//                    if (!inputVariables.ContainsKey(variable))
//                    {
//                        throw new Exception($"The following '{variable}' could not be found in templateVariables");
//                    }
//                }
//                else
//                {
//                    throw new Exception($"The following '{variable}' could not be found in templateVariables");

//                }
//            }

//        }
//    }


//    /// <summary>
//    ///  This function will extract the verable place holders from the  string template.
//    /// </summary>
//    /// <param name="stringTemplate">The string template to search for variable placeholders.</param>
//    /// <returns>A list verable placeholders found in string template</returns>
//    private List<string> GetVerablePlaceholdersFromStringTemplate(string stringTemplate)
//    {

//        var variablePlaceholderList = new List<string>();
//        var regex = new Regex(@"{(\w+(-\w+)*)}");
//        var matches = regex.Matches(stringTemplate);
//        var workVariable = "";

//        foreach (Match match in matches)
//        {
//            workVariable = match.Value.Replace("{", "").Replace("}", "");
//            if (!variablePlaceholderList.Contains(workVariable))
//            {
//                variablePlaceholderList.Add(workVariable);
//            }

//        }

//        return variablePlaceholderList;
//    }


//}
