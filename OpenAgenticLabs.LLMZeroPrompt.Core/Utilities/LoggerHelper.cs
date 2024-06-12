using Microsoft.Extensions.Logging;




namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;





/// <summary>
/// Provides logging functionality at various levels throughout an application.
/// </summary>
public static class LoggerHelper
{
    /// <summary>
    /// Logs critical level messages and associated exceptions.
    /// </summary>
    /// <param name="logger">The logger interface to use for logging.</param>
    /// <param name="ex">The exception associated with the critical log.</param>
    /// <param name="message">The message to log.</param>
    public static void LogCritical(ILogger logger, Exception ex, string message)
    {
        logger?.LogCritical(ex, message);
    }

    /// <summary>
    /// Logs error level messages and associated exceptions.
    /// </summary>
    /// <param name="logger">The logger interface to use for logging.</param>
    /// <param name="ex">The exception to log at error level.</param>
    /// <param name="message">The error message to log.</param>
    public static void LogError(ILogger logger, Exception ex, string message)
    {
        logger?.LogError(ex, message);
    }

    /// <summary>
    /// Logs warnings in the application.
    /// </summary>
    /// <param name="logger">The logger interface to use for logging.</param>
    /// <param name="message">The warning message to log.</param>
    public static void LogWarning(ILogger logger, string message)
    {
        logger?.LogWarning(message);
    }

    /// <summary>
    /// Logs informational messages.
    /// </summary>
    /// <param name="logger">The logger interface to use for logging.</param>
    /// <param name="message">The information message to log.</param>
    public static void LogInformation(ILogger logger, string message)
    {
        logger?.LogInformation(message);
    }

    /// <summary>
    /// Logs debug information.
    /// </summary>
    /// <param name="logger">The logger interface to use for logging.</param>
    /// <param name="message">The debug message to log.</param>
    public static void LogDebug(ILogger logger, string message)
    {
        logger?.LogDebug(message);
    }
}

