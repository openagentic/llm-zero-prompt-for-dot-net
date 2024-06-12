

//namespace OpenAgenticLabs.LLMZeroPrompt.Elevate.Core.PromptsN.ChatCompletionTemplateN;


///// <summary>
///// These are the roles use with chat completion.
///// If you are working with a connector that dose 
///// not use a messageRole you can ignore using or setting roles and the
///// defaults will kick in and work.
///// </summary>
//public class ChatCompletionPromptTemplateMessageRoles
//{


//    /// <summary>
//    ///  This defines the messageRole of the user.
//    /// </summary>
//    private Roles role;

//    /// <summary>
//    /// These are the roles use with chat completion.
//    /// </summary>
//    public enum Roles
//    {
//        NONE = 0,
//        USER = 1,
//        SYSTEM = 2,
//        ASSISTANT = 3,
//        FUNCTION = 4
//    }

//    /// <summary>
//    /// This is the constructor for the ChatCompletionPromptTemplateMessageRoles class.
//    /// </summary>
//    public ChatCompletionPromptTemplateMessageRoles()
//    {
//        this.role = Roles.NONE;
//    }

//    /// <summary>
//    /// This is the constructor for the ChatCompletionPromptTemplateMessageRoles class.
//    /// </summary>
//    /// <param name="role"></param>
//    public ChatCompletionPromptTemplateMessageRoles(Roles role)
//    {
//        this.role = role;
//    }

//    /// <summary>
//    /// Calling this method will create a new PromptTemplateRoles object.
//    /// </summary>
//    public static ChatCompletionPromptTemplateMessageRoles New()
//    {
//      return new ChatCompletionPromptTemplateMessageRoles();
//    }

//    /// <summary>
//    /// Calling this method will create a new PromptTemplateRoles object.
//    /// </summary>
//    /// <param name="role"></param>
//    public static ChatCompletionPromptTemplateMessageRoles New(Roles role)
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(role);
//    }

//    /// <summary>
//    /// This method will new the messageRole as user.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewAsNone()
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(Roles.NONE);
//    }

//    /// <summary>
//    /// This method will new the messageRole as user.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewAsUser()
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(Roles.USER);
//    }


//    /// <summary>
//    /// This method will new the messageRole as system.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewAsSystem()
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(Roles.SYSTEM);
//    }

//    /// <summary>
//    /// This method will new the messageRole as assistant.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewAsAssistant()
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(Roles.ASSISTANT);
//    }



//    /// <summary>
//    /// This method will new the messageRole as function.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewAsFunction()
//    {
//        return new ChatCompletionPromptTemplateMessageRoles(Roles.FUNCTION);
//    }

//    /// <summary>
//    /// This method will new the messageRole as string.
//    /// </summary>
//    /// <returns></returns>
//    public static ChatCompletionPromptTemplateMessageRoles NewFromString(string input)
//    {
//        switch (input.Trim().ToLower())
//        {
//            case "function":
//                return new ChatCompletionPromptTemplateMessageRoles(Roles.FUNCTION);
//            case "system":
//                return new ChatCompletionPromptTemplateMessageRoles(Roles.SYSTEM);
//            case "none":
//                return new ChatCompletionPromptTemplateMessageRoles(Roles.NONE);
//            case "assistant":
//                return new ChatCompletionPromptTemplateMessageRoles(Roles.ASSISTANT);
//            case "user":
//                return new ChatCompletionPromptTemplateMessageRoles(Roles.USER);

//            default:
//                throw new Exception("The messageRole is not valid");
//        }
//    }


//    /// <summary>
//    /// This method sets the messageRole.
//    /// </summary>
//    /// <param name="role"></param>
//    public Roles GetRole()
//    {
//        return this.role ;
//    }

 

//    /// <summary>
//    /// This method gets the messageRole integer.
//    /// </summary>
//    /// <returns></returns>
//    public int GetRoleAsInteger()
//    {
//        return (int) this.role;
//    }

//    /// <summary>
//    /// This will return the messageRole as a string.
//    /// </summary>
//    /// <returns></returns>
//    public string GetRoleAsString()
//    {
//        return GetRoleAsString(this.role);
//    }
//    /// <summary>
//    /// This method gets the messageRole as a string.
//    /// </summary>
//    /// <param name="role"></param>
//    /// <returns></returns>
//    /// <exception cref="Exception"></exception>
//    private string GetRoleAsString(Roles role)
//    {
//        switch (role)
//        {
//            case Roles.NONE:
//                return "NONE";
//            case Roles.USER:
//                return "USER";
//            case Roles.SYSTEM:
//                return "SYSTEM";
//            case Roles.ASSISTANT:
//                return "ASSISTANT";
//            case Roles.FUNCTION:
//                return "FUNCTION";
//            default:
//               throw new Exception("The messageRole is not valid");
//        }
//    }
//}
