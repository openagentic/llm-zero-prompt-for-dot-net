using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


public static class TypeFormatConverter
{

    public static OperationResult<object, string, string> ConvertXtoY(string input, LLMTaskDescriptionOutputFormats outputFormat)
    {
        switch (outputFormat)
        {
            case LLMTaskDescriptionOutputFormats.None:
                return ConvertNone(input);
            case LLMTaskDescriptionOutputFormats.SingleWord:
                return ConvertSingleWord(input);
            case LLMTaskDescriptionOutputFormats.TwoWords:
                return ConvertTwoWords(input);
            case LLMTaskDescriptionOutputFormats.ThreeWords:
                return ConvertThreeWords(input);
            case LLMTaskDescriptionOutputFormats.CommaDelimited:
                return ConvertCommaDelimited(input);
            case LLMTaskDescriptionOutputFormats.Json:
                return ConvertJson(input);
            case LLMTaskDescriptionOutputFormats.Xml:
                return ConvertXml(input);
            case LLMTaskDescriptionOutputFormats.Sentence:
                return ConvertSentence(input);
            case LLMTaskDescriptionOutputFormats.Paragraph:
                return ConvertParagraph(input);
            case LLMTaskDescriptionOutputFormats.SpaceSeparated:
                return ConvertSpaceSeparated(input);
            case LLMTaskDescriptionOutputFormats.PipeSeparated:
                return ConvertPipeSeparated(input);
            case LLMTaskDescriptionOutputFormats.NewlineSeparated:
                return ConvertNewlineSeparated(input);
            case LLMTaskDescriptionOutputFormats.MultipleSentences:
                return ConvertMultipleSentences(input);
            case LLMTaskDescriptionOutputFormats.MultipleParagraphs:
                return ConvertMultipleParagraphs(input);
            case LLMTaskDescriptionOutputFormats.Int:
                return ConvertInt(input);
            case LLMTaskDescriptionOutputFormats.Float:
                return ConvertFloat(input);
            case LLMTaskDescriptionOutputFormats.Boolean:
                return ConvertBoolean(input);
            case LLMTaskDescriptionOutputFormats.Date:
                return ConvertDate(input);
            case LLMTaskDescriptionOutputFormats.Time:
                return ConvertTime(input);
            case LLMTaskDescriptionOutputFormats.DateTime:
                return ConvertDateTime(input);
            case LLMTaskDescriptionOutputFormats.Url:
                return ConvertUrl(input);
            case LLMTaskDescriptionOutputFormats.Email:
                return ConvertEmail(input);
            case LLMTaskDescriptionOutputFormats.PhoneNumber:
                return ConvertPhoneNumber(input);
            case LLMTaskDescriptionOutputFormats.Uuid:
                return ConvertUuid(input);
            case LLMTaskDescriptionOutputFormats.Regex:
                return ConvertRegex(input);
            case LLMTaskDescriptionOutputFormats.Html:
                return ConvertHtml(input);
            case LLMTaskDescriptionOutputFormats.Csv:
                return ConvertCsv(input);
            case LLMTaskDescriptionOutputFormats.Tsv:
                return ConvertTsv(input);
            case LLMTaskDescriptionOutputFormats.Yaml:
                return ConvertYaml(input);
            case LLMTaskDescriptionOutputFormats.Toml:
                return ConvertToml(input);
            case LLMTaskDescriptionOutputFormats.Ini:
                return ConvertIni(input);
            case LLMTaskDescriptionOutputFormats.Markdown:
                return ConvertMarkdown(input);
            case LLMTaskDescriptionOutputFormats.RichText:
                return ConvertRichText(input);
            case LLMTaskDescriptionOutputFormats.Binary:
                return ConvertBinary(input);
            case LLMTaskDescriptionOutputFormats.Image:
                return ConvertImage(input);
            case LLMTaskDescriptionOutputFormats.Audio:
                return ConvertAudio(input);
            case LLMTaskDescriptionOutputFormats.Video:
                return ConvertVideo(input);
            case LLMTaskDescriptionOutputFormats.TextDocument:
                return ConvertTextDocument(input);
            case LLMTaskDescriptionOutputFormats.SpreadsheetCsv:
                return ConvertSpreadsheetCsv(input);
            case LLMTaskDescriptionOutputFormats.ArchiveZip:
                return ConvertArchiveZip(input);
            case LLMTaskDescriptionOutputFormats.UserDecided:
                return ConvertUserDecided(input);
            case LLMTaskDescriptionOutputFormats.Double:
                return ConvertToDouble(input);
            case LLMTaskDescriptionOutputFormats.Summary:
                return ConvertToSummary(input);
            case LLMTaskDescriptionOutputFormats.JsonArrayKeyValuePairs:
                return ConvertToJsonArrayKeyValuePairs(input);
            case LLMTaskDescriptionOutputFormats.JsonArray:
                return ConvertToJsonArray(input);
            case LLMTaskDescriptionOutputFormats.JsonObject:
                return ConvertToJsonObject(input);
			case LLMTaskDescriptionOutputFormats.AzureBICEPTemplate:
				return ConvertToAzureBICEPTemplate(input);
			case LLMTaskDescriptionOutputFormats.PythonCode:
				return ConvertToPythonCode(input);
			case LLMTaskDescriptionOutputFormats.AzurePowerShellScript:
				return ConvertToAzurePowerShellScript(input);
			case LLMTaskDescriptionOutputFormats.DotNetCode:
				return ConvertToDotNetCode(input);
            case LLMTaskDescriptionOutputFormats.AzurePowerShellScriptRequirements:
                return ValidateAzurePowerShellScriptRequirements(input);
            default:
                return OperationResult<object, string, string>.Failure("Unknown output format.");
        }
    }

    public static OperationResult<object, string, string> ConvertNone(string input)
    {
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertSingleWord(string input)
    {
        if (Regex.IsMatch(input, @"^\w+$"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a single word.");

    }

    public static OperationResult<object, string, string> ConvertTwoWords(string input)
    {
        if (Regex.IsMatch(input, @"^\w+\s+\w+$"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not two word.");
    }

    public static OperationResult<object, string, string> ConvertThreeWords(string input)
    {
        if (Regex.IsMatch(input, @"^\w+\s+\w+\s+\w+$"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not three word.");

    }


    public static OperationResult<object, string, string> ConvertCommaDelimited(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^,]+(?:,[^,]+)*$"))
        {
            return OperationResult<object, string, string>.Success(input.Split(','));
        }
        return OperationResult<object, string, string>.Failure("Input is not a comma-separated list.");
    }

    public static OperationResult<object, string, string> ConvertJson(string input)
    {
        try
        {
            var jsonDocument = JsonDocument.Parse(input);
            return OperationResult<object, string, string>.Success(jsonDocument);
        }
        catch (JsonException)
        {
            return OperationResult<object, string, string>.Failure("Input is not valid JSON.");
        }
    }

    public static OperationResult<object, string, string> ConvertXml(string input)
    {
        try
        {
            var xDocument = XDocument.Parse(input);
            return OperationResult<object, string, string>.Success(xDocument);
        }
        catch (System.Xml.XmlException)
        {
            return OperationResult<object, string, string>.Failure("Input is not valid XML.");
        }
    }

    public static OperationResult<object, string, string> ConvertSentence(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$)"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid sentence.");
    }

    public static OperationResult<object, string, string> ConvertParagraph(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid paragraph.");
    }

    public static OperationResult<object, string, string> ConvertSpaceSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^\s]+(?:\s+[^\s]+)*$"))
        {
            return OperationResult<object, string, string>.Success(input.Split(' '));
        }
        return OperationResult<object, string, string>.Failure("Input is not a space-separated list.");
    }

    public static OperationResult<object, string, string> ConvertPipeSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^|]+(?:\|[^|]+)*$"))
        {
            return OperationResult<object, string, string>.Success(input.Split('|'));
        }
        return OperationResult<object, string, string>.Failure("Input is not a pipe-separated list.");
    }

    public static OperationResult<object, string, string> ConvertNewlineSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^\r\n]+(?:\r?\n[^\r\n]+)*$"))
        {
            return OperationResult<object, string, string>.Success(input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }
        return OperationResult<object, string, string>.Failure("Input is not a newline-separated list.");
    }

    public static OperationResult<object, string, string> ConvertMultipleSentences(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid group of sentences.");
    }

    public static OperationResult<object, string, string> ConvertMultipleParagraphs(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+\r?\n?)+"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid group of paragraphs.");
    }

    public static OperationResult<object, string, string> ConvertInt(string input)
    {
        if (int.TryParse(input, out int value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid integer.");
    }

    public static OperationResult<object, string, string> ConvertFloat(string input)
    {
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid float.");
    }

    public static OperationResult<object, string, string> ConvertBoolean(string input)
    {
        if (bool.TryParse(input, out bool value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid boolean.");
    }

    public static OperationResult<object, string, string> ConvertDate(string input)
    {
        if (DateTime.TryParse(input, out DateTime value))
        {
            return OperationResult<object, string, string>.Success(value.Date);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid date.");
    }

    public static OperationResult<object, string, string> ConvertTime(string input)
    {
        if (TimeSpan.TryParse(input, out TimeSpan value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid time.");
    }

    public static OperationResult<object, string, string> ConvertUrl(string input)
    {
        if (Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return OperationResult<object, string, string>.Success(uriResult);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid URL.");
    }

    public static OperationResult<object, string, string> ConvertEmail(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid email address.");
    }

    public static OperationResult<object, string, string> ConvertPhoneNumber(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\+?[0-9]{1,15}$"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid phone number.");
    }

    public static OperationResult<object, string, string> ConvertUuid(string input)
    {
        if (Guid.TryParse(input, out Guid value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure( "Input is not a valid UUID.");
    }

    public static OperationResult<object, string, string> ConvertRegex(string input)
    {
        try
        {
            var regex = new Regex(input);
            return OperationResult<object, string, string>.Success(regex);
        }
        catch (ArgumentException)
        {
            return OperationResult<object, string, string>.Failure("Input is not a valid regular expression.");
        }
    }

    public static OperationResult<object, string, string> ConvertCsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var csvData = lines.Select(line => line.Split(',')).ToArray();
            return OperationResult<object, string, string>.Success(csvData);
        }
        catch
        {
            return OperationResult<object, string, string>.Failure("Input is not a valid CSV.");
        }
    }

    public static OperationResult<object, string, string> ConvertTsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var tsvData = lines.Select(line => line.Split('\t')).ToArray();
            return OperationResult<object, string, string>.Success(tsvData);
        }
        catch
        {
            return OperationResult<object, string, string>.Failure("Input is not a valid TSV.");
        }
    }

    public static OperationResult<object, string, string> ConvertYaml(string input)
    {
        throw new NotImplementedException("OperationResult is not implemented.");
    }

    public static OperationResult<object, string, string> ConvertToml(string input)
    {
        throw new NotImplementedException("OperationResult is not implemented.");
    }

    public static OperationResult<object, string, string> ConvertIni(string input)
    {
        try
        {
            var iniData = new Dictionary<string, Dictionary<string, string>>();
            var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var sectionPattern = @"^\[.+\]$";
            var keyValuePattern = @"^.+=.+$";

            string currentSection = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (Regex.IsMatch(line, sectionPattern))
                {
                    currentSection = line.Trim('[', ']');
                    iniData[currentSection] = new Dictionary<string, string>();
                }
                else if (Regex.IsMatch(line, keyValuePattern))
                {
                    if (currentSection == null)
                        throw new InvalidOperationException("Key-value pair found before section header.");

                    var parts = line.Split(new[] { '=' }, 2, StringSplitOptions.None);
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    iniData[currentSection][key] = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid INI format.");
                }
            }

            return OperationResult<object, string, string>.Success(iniData);
        }
        catch (Exception ex)
        {
            return OperationResult<object, string, string>.Failure(ex.Message);
        }
    }

    public static OperationResult<object, string, string> ConvertMarkdown(string input)
    {
        // Markdown conversion is not applicable for string input
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertRichText(string input)
    {
        // Rich text conversion is not applicable for string input
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertBinary(string input)
    {
        // Binary data conversion is not applicable for string input
        return OperationResult<object, string, string>.Failure("Binary data conversion is not supported.");
    }

    public static OperationResult<object, string, string> ConvertImage(string input)
    {
        // Image data conversion is not applicable for string input
        return OperationResult<object, string, string>.Failure("Image data conversion is not supported.");
    }

    public static OperationResult<object, string, string> ConvertAudio(string input)
    {
        // Audio data conversion is not applicable for string input
        return OperationResult<object, string, string>.Failure("Audio data conversion is not supported.");
    }

    public static OperationResult<object, string, string> ConvertVideo(string input)
    {
        // Video data conversion is not applicable for string input
        return OperationResult<object, string, string>.Failure( "Video data conversion is not supported.");
    }

    public static OperationResult<object, string, string> ConvertTextDocument(string input)
    {
        // Text document conversion is not applicable for string input
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertSpreadsheetCsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var csvData = lines.Select(line => line.Split(',')).ToArray();
            return OperationResult<object, string, string>.Success(csvData);
        }
        catch
        {
            return OperationResult<object, string, string>.Failure( "Input is not a valid spreadsheet CSV.");
        }
    }

    public static OperationResult<object, string, string> ConvertArchiveZip(string input)
    {
        // ZIP archive conversion is not applicable for string input
        return OperationResult<object, string, string>.Failure( "ZIP archive conversion is not supported.");
    }

    public static OperationResult<object, string, string> ConvertUserDecided(string input)
    {
        // User-decided format conversion is not applicable
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertHtml(string input)
    {
        // HTML conversion is not applicable for string input
        return OperationResult<object, string, string>.Success(input);
    }

    public static OperationResult<object, string, string> ConvertDateTime(string input)
    {
        if (DateTime.TryParse(input, out DateTime value))
        {
            return OperationResult<object, string, string>.Success(value);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid date and time.");
    }

    public static OperationResult<object, string, string> ConvertToDouble(string input)
    {
        // Check if the input is not null or empty and can be parsed as a double
        if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double result))
        {
            return OperationResult<object, string, string>.Success(result);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid double.");
    }


    public static OperationResult<object, string, string> ConvertToSummary(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$)"))
        {
            return OperationResult<object, string, string>.Success(input);
        }
        return OperationResult<object, string, string>.Failure("Input is not a valid sentence.");
    }

    public static OperationResult<object, string, string> ConvertToJsonArrayKeyValuePairs(string input)
    {
        try
        {
            JArray jsonArray = JArray.Parse(input);

            return OperationResult<object, string, string>.Success(jsonArray);
        }
        catch (Exception ex)
        {

            return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
    }



    public static OperationResult<object, string, string> ConvertToJsonArray(string input)
    {
        try
        {
    
            JArray jsonArray = JArray.Parse(input);
          
            return OperationResult<object, string, string>.Success(jsonArray);
        }
        catch (Exception ex)
        {
        
            return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
    }



    public static OperationResult<object, string, string> ConvertToJsonObject(string input)
    {
        try
        {

            JObject jsonJObject = JObject.Parse(input);

            return OperationResult<object, string, string>.Success(jsonJObject);
        }
        catch (Exception ex)
        {

            return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
    }



	public static OperationResult<object, string, string> ConvertToAzureBICEPTemplate(string input)
	{
		try
		{
			return OperationResult<object, string, string>.Success(input);
		}
		catch (Exception ex)
		{
			return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<object, string, string> ConvertToPythonCode(string input)
	{
		try
		{
			return OperationResult<object, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<object, string, string> ConvertToAzurePowerShellScript(string input)
	{
		try
		{

			return OperationResult<object, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<object, string, string> ConvertToDotNetCode(string input)
	{
		try
		{
			return OperationResult<object, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<object, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


    public static OperationResult<object, string, string> ValidateAzurePowerShellScriptRequirements(string input)
    {
        try
        {
            return OperationResult<object, string, string>.Success(input);

        }
        catch (Exception ex)
        {
            return OperationResult<object, string, string>.Failure($"Input is not valid Azure PowerShell requirements.. Error: {ex.Message}");
        }
    }

    
}