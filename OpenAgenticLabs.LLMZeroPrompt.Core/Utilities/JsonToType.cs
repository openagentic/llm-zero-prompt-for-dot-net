using Newtonsoft.Json;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;

/// <summary>
/// This class is used to convert a json string to a type.
/// </summary>
internal class JsonToType
{

    /// <summary>
    /// Convert a json string to a type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json">The string json to convert to a type.</param>
    /// <returns>The type created from the string json.</returns>
    public static ReturnResult<T, string> Convert<T>(string json)
    {
        try
        {
            var returnObject = JsonConvert.DeserializeObject<T>(json);
            return ReturnResult<T, string>.Success(returnObject);
        }
        catch (Exception e)
        {
            return ReturnResult<T, string>.Failure(e.Message);
        }
    }


}


