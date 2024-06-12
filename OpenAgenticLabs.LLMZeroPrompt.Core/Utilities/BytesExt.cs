

namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


/// <summary>
/// Byte related extension methods.
/// </summary>
public class BytesExt
{


    /// <summary>
    /// This method will copy bytes from one array to another.
    /// </summary>
    /// <param name="source">The source of the bytes to be copied.</param>
    /// <param name="destination">Where the source bytes are to be copied to.</param>
    /// <param name="destStartIndex">The starting point in the destination</param>
    /// <param name="count">The number of bytes to be copied.</param>
    /// <returns></returns>
    public static ReturnResult<int, string> CopyBytes(byte[] source, byte[] destination, int destStartIndex, int count)
    {

        try
        {
            if (destStartIndex + count > source.Length || count > destination.Length)
            {
                return ReturnResult<int, string>.Failure("Count is too large, or startIndex is out of range");
            }

            for (int i = 0; i < count; i++)
            {
                destination[i] = source[destStartIndex + i];
            }

            int returnCount = destStartIndex + count;

            return ReturnResult<int, string>.Success(returnCount);

        }
        catch (Exception ex)
        {
            return ReturnResult<int, string>.Failure($"Exception occured while copying bytes. Exception: {ex}");
        }

    }

}


