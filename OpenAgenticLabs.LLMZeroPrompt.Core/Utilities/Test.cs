


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;





/// <summary>
/// Generic test class that enables comparing objects of type T and M.
/// <example>
/// <code>
/// var test = new Test&lt;int, double&gt;();
/// bool isEqual = test.AreEqual(5, 5.0);
/// Console.WriteLine($"Are equal: {isEqual}");
///
/// var notEqual = test.AreNotEqual(5, 6.0);
/// Console.WriteLine($"Are not equal: {notEqual}");
/// </code>
/// </example>
/// </summary>
/// <typeparam name="T">The first type to compare.</typeparam>
/// <typeparam name="M">The second type to compare, convertible to T.</typeparam>
public class Test<T, M> where M : IConvertible
{

    /// <summary>
    /// Checks if two values are equal.
    /// </summary>
    /// <param name="first">First value of type T.</param>
    /// <param name="second">Second value of type M.</param>
    /// <returns>True if equal, otherwise false.</returns>
    public bool AreEqual(T first, M second)
    {

        try
        {
            T convertedSecond = (T)Convert.ChangeType(second, typeof(T));
            return EqualityComparer<T>.Default.Equals(first, convertedSecond);
        }
        catch (Exception ex)
        {
            ;
            throw;
        }
    }

    /// <summary>
    /// Checks if two values are not equal.
    /// </summary>
    /// <param name="first">First value of type T.</param>
    /// <param name="second">Second value of type M.</param>
    /// <returns>True if not equal, otherwise false.</returns>
    public bool AreNotEqual(T first, M second)
    {
        try
        {
            T convertedSecond = (T)Convert.ChangeType(second, typeof(T));
            return !EqualityComparer<T>.Default.Equals(first, convertedSecond);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}



