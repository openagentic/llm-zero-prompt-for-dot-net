using System.Text;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


public class LLMTaskExamples
{

    public List<string> Examples { get; init; } = new();


    public LLMTaskExamples(List<string> examples)
    {
        Examples.AddRange(examples);
    }

    public LLMTaskExamples(string example)
    {
        Examples.Add(example);
    }

    public LLMTaskExamples()
    {

    }

    public void Add(string example)
    {
        Examples.Add(example);
    }

    public void Clear()
    {
        Examples.Clear();
    }

    public string GetExamplesAsString(string example)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-----------");
        sb.AppendLine();
        sb.AppendLine("Examples:");

        foreach (var item in Examples)
        {
            sb.AppendLine(item);
            sb.AppendLine();
        }

        sb.AppendLine();
        sb.AppendLine("-----------");

        return sb.ToString();
    }

}







