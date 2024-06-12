

namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


/// <summary>
/// Represents the result of an operation, encapsulating a result value of type T and a flag value of type TF.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
/// <typeparam name="TF">The type of the flag value.</typeparam>
/// <example>
/// // Example usage:
/// ReturnResult<int, string> successResult = ReturnResult<int, string>.Success(42);
/// ReturnResult<bool, string> failureResult = ReturnResult<bool, string>.Failure("Error message");
/// ReturnResult<bool, bool> successBoolResult = ReturnResult<bool, bool>.Success();
/// ReturnResult<int, bool> failureBoolResult = ReturnResult<int, bool>.Failure();
/// </example>
public class ReturnResult<T, TF>
{
    /// <summary>
    /// Gets the result value of the operation.
    /// </summary>
    public T Result { get; private set; }

    /// <summary>
    /// Gets the flag value of the operation.
    /// </summary>
    public TF Flag { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess = false;

    private ReturnResult(T result, TF flag, bool isSuccess)
    {
        Result = result;
        Flag = flag;
        IsSuccess = isSuccess;
    }

    /// <summary>
    /// Creates a successful <see cref="ReturnResult{T, TF}"/> object with the specified result value.
    /// </summary>
    /// <param name="result">The result value of the operation.</param>
    /// <returns>A successful <see cref="ReturnResult{T, TF}"/> object.</returns>
    public static ReturnResult<T, TF> Success(T result)
    {
        return new ReturnResult<T, TF>(result, default(TF), true);
    }

    /// <summary>
    /// Creates a successful <see cref="ReturnResult{T,TF}"/> object with a result value of true.
    /// </summary>
    /// <returns>A successful <see cref="ReturnResult{T,TF}"/> object.</returns>
    public static ReturnResult<bool, TF> Success()
    {
        return new ReturnResult<bool, TF>(true, default(TF), true);
    }

    /// <summary>
    /// Creates a failed <see cref="ReturnResult{T, TF}"/> object with the specified flag value.
    /// </summary>
    /// <param name="flag">The flag value of the operation.</param>
    /// <returns>A failed <see cref="ReturnResult{T, TF}"/> object.</returns>
    public static ReturnResult<T, TF> Failure(TF flag)
    {
        return new ReturnResult<T, TF>(default(T), flag, false);
    }

    /// <summary>
    /// Creates a failed <see cref="ReturnResult{T, bool}"/> object with a flag value of false.
    /// </summary>
    /// <returns>A failed <see cref="ReturnResult{T, bool}"/> object.</returns>
    public static ReturnResult<T, bool> Failure()
    {
        return new ReturnResult<T, bool>(default(T), false, false);
    }
}


//public class ReturnResult<T, TF>
//{

//    public T Result { get; private set; }
//    public TF Flag { get; private set; }

//    public bool IsSuccess = false; 

//    private ReturnResult(T result, TF flag, bool isSuccess)
//    {
//        Result = result;
//        Flag = flag;
//        IsSuccess = isSuccess;
//    }



//    public static ReturnResult<T, TF> Success(T result, TF flag)
//    {


//        return new ReturnResult<T, TF>(result, flag, true);
//    }

//    public static ReturnResult<T, TF> Failure(T result, TF flag)
//    {
//        return new ReturnResult<T, TF>(result, flag, false);
//    }

//}
