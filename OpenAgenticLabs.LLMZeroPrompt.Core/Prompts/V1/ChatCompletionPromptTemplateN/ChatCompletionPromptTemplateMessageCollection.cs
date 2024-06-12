

//namespace OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.ChatCompletionTemplateN;


//public class ChatCompletionPromptTemplateMessageCollection
//{


//    public List<ChatCompletionPromptTemplateMessage> Templates { get; set; }


//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
//    public ChatCompletionPromptTemplateMessageCollection()
//    {
//        this.Templates = new List<ChatCompletionPromptTemplateMessage>();

//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
//    public ChatCompletionPromptTemplateMessageCollection(string input)
//    {
//        this.Templates = new List<ChatCompletionPromptTemplateMessage>();

//    }

//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="message"></param>

//    public ChatCompletionPromptTemplateMessageCollection(ChatCompletionPromptTemplateMessage message)
//    {
//        this.Templates = new List<ChatCompletionPromptTemplateMessage>();
//        this.Templates.Add(message);
//    }


//    /// <summary>
//    /// Constructor for the PromptTemplateInputCollection class.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="messageRole"></param>
//    public ChatCompletionPromptTemplateMessageCollection(string input, ChatCompletionPromptTemplateMessageRoles messageRole)
//    {
//        this.Templates = new List<ChatCompletionPromptTemplateMessage>();
//        this.Templates.Add(ChatCompletionPromptTemplateMessage.New(input, messageRole));

//    }

//    /// <summary>
//    /// This method returns a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageCollection New()
//    {
//        return new ChatCompletionPromptTemplateMessageCollection();
//    }

//    /// <summary>
//    /// This method returns a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageCollection New(string input)
//    {
//        return new ChatCompletionPromptTemplateMessageCollection(input);
//    }

//    /// <summary>
//    /// This method returns a new instance of PromptTemplateInput.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="messageRole"></param>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageCollection New(string input, ChatCompletionPromptTemplateMessageRoles messageRole)
//    {
//        return new ChatCompletionPromptTemplateMessageCollection(input, messageRole);
//    }

//    /// <summary>
//    /// This method adds a new message to the message list.
//    /// </summary>
//    /// <param name="input"></param>
//    public void Add(string input)
//    {
//        var promptTemplateRolesToAdd = ChatCompletionPromptTemplateMessage.New(input);
//        this.Templates.Add(promptTemplateRolesToAdd);
//    }

//    /// <summary>
//    /// This method adds a new message to the message list.
//    /// </summary>
//    /// <param name="input"></param>
//    /// <param name="messageRole"></param>
//    public void Add(string input, ChatCompletionPromptTemplateMessageRoles messageRole)
//    {
//        var promptTemplateRolesToAdd = ChatCompletionPromptTemplateMessage.New(input, messageRole);
//        this.Templates.Add(promptTemplateRolesToAdd);
//    }

//    /// <summary>
//    /// This method adds a new message to the message list.
//    /// </summary>
//    /// <param name="message"></param>
//    public void Add(ChatCompletionPromptTemplateMessage message)
//    {
//        this.Templates.Add(message);
//    }


//    /// <summary>
//    /// This method clears the message list.
//    /// </summary>
//    public void Clear()
//    {
//        this.Templates.Clear();
//    }

//    /// <summary>
//    /// This method returns the count of the message list.
//    /// </summary>
//    /// <returns></returns>
//    public int Count()
//    {
//        return this.Templates.Count;
//    }


//    /// <summary>
//    /// This method returns the list the message list.
//    /// </summary>
//    /// <returns></returns>
//    public List<ChatCompletionPromptTemplateMessage> GetInputList()
//    {
//        return this.Templates;
//    }
//}
