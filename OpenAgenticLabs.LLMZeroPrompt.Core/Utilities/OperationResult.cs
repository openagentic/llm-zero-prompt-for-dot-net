namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN
{
    /// <summary>
    /// Represents the status of an operation.
    /// </summary>
    public enum OperationResultOperationStatus
    {
        /// <summary>
        /// All was good and you will get a result.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Failure of some kind happened.
        /// </summary>
        Failure = 1,
        /// <summary>
        /// No failure just a clean exit.
        /// </summary>
        Exit = 2
    }

    /// <summary>
    /// Represents the result of an operation, encapsulating a result value of type T, a status value of type TS, and an exit status value of type TE.
    /// <example>
    /// OperationResult<int, string, string> successResult = OperationResult<int, string, string>.Success(42);
    /// OperationResult<bool, string, string> failureResult = OperationResult<bool, string, string>.Failure("Error message");
    /// OperationResult<bool, string, string> exitResult = OperationResult<bool, string, string>.Exit("Exit message");
    /// OperationResult<bool, bool, bool> successBoolResult = OperationResult<bool, bool, bool>.Success();
    /// OperationResult<int, bool, bool> failureBoolResult = OperationResult<int, bool, bool>.Failure();
    /// OperationResult<int, bool, bool> exitBoolResult = OperationResult<int, bool, bool>.Exit();
    /// </example>
    /// </summary>
    /// <typeparam name="TR">The type of the result value.</typeparam>
    /// <typeparam name="TF">The type of the status value.</typeparam>
    /// <typeparam name="TE">The type of the exit status value.</typeparam>
    public class OperationResult<TR, TF, TE>
    {
        /// <summary>
        /// Gets the result value of the operation.
        /// </summary>
        public TR SuccessValue { get; private set; }

        /// <summary>
        /// Gets the status value of the operation.
        /// </summary>
        public TF FailureValue { get; private set; }

        /// <summary>
        /// Gets the exit status value of the operation.
        /// </summary>
        public TE ExitValue { get; private set; }

        /// <summary>
        /// Gets the status of the operation.
        /// </summary>
        public OperationResultOperationStatus OperationStatus { get; private set; }

        /// <summary>
        /// Gets the exception associated with the failure, if any.
        /// </summary>
        public Exception FailureException { get; private set; }

        private OperationResult(TR successValue, TF failureValue, TE exitValue, OperationResultOperationStatus operationResultOperationStatus, Exception failureException = null)
        {
            SuccessValue = successValue;
            FailureValue = failureValue;
            ExitValue = exitValue;
            OperationStatus = operationResultOperationStatus;
            FailureException = failureException;
        }

        /// <summary>
        /// Creates a successful <see cref="OperationResult{TR, TF, TE}"/> object with the specified result value.
        /// </summary>
        /// <param name="result">The result value of the operation.</param>
        /// <returns>A successful <see cref="OperationResult{TR, TF, TE}"/> object.</returns>
        public static OperationResult<TR, TF, TE> Success(TR result)
        {
            return new OperationResult<TR, TF, TE>(result, default(TF), default(TE), OperationResultOperationStatus.Success);
        }

        /// <summary>
        /// Creates a successful <see cref="OperationResult{TR,TF,TE}"/> object with a result value of true.
        /// </summary>
        /// <returns>A successful <see cref="OperationResult{TR,TF,TE}"/> object.</returns>
        public static OperationResult<bool, TF, TE> Success()
        {
            return new OperationResult<bool, TF, TE>(true, default(TF), default(TE), OperationResultOperationStatus.Success);
        }

        /// <summary>
        /// Creates a failed <see cref="OperationResult{TR, TF, TE}"/> object with the specified status value.
        /// </summary>
        /// <param name="statusValue">The status value of the operation.</param>
        /// <param name="exception">An optional exception associated with the failure.</param>
        /// <returns>A failed <see cref="OperationResult{TR, TF, TE}"/> object.</returns>
        public static OperationResult<TR, TF, TE> Failure(TF statusValue, Exception exception = null)
        {
            return new OperationResult<TR, TF, TE>(default(TR), statusValue, default(TE), OperationResultOperationStatus.Failure, exception);
        }

        /// <summary>
        /// Creates a failed <see cref="OperationResult{TR,TF,TE}"/> object with a status value of false.
        /// </summary>
        /// <param name="exception">An optional exception associated with the failure.</param>
        /// <returns>A failed <see cref="OperationResult{TR,TF,TE}"/> object.</returns>
        public static OperationResult<TR, bool, TE> Failure(Exception exception = null)
        {
            return new OperationResult<TR, bool, TE>(default(TR), false, default(TE), OperationResultOperationStatus.Failure, exception);
        }

        /// <summary>
        /// Creates an exited <see cref="OperationResult{TR, TF, TE}"/> object with the specified exit status value.
        /// </summary>
        /// <param name="exitStatus">The exit status value of the operation.</param>
        /// <returns>An exited <see cref="OperationResult{TR, TF, TE}"/> object.</returns>
        public static OperationResult<TR, TF, TE> Exit(TE exitStatus)
        {
            return new OperationResult<TR, TF, TE>(default(TR), default(TF), exitStatus, OperationResultOperationStatus.Exit);
        }

        /// <summary>
        /// Creates an exited <see cref="OperationResult{TR, TF, bool}"/> object with an exit status value of false.
        /// </summary>
        /// <returns>An exited <see cref="OperationResult{TR, TF, bool}"/> object.</returns>
        public static OperationResult<TR, TF, bool> Exit()
        {
            return new OperationResult<TR, TF, bool>(default(TR), default(TF), false, OperationResultOperationStatus.Exit);
        }
    }
}

















//namespace JetPackForAI.Elevate.Core.UtilitiesN;


///// <summary>
///// Represents the status of an operation.
///// </summary>
//public enum OperationResultOperationStatus
//{
//    /// <summary>
//    /// All was good and you will get a result.
//    /// </summary>
//    Success = 0,
//    /// <summary>
//    /// Failure of some kind happened.
//    /// </summary>
//    Failure = 1,
//    /// <summary>
//    /// No failure ust a clean exit.
//    /// </summary>
//    Exit = 2
//}


///// <summary>
///// Represents the result of an operation, encapsulating a result value of type T, a status value of type TS, and an exit status value of type TE.
///// <example>
///// OperationResult<int, string, string> successResult = OperationResult<int, string, string>.Success(42);
///// OperationResult<bool, string, string> failureResult = OperationResult<bool, string, string>.Failure("Error message");
///// OperationResult<bool, string, string> exitResult = OperationResult<bool, string, string>.Exit("Exit message");
///// OperationResult<bool, bool, bool> successBoolResult = OperationResult<bool, bool, bool>.Success();
///// OperationResult<int, bool, bool> failureBoolResult = OperationResult<int, bool, bool>.Failure();
///// OperationResult<int, bool, bool> exitBoolResult = OperationResult<int, bool, bool>.Exit();
///// </example>
///// </summary>
///// <typeparam name="TR">The type of the result value.</typeparam>
///// <typeparam name="TF">The type of the status value.</typeparam>
///// <typeparam name="TE">The type of the exit status value.</typeparam>
//public class OperationResult<TR, TF, TE>
//{
//    /// <summary>
//    /// Gets the result value of the operation.
//    /// </summary>
//    public TR SuccessValue { get; private set; }

//    /// <summary>
//    /// Gets the status value of the operation.
//    /// </summary>
//    public TF FailureValue { get; private set; }

//    /// <summary>
//    /// Gets the exit status value of the operation.
//    /// </summary>
//    public TE ExitValue { get; private set; }

//    /// <summary>
//    /// Gets the status of the operation.
//    /// </summary>
//    public OperationResultOperationStatus OperationStatus { get; private set; }

//    private OperationResult(TR successValue, TF failureValue, TE exitValue, OperationResultOperationStatus operationResultOperationStatus)
//    {
//        SuccessValue = successValue;
//        FailureValue = failureValue;
//        ExitValue = exitValue;
//        OperationStatus = operationResultOperationStatus;
//    }

//    /// <summary>
//    /// Creates a successful <see cref="OperationResult{T, TS, TE}"/> object with the specified result value.
//    /// </summary>
//    /// <param name="result">The result value of the operation.</param>
//    /// <returns>A successful <see cref="OperationResult{T, TS, TE}"/> object.</returns>
//    public static OperationResult<TR, TF, TE> Success(TR result)
//    {
//        return new OperationResult<TR, TF, TE>(result, default(TF), default(TE), OperationResultOperationStatus.Success);
//    }

//    /// <summary>
//    /// Creates a successful <see cref="OperationResult{bool, TS, TE}"/> object with a result value of true.
//    /// </summary>
//    /// <returns>A successful <see cref="OperationResult{bool, TS, TE}"/> object.</returns>
//    public static OperationResult<bool, TF, TE> Success()
//    {
//        return new OperationResult<bool, TF, TE>(true, default(TF), default(TE), OperationResultOperationStatus.Success);
//    }

//    /// <summary>
//    /// Creates a failed <see cref="OperationResult{T, TS, TE}"/> object with the specified status value.
//    /// </summary>
//    /// <param name="statusValue">The status value of the operation.</param>
//    /// <returns>A failed <see cref="OperationResult{T, TS, TE}"/> object.</returns>
//    public static OperationResult<TR, TF, TE> Failure(TF statusValue)
//    {
//        return new OperationResult<TR, TF, TE>(default(TR), statusValue, default(TE), OperationResultOperationStatus.Failure);
//    }

//    /// <summary>
//    /// Creates a failed <see cref="OperationResult{T, bool, TE}"/> object with a status value of false.
//    /// </summary>
//    /// <returns>A failed <see cref="OperationResult{T, bool, TE}"/> object.</returns>
//    public static OperationResult<TR, bool, TE> Failure()
//    {
//        return new OperationResult<TR, bool, TE>(default(TR), false, default(TE), OperationResultOperationStatus.Failure);
//    }

//    /// <summary>
//    /// Creates an exited <see cref="OperationResult{T, TS, TE}"/> object with the specified exit status value.
//    /// </summary>
//    /// <param name="exitStatus">The exit status value of the operation.</param>
//    /// <returns>An exited <see cref="OperationResult{T, TS, TE}"/> object.</returns>
//    public static OperationResult<TR, TF, TE> Exit(TE exitStatus)
//    {
//        return new OperationResult<TR, TF, TE>(default(TR), default(TF), exitStatus, OperationResultOperationStatus.Exit);
//    }

//    /// <summary>
//    /// Creates an exited <see cref="OperationResult{T, TS, bool}"/> object with an exit status value of false.
//    /// </summary>
//    /// <returns>An exited <see cref="OperationResult{T, TS, bool}"/> object.</returns>
//    public static OperationResult<TR, TF, bool> Exit()
//    {
//        return new OperationResult<TR, TF, bool>(default(TR), default(TF), false, OperationResultOperationStatus.Exit);
//    }
//}
