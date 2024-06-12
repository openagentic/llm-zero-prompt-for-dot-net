using Microsoft.Extensions.Logging;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;



/// <summary>
/// This is an extension to the exception class that allows for logging of argument exceptions.
/// </summary>
public class ExceptionExt : Exception
{
    public ExceptionExt(string message, ILogger? logger = null) : base(message)
    {
        if (logger != null)
        {
            logger.LogCritical(message, this);
        }
    }
}


/// <summary>
/// This is an extension to the exception class that allows for logging of argument exceptions.
/// </summary>
public class NullReferenceExceptionExt : NullReferenceException
{
    public NullReferenceExceptionExt(string message, ILogger? logger = null) : base(message)
    {
        if (logger != null)
        {
            logger.LogCritical(message, this);
        }
    }
}

/// <summary>
/// This is an extension to the exception class that allows for logging of argument exceptions.
/// </summary>
public class ArgumentExceptionExt : ArgumentException
{
    ArgumentExceptionExt(string message, ILogger? logger = null) : base(message)
    {
        if (logger != null)
        {
            logger.LogCritical(message, this);
        }
    }

}

