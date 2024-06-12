using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


/// <summary>
/// 
/// </summary>
public class LLMTaskDescriptionOutput<TOut> : ILLMTaskDescriptionOutput<TOut>
{

    /// <summary>
    /// ValueType is the type required to be output.
    /// </summary>
    public Type ValueType { get; set; }
    
    
    /// <summary>
    /// This is the tag that will be used to describe the output.
    /// The tag helps the LLM understand what the output is.
    /// For example, you many have a tag like 'Question',
    /// the JetPackForAI.Elevate will form 'Question' into
    /// a tag that the LLM will understand. The default
    /// handling of the formatting of this tag is to add
    /// angular brackets so the tag end up like as HTML tag,
    /// '<Question>' as HTML is very common, LLM will
    /// have this tag meaning already learned in many cases.
    /// Remember you can always preform JetPackForAI.Elevate
    /// optimization with training data to improve LLM type performance.
    /// </summary>
    public string Tag { get; set; }



    /// <summary>
    /// 
    /// </summary>
    public LLMTaskDescriptionOutputFormats OutputFormat { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public string Description { get; init; }
    
    
    
    /// <summary>
    ///
    ///
    ///
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="outputFormat"></param>
    /// <exception cref="ArgumentException"></exception>
    public LLMTaskDescriptionOutput(string tag, string description, LLMTaskDescriptionOutputFormats outputFormat)
    {

        if (string.IsNullOrEmpty(tag) == true) throw new ArgumentException("tag is null  or empty.");
        if (string.IsNullOrWhiteSpace(tag) == true) throw new ArgumentException("tag is null  or whitespace.");

        Tag = tag;
        OutputFormat = outputFormat;
        Description = description;
        ValueType = typeof(TOut);

    }
    


}







