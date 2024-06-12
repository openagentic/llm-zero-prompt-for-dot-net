using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


public static class TypeFormatValidator
{

    public static OperationResult<string, string, string> ValidateXCanBeY(string input, LLMTaskDescriptionOutputFormats outputFormat)
    {
        switch (outputFormat)
        {
            case LLMTaskDescriptionOutputFormats.None:
                return ValidateNone(input);
            case LLMTaskDescriptionOutputFormats.SingleWord:
                return ValidateSingleWord(input);
            case LLMTaskDescriptionOutputFormats.TwoWords:
                return ValidateTwoWords(input);
            case LLMTaskDescriptionOutputFormats.ThreeWords:
                return ValidateThreeWords(input);
            case LLMTaskDescriptionOutputFormats.CommaDelimited:
                return ValidateCommaDelimited(input);
            case LLMTaskDescriptionOutputFormats.Json:
                return ValidateJson(input);
            case LLMTaskDescriptionOutputFormats.Xml:
                return ValidateXml(input);
            case LLMTaskDescriptionOutputFormats.Sentence:
                return ValidateSentence(input);
            case LLMTaskDescriptionOutputFormats.Paragraph:
                return ValidateParagraph(input);
            case LLMTaskDescriptionOutputFormats.SpaceSeparated:
                return ValidateSpaceSeparated(input);
            case LLMTaskDescriptionOutputFormats.PipeSeparated:
                return ValidatePipeSeparated(input);
            case LLMTaskDescriptionOutputFormats.NewlineSeparated:
                return ValidateNewlineSeparated(input);
            case LLMTaskDescriptionOutputFormats.MultipleSentences:
                return ValidateMultipleSentences(input);
            case LLMTaskDescriptionOutputFormats.MultipleParagraphs:
                return ValidateMultipleParagraphs(input);
            case LLMTaskDescriptionOutputFormats.Int:
                return ValidateInt(input);
            case LLMTaskDescriptionOutputFormats.Float:
                return ValidateFloat(input);
            case LLMTaskDescriptionOutputFormats.Boolean:
                return ValidateBoolean(input);
            case LLMTaskDescriptionOutputFormats.Date:
                return ValidateDate(input);
            case LLMTaskDescriptionOutputFormats.Time:
                return ValidateTime(input);
            case LLMTaskDescriptionOutputFormats.DateTime:
                return ValidateDateTime(input);
            case LLMTaskDescriptionOutputFormats.Url:
                return ValidateUrl(input);
            case LLMTaskDescriptionOutputFormats.Email:
                return ValidateEmail(input);
            case LLMTaskDescriptionOutputFormats.PhoneNumber:
                return ValidatePhoneNumber(input);
            case LLMTaskDescriptionOutputFormats.Uuid:
                return ValidateUuid(input);
            case LLMTaskDescriptionOutputFormats.Regex:
                return ValidateRegex(input);
            case LLMTaskDescriptionOutputFormats.Html:
                return ValidateHtml(input);
            case LLMTaskDescriptionOutputFormats.Csv:
                return ValidateCsv(input);
            case LLMTaskDescriptionOutputFormats.Tsv:
                return ValidateTsv(input);
            case LLMTaskDescriptionOutputFormats.Yaml:
                return ValidateYaml(input);
            case LLMTaskDescriptionOutputFormats.Toml:
                return ValidateToml(input);
            case LLMTaskDescriptionOutputFormats.Ini:
                return ValidateIni(input);
            case LLMTaskDescriptionOutputFormats.Markdown:
                return ValidateMarkdown(input);
            case LLMTaskDescriptionOutputFormats.RichText:
                return ValidateRichText(input);
            case LLMTaskDescriptionOutputFormats.Binary:
                return ValidateBinary(input);
            case LLMTaskDescriptionOutputFormats.Image:
                return ValidateImage(input);
            case LLMTaskDescriptionOutputFormats.Audio:
                return ValidateAudio(input);
            case LLMTaskDescriptionOutputFormats.Video:
                return ValidateVideo(input);
            case LLMTaskDescriptionOutputFormats.TextDocument:
                return ValidateTextDocument(input);
            case LLMTaskDescriptionOutputFormats.SpreadsheetCsv:
                return ValidateSpreadsheetCsv(input);
            case LLMTaskDescriptionOutputFormats.ArchiveZip:
                return ValidateArchiveZip(input);
            case LLMTaskDescriptionOutputFormats.UserDecided:
                return ValidateUserDecided(input);
            case LLMTaskDescriptionOutputFormats.Double:
                return ValidateDouble(input);
            case LLMTaskDescriptionOutputFormats.Summary:
                return ValidateSummery(input);
            case LLMTaskDescriptionOutputFormats.JsonArrayKeyValuePairs:
                return ValidateJsonArrayKeyValuePairs(input);
            case LLMTaskDescriptionOutputFormats.JsonArray:
                return ValidateJsonArray(input);
            case LLMTaskDescriptionOutputFormats.JsonObject:
                return ValidateJsonObject(input);
	        case LLMTaskDescriptionOutputFormats.AzureBICEPTemplate:
	            return ValidateAzureBICEPTemplate(input);
            case LLMTaskDescriptionOutputFormats.PythonCode:
	            return ValidatePythonCode(input);
            case LLMTaskDescriptionOutputFormats.AzurePowerShellScript:
	            return ValidateAzurePowerShellScript(input);
            case LLMTaskDescriptionOutputFormats.DotNetCode:
	            return ValidateDotNetCode(input);
            case LLMTaskDescriptionOutputFormats.AzurePowerShellScriptRequirements:
                return ValidateAzurePowerShellScriptRequirements(input);
            default:
                return OperationResult<string, string, string>.Failure("Unknown output format.");
        }
    }

    
    public static OperationResult<string, string, string> ValidateNone(string input)
    {
        return OperationResult<string, string, string>.Success(input);
    }

    public static OperationResult<string, string, string> ValidateSingleWord(string input)
    {
        if (Regex.IsMatch(input, @"^\w+$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a single word.");

    }

    public static OperationResult<string, string, string> ValidateTwoWords(string input)
    {
        if (Regex.IsMatch(input, @"^\w+\s+\w+$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not two word.");
    }

    public static OperationResult<string, string, string> ValidateThreeWords(string input)
    {
        if (Regex.IsMatch(input, @"^\w+\s+\w+\s+\w+$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not three word.");

    }


    public static OperationResult<string, string, string> ValidateCommaDelimited(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^,]+(?:,[^,]+)*$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a comma-separated list.");
    }

    public static OperationResult<string, string, string> ValidateJson(string input)
    {
        try
        {
            JsonDocument.Parse(input);
            return OperationResult<string, string, string>.Success(input);
        }
        catch (JsonException)
        {
            return OperationResult<string, string, string>.Failure( "Input is not valid JSON.");
        }
    }

    public static OperationResult<string, string, string> ValidateXml(string input)
    {
        try
        {
            XDocument.Parse(input);
            return OperationResult<string, string, string>.Success(input);
        }
        catch (System.Xml.XmlException)
        {
            return OperationResult<string, string, string>.Failure( "Input is not valid XML.");
        }
    }

    public static OperationResult<string, string, string> ValidateSentence(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$)"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid sentence.");
    }

    public static OperationResult<string, string, string> ValidateParagraph(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid paragraph." );
    }

    public static OperationResult<string, string, string> ValidateSpaceSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^\s]+(?:\s+[^\s]+)*$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a space-separated list.");
    }

    public static OperationResult<string, string, string> ValidatePipeSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^|]+(?:\|[^|]+)*$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a pipe-separated list.");
    }

    public static OperationResult<string, string, string> ValidateNewlineSeparated(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^\r\n]+(?:\r?\n[^\r\n]+)*$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a newline-separated list.");
    }

    public static OperationResult<string, string, string> ValidateMultipleSentences(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid group of sentences.");
    }

    public static OperationResult<string, string, string> ValidateMultipleParagraphs(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(?:(?:[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$))+\r?\n?)+"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid group of paragraphs.");
    }

    public static OperationResult<string, string, string> ValidateInt(string input)
    {
        if (int.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid integer.");
    }

    public static OperationResult<string, string, string> ValidateFloat(string input)
    {
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid float");
    }

    public static OperationResult<string, string, string> ValidateBoolean(string input)
    {
        if (bool.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid boolean.");
    }

    public static OperationResult<string, string, string> ValidateDate(string input)
    {
        if (DateTime.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid date.");
    }

    public static OperationResult<string, string, string> ValidateTime(string input)
    {
        if (TimeSpan.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid time.");
    }

    public static OperationResult<string, string, string> ValidateDateTime(string input)
    {
        if (DateTime.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid date and time.");
    }

    public static OperationResult<string, string, string> ValidateUrl(string input)
    {
        if (Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid URL.");
    }

    public static OperationResult<string, string, string> ValidateEmail(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid email address.");
    }

    public static OperationResult<string, string, string> ValidatePhoneNumber(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\+?[0-9]{1,15}$"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid phone number.");
    }

    public static OperationResult<string, string, string> ValidateUuid(string input)
    {
        if (Guid.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid UUID.");
    }

    public static OperationResult<string, string, string> ValidateRegex(string input)
    {
        try
        {
            Regex.Match("", input);
            return OperationResult<string, string, string>.Success(input);
        }
        catch (ArgumentException)
        {
            return OperationResult<string, string, string>.Failure( "Input is not a valid regular expression.");
        }
    }


    public static OperationResult<string, string, string> ValidateCsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                // Additional validation logic for CSV fields can be added here
            }
            return OperationResult<string, string, string>.Success(input);
        }
        catch
        {
            return OperationResult<string, string, string>.Failure("Input is not a valid CSV.");
        }
    }

    public static OperationResult<string, string, string> ValidateTsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] fields = line.Split('\t');
                // Additional validation logic for TSV fields can be added here
            }
            return OperationResult<string, string, string>.Success(input);
        }
        catch
        {
            return OperationResult<string, string, string>.Failure( "Input is not a valid TSV.");
        }
    }

    public static OperationResult<string, string, string> ValidateYaml(string input)
    {
        throw new NotImplementedException("OperationResult is not implemented.");
    }

    public static OperationResult<string, string, string> ValidateToml(string input)
    {
        throw new NotImplementedException("OperationResult is not implemented.");
    }

    public static OperationResult<string, string, string> ValidateIni(string input)
    {
        try
        {
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
                }
                else if (Regex.IsMatch(line, keyValuePattern))
                {
                    if (currentSection == null)
                        throw new InvalidOperationException("Key-value pair found before section header.");

                    var parts = line.Split(new[] { '=' }, 2, StringSplitOptions.None);
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                }
                else
                {
                    throw new InvalidOperationException("Invalid INI format.");
                }
            }

            return OperationResult<string, string, string>.Success(input);
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure(ex.Message);
        }
    }

    public static OperationResult<string, string, string> ValidateMarkdown(string input)
    {
        // Markdown validation can be quite complex, so a simple check for common Markdown syntax can be performed
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"(#+.*|(\*|-|\+)\s.*|>\s.*|```.*```)"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid Markdown.");
    }

    public static OperationResult<string, string, string> ValidateRichText(string input)
    {
        // Rich text validation depends on the specific rich text format (e.g., RTF, HTML)
        // For simplicity, let's assume it's HTML and perform a basic check for common HTML tags
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"<(/?\w+).*?>"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure( "Input is not a valid rich text.");
    }

    public static OperationResult<string, string, string> ValidateBinary(string input)
    {
        // Binary data validation is not applicable for string input
        return OperationResult<string, string, string>.Failure( "Binary data validation is not supported.");
    }

    public static OperationResult<string, string, string> ValidateImage(string input)
    {
        // Image data validation is not applicable for string input
        return OperationResult<string, string, string>.Failure( "Image data validation is not supported.");
    }

    public static OperationResult<string, string, string> ValidateAudio(string input)
    {
        // Audio data validation is not applicable for string input
        return OperationResult<string, string, string>.Failure( "Audio data validation is not supported.");
    }

    public static OperationResult<string, string, string> ValidateVideo(string input)
    {
        // Video data validation is not applicable for string input
        return OperationResult<string, string, string>.Failure( "Video data validation is not supported.");
    }

    public static OperationResult<string, string, string> ValidateTextDocument(string input)
    {
        // Text document validation can be performed by checking for common file extensions
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"\.(txt|doc|docx|odt|rtf)$", RegexOptions.IgnoreCase))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid text document.");
    }

    public static OperationResult<string, string, string> ValidateSpreadsheetCsv(string input)
    {
        try
        {
            string[] lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                // Additional validation logic for spreadsheet CSV fields can be added here
            }
            return OperationResult<string, string, string>.Success(input);
        }
        catch
        {
            return OperationResult<string, string, string>.Failure( "Input is not a valid spreadsheet CSV.");
        }
    }

    public static OperationResult<string, string, string> ValidateArchiveZip(string input)
    {
        // ZIP archive validation is not applicable for string input
        return OperationResult<string, string, string>.Failure( "ZIP archive validation is not supported.");
    }

    public static OperationResult<string, string, string> ValidateUserDecided(string input)
    {
        // User-decided format validation is not applicable
        return OperationResult<string, string, string>.Success(input);
    }

    public static OperationResult<string, string, string> ValidateDouble(string input)
    {
        // Check if the input is not null or empty and can be parsed as a double
        if (!string.IsNullOrEmpty(input) && double.TryParse(input, out _))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid double.");
    }

    public static OperationResult<string, string, string> ValidateHtml(string input)
    {
        // Regular expression pattern to match HTML tags
        string htmlPattern = @"<(?:""|')?([a-zA-Z][a-zA-Z0-9]*)\b[^>]*>.*?</\1>|<([a-zA-Z][a-zA-Z0-9]*)\b[^/>]*/>|<!--.*?-->";

        // Check if the input matches the HTML pattern
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, htmlPattern, RegexOptions.Singleline))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid HTML.");
    }


    public static OperationResult<string, string, string> ValidateSummery(string input)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[A-Z][^.!?]*(?:[.!?](?!['""'\)]?\s|$)[^.!?]*)*[.!?]?['""'\)]?(?=\s|$)"))
        {
            return OperationResult<string, string, string>.Success(input);
        }
        return OperationResult<string, string, string>.Failure("Input is not a valid sentence.");
    }

    public static OperationResult<string, string, string> ValidateJsonArrayKeyValuePairs(string input)
    {
        try
        {
            JArray jsonArray = JArray.Parse(input);

            if (jsonArray != null)
            {

                foreach (var item in jsonArray)
                {
                    if (!(item is JToken))
                    {
                        return OperationResult<string, string, string>.Failure("Input is not an array of key-value pairs.");
                    }
                }
            }
            else
            {
                return OperationResult<string, string, string>.Failure("Input is not an array.");
            }

            return OperationResult<string, string, string>.Success(input);
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
    }


    public static OperationResult<string, string, string> ValidateJsonArray(string input)
    {
        try
        {
            JArray jsonArray = JArray.Parse(input);

            // Check if parsed object is an array
            if (jsonArray != null)
            {
                return OperationResult<string, string, string>.Success(input);
            }
            else
            {
                return OperationResult<string, string, string>.Failure("Input is not a valid JSON array.");
            }
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
    }

    public static OperationResult<string, string, string> ValidateJsonObject(string input)
    {
        try
        {
            JObject jsonObject = JObject.Parse(input);

            if (jsonObject != null)
            {
                return OperationResult<string, string, string>.Success(input);
            }
            else
            {
                return OperationResult<string, string, string>.Failure("Input is not a valid JSON object.");
            }
        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
        }
	}

	public static OperationResult<string, string, string> ValidateAzureBICEPTemplate(string input)
	{
		try
		{

		
			if (string.IsNullOrWhiteSpace(input))
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid BICEP template.");
			}


			bool containsResourceKeyword = Regex.IsMatch(input, @"\bresource\b", RegexOptions.IgnoreCase);
			bool containsModuleKeyword = Regex.IsMatch(input, @"\bmodule\b", RegexOptions.IgnoreCase);
			bool containsParameterKeyword = Regex.IsMatch(input, @"\bparam\b", RegexOptions.IgnoreCase);
			bool containsVariableKeyword = Regex.IsMatch(input, @"\bvar\b", RegexOptions.IgnoreCase);
			bool containsOutputKeyword = Regex.IsMatch(input, @"\boutput\b", RegexOptions.IgnoreCase);


			if (!containsResourceKeyword && !containsModuleKeyword && !containsParameterKeyword && !containsVariableKeyword && !containsOutputKeyword)
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid BICEP template.");
			}


			bool containsResourceDeclaration = Regex.IsMatch(input, @"resource\s+\w+\s+'\w+'", RegexOptions.IgnoreCase);
			bool containsModuleDeclaration = Regex.IsMatch(input, @"module\s+\w+\s+'\w+'", RegexOptions.IgnoreCase);
			bool containsParameterDeclaration = Regex.IsMatch(input, @"param\s+\w+", RegexOptions.IgnoreCase);
			bool containsVariableDeclaration = Regex.IsMatch(input, @"var\s+\w+", RegexOptions.IgnoreCase);
			bool containsOutputDeclaration = Regex.IsMatch(input, @"output\s+\w+", RegexOptions.IgnoreCase);

			if (!containsResourceDeclaration && !containsModuleDeclaration && !containsParameterDeclaration && !containsVariableDeclaration && !containsOutputDeclaration)
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid BICEP template.");
			}

			// If all checks pass, the input string is considered a valid Bicep template
			return OperationResult<string, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<string, string, string> ValidatePythonCode(string input)
	{
		try
		{
			string pattern = @"
        ^                           # Start of the string
        (?:                         # Non-capturing group
            (?:                     # Non-capturing group
                \s*                 # Optional whitespace
                (?:                 # Non-capturing group
                    def\s+\w+\s*\(  # Function definition
                    |
                    class\s+\w+\s*  # Class definition
                    |
                    if\s+           # If statement
                    |
                    for\s+          # For loop
                    |
                    while\s+        # While loop
                    |
                    try\s*:         # Try block
                    |
                    except\s+       # Except block
                    |
                    with\s+         # With statement
                    |
                    import\s+       # Import statement
                    |
                    from\s+         # From import statement
                    |
                    \w+\s*=         # Variable assignment
                    |
                    \w+\s*\(        # Function call
                    |
                    \w+\s*\[        # List indexing
                    |
                    \w+\s*\.        # Attribute access
                    |
                    \#.*            # Comments
                    |
                    \s*             # Empty lines or whitespace
                )*                  # Zero or more occurrences
                \s*                 # Optional whitespace
            )+                      # One or more occurrences
        )?                          # Optional group
        $                           # End of the string
    ";


			pattern = Regex.Replace(pattern, @"\s+", "");
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);


			var result = regex.IsMatch(input);

			if (result == false)
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid Python code.");

			}
            
            return  OperationResult<string, string, string>.Success(input);
		}
		catch (Exception ex)
		{
			return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<string, string, string> ValidateAzurePowerShellScript(string input)
	{
		try
		{

			string pattern = @"^(?ms)(?:.*(?:function|filter)\s+[\w-]+\s*\{.*\})*(?:.*\r?\n)*$";

			var result = Regex.IsMatch(input, pattern);

			if (result == false)
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid PowerShell script.");

			}

			return OperationResult<string, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


	public static OperationResult<string, string, string> ValidateDotNetCode(string input)
	{
		try
		{

			string pattern = @"
            ^(
                (?:
                    (?:(?:public|private|protected|internal|static|virtual|override|abstract|sealed|extern|partial)\s+)*
                    (?:class|struct|interface|enum)\s+\w+\s*
                    (?:<[^>]*>\s*)?
                    (?:\([^)]*\)\s*)?
                    (?:\s*:\s*\w+(?:\.\w+)?\s*(?:,\s*\w+(?:\.\w+)?)*)?
                    \s*{
                )
                |
                (?:
                    (?:(?:public|private|protected|internal|static|virtual|override|abstract|sealed|extern|partial)\s+)*
                    (?:void|int|float|double|bool|char|string|object|decimal|long|short|byte|uint|ulong|ushort|sbyte)\s+
                    \w+\s*\([^)]*\)\s*{
                )
            )
            [\s\S]*
            ^}
        ";

			RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace;
			var result = Regex.IsMatch(input, pattern, options);
			
			if (result == false)
			{
				return OperationResult<string, string, string>.Failure($"Input is not valid PowerShell script.");

			}

			return OperationResult<string, string, string>.Success(input);

		}
		catch (Exception ex)
		{
			return OperationResult<string, string, string>.Failure($"Input is not valid JSON. Error: {ex.Message}");
		}
	}


    public static OperationResult<string, string, string> ValidateAzurePowerShellScriptRequirements(string input)
    {
        try
        {

            

            return OperationResult<string, string, string>.Success(input);

        }
        catch (Exception ex)
        {
            return OperationResult<string, string, string>.Failure($"Input is not valid Powershell requirements. Error: {ex.Message}");
        }
    }


    

}
