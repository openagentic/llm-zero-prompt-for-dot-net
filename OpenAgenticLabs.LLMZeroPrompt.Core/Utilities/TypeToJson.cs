using Newtonsoft.Json;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;

/// <summary>
/// This will convert any input to Json
/// </summary>
internal class TypeToJson
{

    /// <summary>
    /// This will convert any input object to Json
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static ReturnResult<string, string> Convert(object input)
    {

        try
        {
            string json = JsonConvert.SerializeObject(input);

            return ReturnResult<string, string>.Success(json);

        }
        catch (Exception ex)
        {
           return ReturnResult<string, string>.Failure($"Exception occured converting object to json. Exception: {ex}");
        }
       

    }
}


