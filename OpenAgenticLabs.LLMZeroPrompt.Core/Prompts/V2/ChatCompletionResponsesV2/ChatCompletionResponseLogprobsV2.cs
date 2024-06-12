

namespace OpenAgenticLabs.LLMZeroPrompt.Core.Prompts.ChatCompletionV2;




public class ChatCompletionResponseLogprobsV2 
{

    public List<string> Tokens { get; set; }
    public List<double?> TokenLogprobs { get; set; }
    public List<Dictionary<string, double>> TopLogprobs { get; set; }
    public List<int?> TextOffset { get; set; }


}

