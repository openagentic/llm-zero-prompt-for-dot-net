


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
public interface ILLMTaskDescription<TInp, TOut>

{

    /// <summary>
    /// This is the name given to the Task.
    /// be used
    /// </summary>
    string Name { get; init; }


    /// <summary>
    /// Outputs define for the LLM what we expect as an output and the format.
    /// For example, we require and 'answer' as a sentence. This helps to
    /// ensure that the LLM understands what the expected output is.
    /// </summary>
    TInp Input { get; init; }

    /// <summary>
    /// Outputs define for the LLM what we expect as an output and the format.
    /// For example, we require and 'answer' as a sentence. This helps to
    /// ensure that the LLM understands what the expected output is.
    /// </summary>
    TOut Output { get; init; }


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
    string Context { get; init; }
    
    
    
    /// <summary>
    /// Examples provides a way to show the LLM by teaching it with examples of
    /// the output we require and the format.
    /// </summary>
    string Examples { get; init; }


    /// <summary>
    /// 
    /// </summary>
    string Template { get; init; }


}







