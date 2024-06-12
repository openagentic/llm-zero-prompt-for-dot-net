namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.Models;


/// <summary>
/// These are the model name for GP4 and GPT-4 Turbo.
/// </summary>
public static class GPT4andGP4TurboModels
{
    /// <summary>
    /// The latest GPT-4 model intended to reduce cases of “laziness” where the model doesn’t complete a task.Returns a maximum of 4,096 output tokens. Learn more.
    /// </summary>
    public const string GPT40125Preview = "gpt-4-0125-preview";

    /// <summary>
    /// TCurrently points to gpt-4-0125-preview.
    /// </summary>
    public const string Gpt4TurboPreview = "gpt-4-turbo-preview";

    /// <summary>
    /// GPGPT-4 Turbo model featuring improved instruction following, JSON mode, reproducible outputs, parallel function calling, and more. Returns a maximum of 4,096 output tokens. This is a preview model.
    /// </summary>
    public const string Gpt41106Preview = "gpt-4-1106-preview";

    /// <summary>
    /// 
    /// </summary>
    public const string Gpt4VisionPreview = "gpt-4-vision-preview";

    /// <summary>
    /// GPT-4 with the ability to understand images, in addition to all other GPT-4 Turbo capabilities. Returns a maximum of 4,096 output tokens. This is a preview model version.
    /// </summary>
    public const string Gpt41106VisionPreview = "gpt-4-1106-vision-preview";

    /// <summary>
    /// Currently points to gpt-4-0613.
    /// </summary>
    public const string Gpt4 = "gpt-4";

    /// <summary>
    /// Snapshot of gpt-4 from June 13th 2023 with improved function calling support.
    /// </summary>
    public const string Gpt40613 = "gpt-4-0613";

    /// <summary>
    /// The latest GPT-4 model intended to reduce cases of “laziness” where the model doesn’t complete a task.Returns a maximum of 4,096 output tokens. Learn more.
    /// </summary>
    public const string Gpt432k = "gpt-4-32k";

    /// <summary>
    /// Currently points to gpt-4-32k-0613. See continuous model upgrades. This model was never rolled out widely in favor of GPT-4 Turbo.
    /// </summary>
    public const string Gpt432k0613 = "gpt-4-32k-0613";


}
