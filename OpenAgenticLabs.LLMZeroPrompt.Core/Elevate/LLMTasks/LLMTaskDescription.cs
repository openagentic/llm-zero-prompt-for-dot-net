using HandlebarsDotNet;
using System.Collections;
using System.Text;



namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


/// <summary>
/// The LLM task description provides key information, context and
/// formatting for the generation of a prompt for an LLM. The key information provided
/// are the inputs that describe for the LLM the format, the context of each
/// input. Outputs, the context of each output, and its format. And context
/// what the inputs and outputs mean to each other and the context
/// they are been used in. Examples then hemp provide the LLM
/// with deeper understanding to fine tune its response. 
/// </summary>
public class LLMTaskDescription<TInp, TOut> : ILLMTaskDescription<TInp, TOut>

{

    /// <summary>
    /// This is the name given to the Task.
    /// be used
    /// </summary>
    public string Name { get; init; }


    /// <summary>
    /// Outputs define for the LLM what we expect as an output and the format.
    /// For example, we require and 'answer' as a sentence. This helps to
    /// ensure that the LLM understands what the expected output is.
    /// </summary>
    public TInp Input { get; init; }

    /// <summary>
    /// Outputs define for the LLM what we expect as an output and the format.
    /// For example, we require and 'answer' as a sentence. This helps to
    /// ensure that the LLM understands what the expected output is.
    /// </summary>
    public TOut Output { get; init; }


    ///// <summary>
    ///// Outputs define for the LLM what we expect as an output and the format.
    ///// For example, we require and 'answer' as a sentence. This helps to
    ///// ensure that the LLM understands what the expected output is.
    ///// </summary>
    //public TOut Output { get; init; }


    /// <summary>
    /// Context provides a deeper understanding of the inputs and outputs,
    /// for the LLM and the context used to help frame what the LLM response
    /// should be.
    /// </summary>
    public string Context { get; init; }
    
    
    
    /// <summary>
    /// Examples provides a way to show the LLM by teaching it with examples of
    /// the output we require and the format.
    /// </summary>
    public string Examples { get; init; }


    /// <summary>
    /// 
    /// </summary>
    public string Template { get; init; }

    /// <summary>
    /// When summarizing, this can be sued to define the number of words to return.
    /// </summary>
    public int? NumberOfWordsToReturnForSummery { get; private set; }




    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <param name="context"></param>
    /// <param name="examples"></param>
    /// <param name="template"></param>
    /// <exception cref="ArgumentException"></exception>
    public LLMTaskDescription(string name,TInp input, TOut output, string context, string examples, string template, int? numberOfWordsToReturnForSummery = null)
    {

        if (string.IsNullOrEmpty(name)) throw new ArgumentException("name argument is null or empty.");
        if (string.IsNullOrWhiteSpace(name) == true) throw new ArgumentException("name is null or whitespace.");
        //if (string.IsNullOrEmpty(context)) throw new ArgumentException("description argument is null or empty.");
        //if (string.IsNullOrWhiteSpace(context) == true) throw new ArgumentException("description is null or whitespace.");
        

        Name = name;
        Input = input;
        Output = output;
        Context = context;
        Examples = examples;
        Template = template;
        NumberOfWordsToReturnForSummery = numberOfWordsToReturnForSummery;
    }


    public string BuildPrompt()
    {

        dynamic input = (TInp)Input;
        dynamic output = (TOut)Output;
        
        var template = Handlebars.Compile(Template);
        var dict = new Dictionary<string, string>();

        if(NumberOfWordsToReturnForSummery is null) NumberOfWordsToReturnForSummery = 10;
        
        
        dict.Add("InputTag", input.Tag);
        dict.Add("OutputTag", output.Tag);
        dict.Add("Context", Context);
        dict.Add("Format", BuildFormat());
        dict.Add("Examples", Examples);
        dict.Add("Action", input.Value);
        dict.Add("NumberOfWords", NumberOfWordsToReturnForSummery.ToString());
        var result = template(dict);

        return result;
    }


    public string BuildFormat()
    {

        dynamic input = (TInp)Input;
        dynamic output = (TOut)Output;

        StringBuilder sb = new StringBuilder();


        sb.AppendLine("");
        sb.Append("<");
        sb.Append(input.Tag);
        sb.Append(">");
        sb.Append(" ");
        sb.Append(":");
        sb.Append(" ");
        sb.Append(input.Description);
        sb.AppendLine(".");
        sb.Append("<");
        sb.Append(output.Tag);
        sb.Append(">");
        sb.Append(" ");
        sb.Append(":");
        sb.Append(" ");
        sb.Append(output.Description);
  

        return sb.ToString();
    }




    private string GetSignature()
    {

        if ((IsInputACollection() == false) && (IsOutputACollection() == false)) return GetAsInpOutNotCollection();
        if ((IsInputACollection() == true) && (IsOutputACollection() == false)) return GetInpCollectionOutNotCollection();
        if ((IsInputACollection() == false) && (IsOutputACollection() == true)) return GetInpNotCollectionOutCollection();
        if ((IsInputACollection() == true) && (IsOutputACollection() == true)) return GetInpCollectionOutCollection();


        throw new Exception("Invalid signature been.");

    }



    
    private string GetAsInpOutNotCollection()
    {
        dynamic input = (TInp)Input;
        dynamic output = (TOut)Output;

        StringBuilder sb = new StringBuilder();
        sb.Append("Given the field ");
        sb.Append("<");
        sb.Append(input.Tag);
        sb.Append(">");
        sb.Append(",");
        sb.Append(" ");
        sb.Append("produce the field");
        sb.Append(" ");
        sb.Append("<");
        sb.Append(output.Tag);
        sb.Append(">");
        sb.Append(".");
        sb.AppendLine();
        return sb.ToString();
    }


    private string GetInpCollectionOutNotCollection()
    {
        //StringBuilder sb = new StringBuilder();

        //int counter = 0;
        //int outputCount = Outputs.Count;
        //foreach (var output in Outputs)
        //{

        //    sb.Append("<");
        //    sb.Append(output.Name);
        //    sb.Append("<");
        //    if (counter < outputCount)
        //    {
        //        sb.Append(", ");
        //    }
        //    else
        //    {
        //        sb.Append(" ");
        //    }
        //    counter++;
        //}

        //return sb.ToString();

        return "";
    }


    private string GetInpNotCollectionOutCollection()
    {
        //StringBuilder sb = new StringBuilder();

        //int counter = 0;
        //int outputCount = Outputs.Count;
        //foreach (var output in Outputs)
        //{

        //    sb.Append("<");
        //    sb.Append(output.Name);
        //    sb.Append("<");
        //    if (counter < outputCount)
        //    {
        //        sb.Append(", ");
        //    }
        //    else
        //    {
        //        sb.Append(" ");
        //    }
        //    counter++;
        //}

        //return sb.ToString();

        return "";
    }

    private string GetInpCollectionOutCollection()
    {
        //StringBuilder sb = new StringBuilder();

        //int counter = 0;
        //int outputCount = Outputs.Count;
        //foreach (var output in Outputs)
        //{

        //    sb.Append("<");
        //    sb.Append(output.Name);
        //    sb.Append("<");
        //    if (counter < outputCount)
        //    {
        //        sb.Append(", ");
        //    }
        //    else
        //    {
        //        sb.Append(" ");
        //    }
        //    counter++;
        //}

        //return sb.ToString();

        return "";
    }
    

    
    public bool IsInputACollection()
    {
        return typeof(TInp).IsArray ||
               typeof(TInp).IsAssignableTo(typeof(ICollection)) ||
               typeof(TInp).IsAssignableTo(typeof(IEnumerable));
    }

    public bool IsOutputACollection()
    {
        return typeof(TOut).IsArray ||
               typeof(TOut).IsAssignableTo(typeof(ICollection)) ||
               typeof(TOut).IsAssignableTo(typeof(IEnumerable));
    }

}







