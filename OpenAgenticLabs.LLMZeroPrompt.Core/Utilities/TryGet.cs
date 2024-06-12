


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


/// <summary>
/// This class that will allow you to try and get a value of type T from an object.
/// <example>
/// <code>
/// object value = 10;
/// var result = TryGet&lt;int&gt;.Create(value);
/// result.Match(
///     value => Console.WriteLine($"Result: {value}"),
///     exception => Console.WriteLine($"Error: {exception.Message}")
/// );
/// 
/// // Getting the value directly from the result property
/// if (result.Result.IsSuccess)
/// {
///     int convertedValue = result.Result.Result;
///     Console.WriteLine($"Converted value: {convertedValue}");
/// }
/// else
/// {
///     Exception exception = result.Result.Error;
///     Console.WriteLine($"Conversion failed with exception: {exception.Message}");
/// }
/// </code>
/// </example>
/// <remarks>
/// To get the value directly from the Result property:
/// <code>
/// var tryGet = TryGet&lt;int&gt;.Create(10);
/// if (tryGet.Result.IsSuccess)
/// {
///     int value = tryGet.Result.Result;
///     // Use the value
/// }
/// else
/// {
///     Exception exception = tryGet.Result.Error;
///     // Handle the exception
/// }
/// </code>
/// </remarks>
/// </summary>




/// <typeparam name="T"></typeparam>
public class TryGet<T>
{
    private readonly object value;

    /// <summary>
    /// Encapsulated computation result, lazy evaluation.
    /// </summary>
    public Lazy<(bool IsSuccess, T? Result, Exception? Error)> Result => result;
    private Lazy<(bool IsSuccess, T? Result, Exception? Error)> result;

    /// <summary>
    /// Private constructor to enforce the use of the static factory method.
    /// </summary>
    private TryGet(object? value)
    {
        if (value is null)
        {
            result = new Lazy<(bool, T?, Exception?)>(() => (false, default, null));
        }
        else
        {
            this.value = value;
            result = new Lazy<(bool, T?, Exception?)>(() => ConvertValue());
        }
    }

    /// <summary>
    /// Creates a new TryGet computation.
    /// </summary>
    /// <param name="value">The object to be converted to type T.</param>
    /// <returns>A new TryGet instance encapsulating the computation.</returns>
    public static TryGet<T> Create(object? value)
    {
        return new TryGet<T>(value);
    }

    /// <summary>
    /// Converts the object to type T and captures any exception.
    /// </summary>
    private (bool, T?, Exception?) ConvertValue()
    {
        try
        {

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"Cannot convert null to type {typeof(T)}.");
            }

            if (!(value is T))
            {
                return (true, (T)Convert.ChangeType(value, typeof(T)), null);
            }

            return (true, (T)value, null);
        }
        catch (Exception ex)
        {
            return (false, default, ex);
        }
    }

    /// <summary>
    /// Handles the result of the computation by providing handlers for success and failure.
    /// </summary>
    /// <param name="succ">Action to execute on success.</param>
    /// <param name="fail">Action to execute on failure.</param>
    public void Match(Action<T> succ, Action<Exception> fail)
    {
        if (result.Value.IsSuccess)
            succ(result.Value.Result);
        else
            fail(result.Value.Error);
    }
}