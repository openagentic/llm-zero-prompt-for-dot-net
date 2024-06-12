




namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;



/// <summary>
/// Represents an asynchronous operation to safely convert an object to a type <typeparamref name="T"/>.
/// <example>
/// Example of using TryGetAsync:
/// <code>
/// var tryGetString = TryGetAsync&lt;string&gt;.Create("123");
/// var result = await tryGetString.ResultAsync;
/// if (result.IsSuccess) Console.WriteLine(result.Result);
/// </code>
/// <code>
/// var tryGetInt = TryGetAsync&lt;int&gt;.Create("456");
/// await tryGetInt.MatchAsync(success => Console.WriteLine(success), fail => Console.WriteLine(fail.Message));
/// </code>
/// </example>
/// </summary>
public class TryGetAsync<T>
{
    private readonly object value;
    private readonly TaskCompletionSource<(bool IsSuccess, T? Result, Exception? Error)> resultTcs = new();

    private TryGetAsync(object? value)
    {
        this.value = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null.");

        if (value is T t)
        {
            resultTcs.SetResult((true, t, null));
        }
        else
        {
            Task.Run(async () => await ConvertValueAsync()).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Creates an instance of TryGetAsync for the given value.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns>An instance of TryGetAsync.</returns>
    public static TryGetAsync<T> Create(object? value) => new TryGetAsync<T>(value);

    /// <summary>
    /// Gets the result of the conversion attempt as an asynchronous task.
    /// </summary>
    public Task<(bool IsSuccess, T? Result, Exception? Error)> ResultAsync => resultTcs.Task;

    private async Task ConvertValueAsync()
    {
        try
        {
            var converted = (T)Convert.ChangeType(value, typeof(T));
            resultTcs.SetResult((true, converted, null));
        }
        catch (Exception ex)
        {
            resultTcs.SetResult((false, default, ex));
        }
    }

    /// <summary>
    /// Executes the provided success or failure functions based on the result.
    /// </summary>
    /// <param name="succ">Function to execute on success.</param>
    /// <param name="fail">Function to execute on failure.</param>
    public async Task MatchAsync(Func<T, Task> succ, Func<Exception, Task> fail)
    {
        var result = await ResultAsync;
        if (result.IsSuccess)
            await succ(result.Result);
        else
            await fail(result.Error);
    }
}

