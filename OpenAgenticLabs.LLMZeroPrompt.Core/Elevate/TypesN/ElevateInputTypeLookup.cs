
namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;



/// <summary>
/// Provides lookup methods for descriptions and Python examples related to ElevateInputTypes.
/// </summary>
public static class ElevateInputTypeLookup
{
    /// <summary>
    /// Get the description of the input type.
    /// </summary>
    /// <param name="format">The input type.</param>
    /// <returns>Description of the input type.</returns>
    public static string GetDescription(LLMTaskDescriptionInputFormats format)
    {
        switch (format)
        {
            case LLMTaskDescriptionInputFormats.None:
                return "Indicates the absence of a specified return type.";
            case LLMTaskDescriptionInputFormats.SingleWord:
                return "Represents a single word as a return type.";
            case LLMTaskDescriptionInputFormats.TwoWords:
                return "Represents a pair of words as a return type.";
            case LLMTaskDescriptionInputFormats.ThreeWords:
                return "Represents a trio of words as a return type.";
            case LLMTaskDescriptionInputFormats.CommaDelimited:
                return "Comma-separated list of items.";
            case LLMTaskDescriptionInputFormats.Json:
                return "Data formatted as JSON (JavaScript Object Notation).";
            case LLMTaskDescriptionInputFormats.Xml:
                return "Data formatted as XML (eXtensible Markup Language).";
            case LLMTaskDescriptionInputFormats.Sentence:
                return "A single sentence.";
            case LLMTaskDescriptionInputFormats.Paragraph:
                return "A single paragraph of text.";
            case LLMTaskDescriptionInputFormats.SpaceSeparated:
                return "List of items separated by spaces.";
            case LLMTaskDescriptionInputFormats.PipeSeparated:
                return "List of items separated by pipes (|).";
            case LLMTaskDescriptionInputFormats.NewlineSeparated:
                return "List of items separated by newline characters.";
            case LLMTaskDescriptionInputFormats.MultipleSentences:
                return "Multiple sentences grouped together.";
            case LLMTaskDescriptionInputFormats.MultipleParagraphs:
                return "Multiple paragraphs of text.";
            case LLMTaskDescriptionInputFormats.Int:
                return "An integer number.";
            case LLMTaskDescriptionInputFormats.Float:
                return "A floating-point number.";
            case LLMTaskDescriptionInputFormats.Boolean:
                return "A Boolean value (true or false).";
            case LLMTaskDescriptionInputFormats.Date:
                return "A date without time.";
            case LLMTaskDescriptionInputFormats.Time:
                return "A specific time without a date.";
            case LLMTaskDescriptionInputFormats.DateTime:
                return "A combination of date and time.";
            case LLMTaskDescriptionInputFormats.Url:
                return "A Uniform Resource Locator (URL).";
            case LLMTaskDescriptionInputFormats.Email:
                return "An email address.";
            case LLMTaskDescriptionInputFormats.PhoneNumber:
                return "A telephone number.";
            case LLMTaskDescriptionInputFormats.Uuid:
                return "A universally unique identifier (UUID).";
            case LLMTaskDescriptionInputFormats.Regex:
                return "A regular expression pattern.";
            case LLMTaskDescriptionInputFormats.Html:
                return "Data formatted as HTML (HyperText Markup Language).";
            case LLMTaskDescriptionInputFormats.Csv:
                return "Data formatted as CSV (Comma-Separated Values).";
            case LLMTaskDescriptionInputFormats.Tsv:
                return "Data formatted as TSV (Tab-Separated Values).";
            case LLMTaskDescriptionInputFormats.Yaml:
                return "Data formatted as YAML (YAML Ain't Markup Language).";
            case LLMTaskDescriptionInputFormats.Toml:
                return "Data formatted as TOML (Tom's Obvious, Minimal Language).";
            case LLMTaskDescriptionInputFormats.Ini:
                return "Data formatted in INI file format.";
            case LLMTaskDescriptionInputFormats.Markdown:
                return "Text formatted in Markdown.";
            case LLMTaskDescriptionInputFormats.RichText:
                return "Text formatted in a rich text format.";
            case LLMTaskDescriptionInputFormats.Binary:
                return "Binary data.";
            case LLMTaskDescriptionInputFormats.Image:
                return "An image file.";
            case LLMTaskDescriptionInputFormats.Audio:
                return "An audio file.";
            case LLMTaskDescriptionInputFormats.Video:
                return "A video file.";
            case LLMTaskDescriptionInputFormats.TextDocument:
                return "This is a text document and has text as the type of information in the document.";
            case LLMTaskDescriptionInputFormats.SpreadsheetCsv:
                return "A spreadsheet file formatted as CSV.";
            //case LLMTaskDescriptionInputFormats.ArchiveZip:
            //    return "A ZIP archive file.";
            default:
                return "Unknown input type.";
        }
    }

    /// <summary>
    /// Get a Python example for the input type.
    /// </summary>
    /// <param name="format">The input type.</param>
    /// <returns>Python example for the input type.</returns>
    public static string GetPythonExample(LLMTaskDescriptionInputFormats format)
    {
        switch (format)
        {
            case LLMTaskDescriptionInputFormats.None:
                return "None";
            case LLMTaskDescriptionInputFormats.SingleWord:
                return "'hello'";
            case LLMTaskDescriptionInputFormats.TwoWords:
                return "'hello world'";
            case LLMTaskDescriptionInputFormats.ThreeWords:
                return "'hello world again'";
            case LLMTaskDescriptionInputFormats.CommaDelimited:
                return "'apple, banana, cherry'";
            case LLMTaskDescriptionInputFormats.Json:
                return "{'name': 'John', 'age': 30}";
            case LLMTaskDescriptionInputFormats.Xml:
                return "<person><name>John</name><age>30</age></person>";
            case LLMTaskDescriptionInputFormats.Sentence:
                return "'This is a sentence.'";
            case LLMTaskDescriptionInputFormats.Paragraph:
                return "'This is a paragraph. It contains multiple sentences.'";
            case LLMTaskDescriptionInputFormats.SpaceSeparated:
                return "'item1 item2 item3'";
            case LLMTaskDescriptionInputFormats.PipeSeparated:
                return "'item1|item2|item3'";
            case LLMTaskDescriptionInputFormats.NewlineSeparated:
                return "'item1\\nitem2\\nitem3'";
            case LLMTaskDescriptionInputFormats.MultipleSentences:
                return "'This is one sentence. This is another.'";
            case LLMTaskDescriptionInputFormats.MultipleParagraphs:
                return "'Paragraph one.\\n\\nParagraph two.'";
            case LLMTaskDescriptionInputFormats.Int:
                return "42";
            case LLMTaskDescriptionInputFormats.Float:
                return "3.14159";
            case LLMTaskDescriptionInputFormats.Boolean:
                return "True";
            case LLMTaskDescriptionInputFormats.Date:
                return "'2023-01-01'";
            case LLMTaskDescriptionInputFormats.Time:
                return "'23:59'";
            case LLMTaskDescriptionInputFormats.DateTime:
                return "'2023-01-01T23:59:00'";
            case LLMTaskDescriptionInputFormats.Url:
                return "'http://www.example.com'";
            case LLMTaskDescriptionInputFormats.Email:
                return "'email@example.com'";
            case LLMTaskDescriptionInputFormats.PhoneNumber:
                return "'123-456-7890'";
            case LLMTaskDescriptionInputFormats.Uuid:
                return "'123e4567-e89b-12d3-a456-426655440000'";
            case LLMTaskDescriptionInputFormats.Regex:
                return "'^a...s$'";
            case LLMTaskDescriptionInputFormats.Html:
                return "'<p>Hello, world!</p>'";
            case LLMTaskDescriptionInputFormats.Csv:
                return "'name,age\\nJohn,30\\nJane,25'";
            case LLMTaskDescriptionInputFormats.Tsv:
                return "'name\tage\\nJohn\t30\\nJane\t25'";
            case LLMTaskDescriptionInputFormats.Yaml:
                return "'name: John\\nage: 30'";
            case LLMTaskDescriptionInputFormats.Toml:
                return "'[owner]\\nname = \"Tom Preston-Werner\"\\ndob = 1979-05-27T07:32:00-08:00'";
            case LLMTaskDescriptionInputFormats.Ini:
                return "'[settings]\\nresolution = 1920x1080\\nfullscreen = true'";
            case LLMTaskDescriptionInputFormats.Markdown:
                return "'**bold text**'";
            case LLMTaskDescriptionInputFormats.RichText:
                return "'This is <b>bold</b> and this is <i>italic</i>'";
            case LLMTaskDescriptionInputFormats.Binary:
                return "b'\\x89PNG\\r\\n\\x1a\\n'";
            case LLMTaskDescriptionInputFormats.Image:
                return "'path/to/image.jpg'";
            case LLMTaskDescriptionInputFormats.Audio:
                return "'path/to/audio.mp3'";
            case LLMTaskDescriptionInputFormats.Video:
                return "'path/to/video.mp4'";
            //case LLMTaskDescriptionInputFormats.DocumentTxt:
            //    return "'path/to/document.txt'";
            //case LLMTaskDescriptionInputFormats.DocumentBin:
            //    return "'path/to/document.docx'";
            //case LLMTaskDescriptionInputFormats.SpreadsheetCsv:
            //    return "'path/to/spreadsheet.csv'";
            //case LLMTaskDescriptionInputFormats.ArchiveZip:
            //    return "'path/to/archive.zip'";
            default:
                return "None";
        }
    }
}

