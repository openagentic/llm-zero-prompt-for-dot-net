

namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Models;


/// <summary>
/// These are the model name for GP4 and GPT-4 Turbo.
/// </summary>
public static class GP3TurboModels
{
    /// <summary>
    /// The latest GPT-3.5 Turbo model with higher accuracy at responding in requested formats and a fix for a bug which caused a text encoding issue for non-English language function calls. Returns a maximum of 4,096 output tokens. Learn more.
    /// </summary>
    public const string GPT35turbo0125 = "gpt-3.5-turbo-0125";

    /// <summary>
    /// Currently points to gpt-3.5-turbo-0125..
    /// </summary>
    public const string GPT35Turbo = "gpt-3.5-turbo";

    /// <summary>
    /// GPT-3.5 Turbo model with improved instruction following, JSON mode, reproducible outputs, parallel function calling, and more. Returns a maximum of 4,096 output tokens.
    /// </summary>
    public const string GPT35Turbo1106 = "gpt-3.5-turbo-1106";

    /// <summary>
    /// Similar capabilities as GPT-3 era models. Compatible with legacy Completions endpoint and not Chat Completions.
    /// </summary>
    public const string GPT35TurboInstruct = "gpt-3.5-turbo-instruct";

    /// <summary>
    /// Currently points to gpt-3.5-turbo-16k-0613.
    /// </summary>
    public const string GPT35Turbo16K = "gpt-3.5-turbo-16k";

    /// <summary>
    /// Snapshot of gpt-3.5-turbo from June 13th 2023. Will be deprecated on June 13, 2024.
    /// </summary>
    public const string GPT35Turbo0613 = "gpt-3.5-turbo-0613";

    /// <summary>
    /// napshot of gpt-3.5-16k-turbo from June 13th 2023. Will be deprecated on June 13, 2024.
    /// </summary>
    public const string GPT35Turbo16K0613 = "gpt-3.5-turbo-16k-0613";

}
