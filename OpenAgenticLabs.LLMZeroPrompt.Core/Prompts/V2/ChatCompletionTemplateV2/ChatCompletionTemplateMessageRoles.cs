

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;


/// <summary>
/// These are the roles use with chat completion.
/// If you are working with a connector that dose 
/// not use a messageRole you can ignore using or setting roles and the
/// defaults will kick in and work.
/// </summary>
public class ChatCompletionTemplateMessageRolesV2
{


    /// <summary>
    ///  This defines the messageRole of the user.
    /// </summary>
    private Roles role;

    /// <summary>
    /// These are the roles use with chat completion.
    /// </summary>
    public enum Roles
    {
        NONE = 0,
        USER = 1,
        SYSTEM = 2,
        ASSISTANT = 3,
        FUNCTION = 4
    }

    /// <summary>
    /// This is the constructor for the ChatCompletionPromptTemplateMessageRoles class.
    /// </summary>
    public ChatCompletionTemplateMessageRolesV2()
    {
        this.role = Roles.NONE;
    }

    /// <summary>
    /// This is the constructor for the ChatCompletionPromptTemplateMessageRoles class.
    /// </summary>
    /// <param name="role"></param>
    public ChatCompletionTemplateMessageRolesV2(Roles role)
    {
        this.role = role;
    }

    /// <summary>
    /// Calling this method will create a new PromptTemplateRoles object.
    /// </summary>
    public static ChatCompletionTemplateMessageRolesV2 New()
    {
      return new ChatCompletionTemplateMessageRolesV2();
    }

    /// <summary>
    /// Calling this method will create a new PromptTemplateRoles object.
    /// </summary>
    /// <param name="role"></param>
    public static ChatCompletionTemplateMessageRolesV2 New(Roles role)
    {
        return new ChatCompletionTemplateMessageRolesV2(role);
    }

    /// <summary>
    /// This method will new the messageRole as user.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewAsNone()
    {
        return new ChatCompletionTemplateMessageRolesV2(Roles.NONE);
    }

    /// <summary>
    /// This method will new the messageRole as user.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewAsUser()
    {
        return new ChatCompletionTemplateMessageRolesV2(Roles.USER);
    }


    /// <summary>
    /// This method will new the messageRole as system.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewAsSystem()
    {
        return new ChatCompletionTemplateMessageRolesV2(Roles.SYSTEM);
    }

    /// <summary>
    /// This method will new the messageRole as assistant.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewAsAssistant()
    {
        return new ChatCompletionTemplateMessageRolesV2(Roles.ASSISTANT);
    }



    /// <summary>
    /// This method will new the messageRole as function.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewAsFunction()
    {
        return new ChatCompletionTemplateMessageRolesV2(Roles.FUNCTION);
    }

    /// <summary>
    /// This method will new the messageRole as string.
    /// </summary>
    /// <returns></returns>
    public static ChatCompletionTemplateMessageRolesV2 NewFromString(string input)
    {
        switch (input.Trim().ToLower())
        {
            case "function":
                return new ChatCompletionTemplateMessageRolesV2(Roles.FUNCTION);
            case "system":
                return new ChatCompletionTemplateMessageRolesV2(Roles.SYSTEM);
            case "none":
                return new ChatCompletionTemplateMessageRolesV2(Roles.NONE);
            case "assistant":
                return new ChatCompletionTemplateMessageRolesV2(Roles.ASSISTANT);
            case "user":
                return new ChatCompletionTemplateMessageRolesV2(Roles.USER);

            default:
                throw new Exception("The messageRole is not valid");
        }
    }


    /// <summary>
    /// This method sets the messageRole.
    /// </summary>
    /// <param name="role"></param>
    public Roles AsRole()
    {
        return this.role ;
    }

 

    /// <summary>
    /// This method gets the messageRole integer.
    /// </summary>
    /// <returns></returns>
    public int AsInteger()
    {
        return (int) this.role;
    }

    /// <summary>
    /// This will return the messageRole as a string.
    /// </summary>
    /// <returns></returns>
    public string AsString()
    {
        return GetRoleAsString(this.role);
    }
    /// <summary>
    /// This method gets the messageRole as a string.
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private string GetRoleAsString(Roles role)
    {
        switch (role)
        {
            case Roles.NONE:
                return "NONE";
            case Roles.USER:
                return "USER";
            case Roles.SYSTEM:
                return "SYSTEM";
            case Roles.ASSISTANT:
                return "ASSISTANT";
            case Roles.FUNCTION:
                return "FUNCTION";
            default:
               throw new Exception("The messageRole is not valid");
        }
    }
}
