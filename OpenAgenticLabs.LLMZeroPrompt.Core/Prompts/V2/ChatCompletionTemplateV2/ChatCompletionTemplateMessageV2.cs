


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;

/// <summary>
/// This is the class for prompt template content.
/// </summary>
public class ChatCompletionTemplateMessageV2
{

    /// <summary>
    /// This is the string content to be used.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// This is the role to use. 
    /// </summary>
    public ChatCompletionTemplateMessageRolesV2 Role { get; }

    /// <summary>
    /// This is the role to use. 
    /// </summary>
    public ChatCompletionTemplateMessageFunctionCallV2? FunctionCall { get; }
    
    
    /// <summary>
    /// Constructor for the PromptTemplateInput class.
    /// </summary>
    /// <param name="input"></param>
    public ChatCompletionTemplateMessageV2()
    {
        this.Content = string.Empty;
        this.Role = ChatCompletionTemplateMessageRolesV2.New(ChatCompletionTemplateMessageRolesV2.Roles.NONE);
    }

    /// <summary>
    /// Constructor for the PromptTemplateInput class.
    /// </summary>
    /// <param name="content"></param>
    public ChatCompletionTemplateMessageV2(string content)
    {
        this.Content = content;
        this.Role = ChatCompletionTemplateMessageRolesV2.New(ChatCompletionTemplateMessageRolesV2.Roles.NONE);
    }

    /// <summary>
    /// Constructor for the PromptTemplateInput class.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="role"></param>
    public ChatCompletionTemplateMessageV2(string content, ChatCompletionTemplateMessageRolesV2 role)
    {
        this.Content = content;
        this.Role = role;
    }

    /// <summary>
    /// Calling this static method will create a new instance of PromptTemplateInput. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageV2 New() 
    {
        return new ChatCompletionTemplateMessageV2();

    }

    /// <summary>
    /// Calling this static method will create a new instance of PromptTemplateInput. 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageV2 New(string input)
    {
        return new ChatCompletionTemplateMessageV2(input);
    }

    /// <summary>
    /// Calling this static method will create a new instance of PromptTemplateInput.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="messageRole"></param>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageV2 New(string input, ChatCompletionTemplateMessageRolesV2 messageRole)
    {
       return new ChatCompletionTemplateMessageV2(input, messageRole);
    }

}
