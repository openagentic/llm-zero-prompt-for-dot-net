

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;


public class ChatCompletionTemplateMessageCollectionV2
{


    public List<ChatCompletionTemplateMessageV2> Messages { get; set; }


    /// <summary>
    /// Constructor for the ChatCompletionTemplateMessageCollectionV2 class.
    /// </summary>
    /// <param name="input"></param>
    public ChatCompletionTemplateMessageCollectionV2()
    {
        this.Messages = new List<ChatCompletionTemplateMessageV2>();

    }

    /// <summary>
    /// Constructor for the ChatCompletionTemplateMessageCollectionV2 class.
    /// </summary>
    /// <param name="input"></param>
    public ChatCompletionTemplateMessageCollectionV2(string input)
    {
        this.Messages = new List<ChatCompletionTemplateMessageV2>();

    }

    /// <summary>
    /// Constructor for the ChatCompletionTemplateMessageCollectionV2 class.
    /// </summary>
    /// <param name="message"></param>

    public ChatCompletionTemplateMessageCollectionV2(ChatCompletionTemplateMessageV2 message)
    {
        this.Messages = new List<ChatCompletionTemplateMessageV2>();
        this.Messages.Add(message);
    }


    /// <summary>
    /// Constructor for the ChatCompletionTemplateMessageCollectionV2 class.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="messageRole"></param>
    public ChatCompletionTemplateMessageCollectionV2(string input, ChatCompletionTemplateMessageRolesV2 messageRole)
    {
        this.Messages = new List<ChatCompletionTemplateMessageV2>();
        this.Messages.Add(ChatCompletionTemplateMessageV2.New(input, messageRole));

    }

    /// <summary>
    /// This method returns a new instance of PromptTemplateInput.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageCollectionV2 New()
    {
        return new ChatCompletionTemplateMessageCollectionV2();
    }

    /// <summary>
    /// This method returns a new instance of PromptTemplateInput.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageCollectionV2 New(string input)
    {
        return new ChatCompletionTemplateMessageCollectionV2(input);
    }

    /// <summary>
    /// This method returns a new instance of PromptTemplateInput.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="messageRole"></param>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageCollectionV2 New(string input, ChatCompletionTemplateMessageRolesV2 messageRole)
    {
        return new ChatCompletionTemplateMessageCollectionV2(input, messageRole);
    }

    /// <summary>
    /// This method adds a new message to the message list.
    /// </summary>
    /// <param name="input"></param>
    public void Add(string input)
    {
        var promptTemplateRolesToAdd = ChatCompletionTemplateMessageV2.New(input);
        this.Messages.Add(promptTemplateRolesToAdd);
    }

    /// <summary>
    /// This method adds a new message to the message list.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="messageRole"></param>
    public void Add(string input, ChatCompletionTemplateMessageRolesV2 messageRole)
    {
        var promptTemplateRolesToAdd = ChatCompletionTemplateMessageV2.New(input, messageRole);
        this.Messages.Add(promptTemplateRolesToAdd);
    }

    /// <summary>
    /// This method adds a new message to the message list.
    /// </summary>
    /// <param name="message"></param>
    public void Add(ChatCompletionTemplateMessageV2 message)
    {
        this.Messages.Add(message);
    }


    /// <summary>
    /// This method clears the message list.
    /// </summary>
    public void Clear()
    {
        this.Messages.Clear();
    }

    /// <summary>
    /// This method returns the count of the message list.
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return this.Messages.Count;
    }


    /// <summary>
    /// This method returns the list the message list.
    /// </summary>
    /// <returns></returns>
    public List<ChatCompletionTemplateMessageV2> GetInputList()
    {
        return this.Messages;
    }
}
