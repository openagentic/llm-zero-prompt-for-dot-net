using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;



/// <summary>
/// 
/// </summary>
public class LLMTaskDescriptionInput<T> 
{

    /// <summary>
    /// 
    /// </summary>
    public T Value { get; init; }
    
    
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
    public string Tag { get; init; }



    /// <summary>
    /// 
    /// </summary>
    public LLMTaskDescriptionInputFormats Format { get; init; }


    /// <summary>
    /// 
    /// </summary>
    public string Description { get; init; }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="name"></param>
    /// <param name="inputFormat"></param>
    /// <exception cref="ArgumentException"></exception>
    public LLMTaskDescriptionInput(T value, string tag, string description,  LLMTaskDescriptionInputFormats inputFormat)
    {

        if (string.IsNullOrEmpty(tag) == true) throw new ArgumentException("tag is null  or empty.");
        if (string.IsNullOrWhiteSpace(tag) == true) throw new ArgumentException("tag is null  or whitespace.");

        Value = value;
        Tag = tag;
        Description = description;


    }

}







