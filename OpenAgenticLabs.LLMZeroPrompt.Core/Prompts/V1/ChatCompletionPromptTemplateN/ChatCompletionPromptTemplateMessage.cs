


//namespace OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.ChatCompletionTemplateN;

///// <summary>
///// This is the class for prompt template content.
///// </summary>
//public class ChatCompletionPromptTemplateMessage  
//{

//    /// <summary>
//    /// This is the string content to be used.
//    /// </summary>
//    public string Content { get; }

//    /// <summary>
//    /// This is the role to use. 
//    /// </summary>
//    public ChatCompletionPromptTemplateMessageRoles Role { get; }

//    /// <summary>
//    /// This is the role to use. 
//    /// </summary>
//    public ChatCompletionPromptTemplateMessageFunctionCall? FunctionCall { get; }
    
    
//    /// <summary>
//    /// Constructor for the PromptTemplateInput class.
//    /// </summary>
//    /// <param name="input"></param>
//    public ChatCompletionPromptTemplateMessage()
//    {
//        this.Content = string.Empty;
//        this.Role = ChatCompletionPromptTemplateMessageRoles.New(ChatCompletionPromptTemplateMessageRoles.Roles.NONE);
//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInput class.
//    /// </summary>
//    /// <param name="content"></param>
//    public ChatCompletionPromptTemplateMessage(string content)
//    {
//        this.Content = content;
//        this.Role = ChatCompletionPromptTemplateMessageRoles.New(ChatCompletionPromptTemplateMessageRoles.Roles.NONE);
//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInput class.
//    /// </summary>
//    /// <param name="content"></param>
//    /// <param name="role"></param>
//    public ChatCompletionPromptTemplateMessage(string content, ChatCompletionPromptTemplateMessageRoles role)
//    {
//        this.Content = content;
//        this.Role = role;
//    }

//    /// <summary>
//    /// Calling this static method will create a new instance of PromptTemplateInput. 
//    /// </summary>
//    /// <param name="input"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessage New() 
//    {
//        return new ChatCompletionPromptTemplateMessage();

//    }

//    /// <summary>
//    /// Calling this static method will create a new instance of PromptTemplateInput. 
//    /// </summary>
//    /// <param name="input"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessage New(string input)
//    {
//        return new ChatCompletionPromptTemplateMessage(input);
//    }

//    /// <summary>
//    /// Calling this static method will create a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="messageRole"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessage New(string input, ChatCompletionPromptTemplateMessageRoles messageRole)
//    {
//       return new ChatCompletionPromptTemplateMessage(input, messageRole);
//    }

//}
