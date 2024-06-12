using HandlebarsDotNet;
using System.Text.RegularExpressions;
using OpenAgenticLabs.LLMZeroPrompt.Core.ChainsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;


/// <summary>
/// 
/// </summary>
public class ChatCompletionTemplateV2 : IChatCompletionTemplateV2
{
    private readonly Dictionary<string, string>? _chatCompletionTemplateMessageVariables;
    private readonly ChatCompletionTemplateMessageCollectionV2 _chatCompletionTemplateMessageCollection;
    private readonly IChain? _nextItemInChain;

    
    /// <summary>
    ///  This is the constructor for the ChatCompletionPromptTemplate class.
    /// </summary>
    public ChatCompletionTemplateV2() : base()
    {

        _chatCompletionTemplateMessageCollection = new ChatCompletionTemplateMessageCollectionV2();
        _chatCompletionTemplateMessageVariables = new Dictionary<string, string>();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    public ChatCompletionTemplateV2(string input) : base()
    {
        _chatCompletionTemplateMessageCollection = new ChatCompletionTemplateMessageCollectionV2(input);
        _chatCompletionTemplateMessageVariables = new Dictionary<string, string>();


    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="inputVariables"></param>
    public ChatCompletionTemplateV2(string input, Dictionary<string, string> inputVariables) : base()
    {
        _chatCompletionTemplateMessageCollection = new ChatCompletionTemplateMessageCollectionV2(input);
        _chatCompletionTemplateMessageVariables = inputVariables;

    }


    /// <summary>
    /// This will preform a build and return GetMessageCollection.
    /// Build is where any variables are injected to the messages.
    /// </summary>
    /// <param name="inputVariables"></param>
    /// <returns>Used the  object to return Collection of messages</returns>
    public virtual OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string>  GetMessageCollection(Dictionary<string, string> inputVariables)
    {
        try
        {
            CheckPlaceHoldersAreAlsoInInputVariables(this._chatCompletionTemplateMessageCollection, inputVariables);

            HandlebarsTemplate<object, object> handlebarsTemplate;
            string result;
            var inputCollection = ChatCompletionTemplateMessageCollectionV2.New();
            var newInputCollection = ChatCompletionTemplateMessageCollectionV2.New();

            foreach (var item in this._chatCompletionTemplateMessageCollection.GetInputList())
            {
                handlebarsTemplate = Handlebars.Compile(item.Content);
                result = handlebarsTemplate(inputVariables);
                inputCollection.Add(result, item.Role);
            }

            foreach (var item in inputCollection.Messages)
            {
                handlebarsTemplate = Handlebars.Compile(item.Content);
                result = handlebarsTemplate(this._chatCompletionTemplateMessageVariables);
                newInputCollection.Add(result, item.Role);
            }

           return OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string>.Success(newInputCollection);

        }
        catch (Exception ex)
        {
            return OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string>.Failure(ex.Message, ex);
        }
      
    }



    /// <summary>
    /// This will preform a build and return GetMessageCollection.
    /// Build is where any variables are injected to the messages.
    /// </summary>
    /// <returns>Used the  object to return Collection of messages</returns>
    public virtual OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string> GetMessageCollection()
    {

        try
        {

            CheckPlaceHoldersAreAlsoInInputVariables(_chatCompletionTemplateMessageCollection, _chatCompletionTemplateMessageVariables);

            HandlebarsTemplate<object, object> handlebarsTemplate;
            string result;
            var inputCollection = ChatCompletionTemplateMessageCollectionV2.New();
            var newInputCollection = ChatCompletionTemplateMessageCollectionV2.New();

            var inputList = this._chatCompletionTemplateMessageCollection.GetInputList();
            foreach (var item in inputList)
            {
                handlebarsTemplate = Handlebars.Compile(item.Content);
                var inputVariablesXX = this._chatCompletionTemplateMessageVariables;
                result = handlebarsTemplate(inputVariablesXX);
                inputCollection.Add(result, item.Role);
            }

            foreach (var item in inputCollection.Messages)
            {
                handlebarsTemplate = Handlebars.Compile(item.Content);
                result = handlebarsTemplate(this._chatCompletionTemplateMessageVariables);
                newInputCollection.Add(result, item.Role);
            }

            return OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string>.Success(newInputCollection);

        }
        catch (Exception ex)
        {
            return OperationResult<ChatCompletionTemplateMessageCollectionV2, string, string>.Failure(ex.Message, ex);
        }

    }


    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessage(string content, string role)
    {
        try
        {
            var roleToUse = ChatCompletionTemplateMessageRolesV2.NewFromString(role);

            _chatCompletionTemplateMessageCollection.Add(content, roleToUse);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }

     
    }

    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection and use the User role.
    /// </summary>
    /// <param name="content">The context is the text that will be sent to the large language model.</param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessageAsUser(string content)
    {
        try
        {
            var roleToUse = ChatCompletionTemplateMessageRolesV2.NewAsUser();

            _chatCompletionTemplateMessageCollection.Add(content, roleToUse);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }


    }

    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection and use the Assistant role.
    /// </summary>
    /// <param name="content">The context is the text that will be sent to the large language model.</param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessageAsAssistant(string content)
    {
        try
        {
            var roleToUse = ChatCompletionTemplateMessageRolesV2.NewAsAssistant();

            _chatCompletionTemplateMessageCollection.Add(content, roleToUse);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }

    }

    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection and use the Function role.
    /// </summary>
    /// <param name="content">The context is the text that will be sent to the large language model.</param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessageAsFunction(string content)
    {
        try
        {
            var roleToUse = ChatCompletionTemplateMessageRolesV2.NewAsFunction();

            _chatCompletionTemplateMessageCollection.Add(content, roleToUse);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }

    }


    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection and use the System role.
    /// </summary>
    /// <param name="content">The context is the text that will be sent to the large language model.</param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessageAsSystem(string content)
    {
        try
        {
            var roleToUse = ChatCompletionTemplateMessageRolesV2.NewAsSystem();

            _chatCompletionTemplateMessageCollection.Add(content, roleToUse);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }


    }


    /// <summary>
    /// Invoking this will add a new message to the ChatCompletionTemplate message collection.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public OperationResult<bool, string, string> AddMessages(string content, ChatCompletionTemplateMessageRolesV2 role)
    {
        try
        {

            _chatCompletionTemplateMessageCollection.Add(content, role);

            return OperationResult<bool, string, string>.Success();

        }
        catch (Exception ex)
        {
            return OperationResult<bool, string, string>.Failure(ex.Message, ex);
        }
    }

    
    /// <summary>
    /// This will return the PromptStringCollection
    /// </summary>
    /// <returns></returns>
    public ChatCompletionTemplateMessageCollectionV2 GetPromptStrings()
    {
        return _chatCompletionTemplateMessageCollection;
    }

    
    /// <summary>
    /// This will add a new input to the input variables.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public ChatCompletionTemplateV2 AddVariable(string key, string value)
    {

         _chatCompletionTemplateMessageVariables.Add(key, value);

        return this;
    }


    /// <summary>
    /// This will add a new input to the input variables.
    /// </summary>
    /// <param name="inputVariables"></param>
    public ChatCompletionTemplateV2 AddPromptStringVariables(Dictionary<string, string>? inputVariables)
    {
        if(inputVariables == null) return this;

        foreach (var item in inputVariables)
        {
            _chatCompletionTemplateMessageVariables.Add(item.Key, item.Value);
        }

        return this;

    }

    /// <summary>
    /// Invoking this method will clear the messages.
    /// </summary>
    public void ClearMessages()
    {
       _chatCompletionTemplateMessageVariables.Clear();
    }

    /// <summary>
    /// Invoking this  will clear the input variables.
    /// </summary>
    public void ClearPromptString()
    {
        _chatCompletionTemplateMessageCollection.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    public IChain Next => _nextItemInChain;

    /// <summary>
    /// This will check that the place holders in the messageCollection strings are available in the template variables,
    /// if not it will throw an exception
    /// </summary>
    /// <param name="messageCollection"></param>
    /// <param name="inputVariables"></param>
    /// <exception cref="Exception"></exception>
    private void CheckPlaceHoldersAreAlsoInInputVariables(ChatCompletionTemplateMessageCollectionV2 messageCollection, Dictionary<string, string> inputVariables)
    {
        var inputList = messageCollection.GetInputList();

        foreach (var item in inputList)
        {

            var stringTemplatePlaceHolderList = GetVariablePlaceholders(item.Content);

            foreach (var variable in stringTemplatePlaceHolderList)
            {
                if (inputVariables != null)
                {
                    if (!inputVariables.ContainsKey(variable))
                    {
                        throw new Exception($"The following '{variable}' could not be found in templateVariables");
                    }
                }
                else
                {
                    throw new Exception($"The following '{variable}' could not be found in templateVariables");

                }
            }

        }
    }


    /// <summary>
    ///  This function will extract the verable place holders from the  string template.
    /// </summary>
    /// <param name="stringTemplate">The string template to search for variable placeholders.</param>
    /// <returns>A list verable placeholders found in string template</returns>
    private List<string> GetVariablePlaceholders(string stringTemplate)
    {

        var variablePlaceholderList = new List<string>();
        var regex = new Regex(@"{(\w+(-\w+)*)}");
        var matches = regex.Matches(stringTemplate);
        var workVariable = "";

        foreach (Match match in matches)
        {
            workVariable = match.Value.Replace("{", "").Replace("}", "");
            if (!variablePlaceholderList.Contains(workVariable))
            {
                variablePlaceholderList.Add(workVariable);
            }

        }

        return variablePlaceholderList;
    }


    /// <summary>
    /// This will handle input as a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<object> InvokeRouterAsync(object input, CancellationToken cancellationToken = default)
    {

        if ((input is string) == false)
        {
            throw new ArgumentException("The input of the chain must be must be a string.");
        }

        if (_nextItemInChain is null)
        {

            return input;

        }
        else
        {
            var returnObject = await _nextItemInChain.ChainInvokeAsync(input, cancellationToken);

            return returnObject;
        }

    }

}
