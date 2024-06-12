using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;



/// <summary>
/// Provides lookup methods for descriptions and Python examples related to ElevateOutputTypes.
/// </summary>
public static class ElevateOutputTypeLookup
{
    /// <summary>
    /// Get the description of the input type.
    /// </summary>
    /// <param name="format">The input type.</param>
    /// <returns>Description of the input type.</returns>
    public static string GetDescription(LLMTaskDescriptionOutputFormats format)
    {
        switch (format)
        {
            case LLMTaskDescriptionOutputFormats.None:
                return "Indicates the absence of a specified return type.";
            case LLMTaskDescriptionOutputFormats.SingleWord:
                return "Represents a single word as a return type.";
            case LLMTaskDescriptionOutputFormats.TwoWords:
                return "Represents a pair of words as a return type.";
            case LLMTaskDescriptionOutputFormats.ThreeWords:
                return "Represents a trio of words as a return type.";
            case LLMTaskDescriptionOutputFormats.CommaDelimited:
                return "Comma-separated list of items.";
            case LLMTaskDescriptionOutputFormats.Json:
                return "Data formatted as JSON (JavaScript Object Notation).";
            case LLMTaskDescriptionOutputFormats.Xml:
                return "Data formatted as XML (eXtensible Markup Language).";
            case LLMTaskDescriptionOutputFormats.Sentence:
                return "A single sentence.";
            case LLMTaskDescriptionOutputFormats.Paragraph:
                return "A single paragraph of text.";
            case LLMTaskDescriptionOutputFormats.SpaceSeparated:
                return "List of items separated by spaces.";
            case LLMTaskDescriptionOutputFormats.PipeSeparated:
                return "List of items separated by pipes (|).";
            case LLMTaskDescriptionOutputFormats.NewlineSeparated:
                return "List of items separated by newline characters.";
            case LLMTaskDescriptionOutputFormats.MultipleSentences:
                return "Multiple sentences grouped together.";
            case LLMTaskDescriptionOutputFormats.MultipleParagraphs:
                return "Multiple paragraphs of text.";
            case LLMTaskDescriptionOutputFormats.Int:
                return "An integer number.";
            case LLMTaskDescriptionOutputFormats.Float:
                return "A floating-point number.";
            case LLMTaskDescriptionOutputFormats.Boolean:
                return "A Boolean value (true or false).";
            case LLMTaskDescriptionOutputFormats.Date:
                return "A date without time.";
            case LLMTaskDescriptionOutputFormats.Time:
                return "A specific time without a date.";
            case LLMTaskDescriptionOutputFormats.DateTime:
                return "A combination of date and time.";
            case LLMTaskDescriptionOutputFormats.Url:
                return "A Uniform Resource Locator (URL).";
            case LLMTaskDescriptionOutputFormats.Email:
                return "An email address.";
            case LLMTaskDescriptionOutputFormats.PhoneNumber:
                return "A telephone number.";
            case LLMTaskDescriptionOutputFormats.Uuid:
                return "A universally unique identifier (UUID).";
            case LLMTaskDescriptionOutputFormats.Regex:
                return "A regular expression pattern.";
            case LLMTaskDescriptionOutputFormats.Html:
                return "Data formatted as HTML (HyperText Markup Language).";
            case LLMTaskDescriptionOutputFormats.Csv:
                return "Data formatted as CSV (Comma-Separated Values).";
            case LLMTaskDescriptionOutputFormats.Tsv:
                return "Data formatted as TSV (Tab-Separated Values).";
            case LLMTaskDescriptionOutputFormats.Yaml:
                return "Data formatted as YAML (YAML Ain't Markup Language).";
            case LLMTaskDescriptionOutputFormats.Toml:
                return "Data formatted as TOML (Tom's Obvious, Minimal Language).";
            case LLMTaskDescriptionOutputFormats.Ini:
                return "Data formatted in INI file format.";
            case LLMTaskDescriptionOutputFormats.Markdown:
                return "Text formatted in Markdown.";
            case LLMTaskDescriptionOutputFormats.RichText:
                return "Text formatted in a rich text format.";
            case LLMTaskDescriptionOutputFormats.Binary:
                return "Binary data.";
            case LLMTaskDescriptionOutputFormats.Image:
                return "An image file.";
            case LLMTaskDescriptionOutputFormats.Audio:
                return "An audio file.";
            case LLMTaskDescriptionOutputFormats.Video:
                return "A video file.";
            case LLMTaskDescriptionOutputFormats.TextDocument:
                return "This is a text document and has text as the type of information in the document.";
            case LLMTaskDescriptionOutputFormats.SpreadsheetCsv:
                return "A spreadsheet file formatted as CSV.";
            case LLMTaskDescriptionOutputFormats.ArchiveZip:
                return "A ZIP archive file.";
            default:
                return "Unknown input type.";
        }
    }

    /// <summary>
    /// Get a Python example for the input type.
    /// </summary>
    /// <param name="format">The input type.</param>
    /// <returns>Python example for the input type.</returns>
    public static string GetPythonExample(LLMTaskDescriptionOutputFormats format)
    {
        switch (format)
        {
            case LLMTaskDescriptionOutputFormats.None:
                return "None";
            case LLMTaskDescriptionOutputFormats.SingleWord:
                return "'hello'";
            case LLMTaskDescriptionOutputFormats.TwoWords:
                return "'hello world'";
            case LLMTaskDescriptionOutputFormats.ThreeWords:
                return "'hello world again'";
            case LLMTaskDescriptionOutputFormats.CommaDelimited:
                return "'apple, banana, cherry'";
            case LLMTaskDescriptionOutputFormats.Json:
                return "{'name': 'John', 'age': 30}";
            case LLMTaskDescriptionOutputFormats.Xml:
                return "<person><name>John</name><age>30</age></person>";
            case LLMTaskDescriptionOutputFormats.Sentence:
                return "'This is a sentence.'";
            case LLMTaskDescriptionOutputFormats.Paragraph:
                return "'This is a paragraph. It contains multiple sentences.'";
            case LLMTaskDescriptionOutputFormats.SpaceSeparated:
                return "'item1 item2 item3'";
            case LLMTaskDescriptionOutputFormats.PipeSeparated:
                return "'item1|item2|item3'";
            case LLMTaskDescriptionOutputFormats.NewlineSeparated:
                return "'item1\\nitem2\\nitem3'";
            case LLMTaskDescriptionOutputFormats.MultipleSentences:
                return "'This is one sentence. This is another.'";
            case LLMTaskDescriptionOutputFormats.MultipleParagraphs:
                return "'Paragraph one.\\n\\nParagraph two.'";
            case LLMTaskDescriptionOutputFormats.Int:
                return "42";
            case LLMTaskDescriptionOutputFormats.Float:
                return "3.14159";
            case LLMTaskDescriptionOutputFormats.Boolean:
                return "True";
            case LLMTaskDescriptionOutputFormats.Date:
                return "'2023-01-01'";
            case LLMTaskDescriptionOutputFormats.Time:
                return "'23:59'";
            case LLMTaskDescriptionOutputFormats.DateTime:
                return "'2023-01-01T23:59:00'";
            case LLMTaskDescriptionOutputFormats.Url:
                return "'http://www.example.com'";
            case LLMTaskDescriptionOutputFormats.Email:
                return "'email@example.com'";
            case LLMTaskDescriptionOutputFormats.PhoneNumber:
                return "'123-456-7890'";
            case LLMTaskDescriptionOutputFormats.Uuid:
                return "'123e4567-e89b-12d3-a456-426655440000'";
            case LLMTaskDescriptionOutputFormats.Regex:
                return "'^a...s$'";
            case LLMTaskDescriptionOutputFormats.Html:
                return "'<p>Hello, world!</p>'";
            case LLMTaskDescriptionOutputFormats.Csv:
                return "'name,age\\nJohn,30\\nJane,25'";
            case LLMTaskDescriptionOutputFormats.Tsv:
                return "'name\tage\\nJohn\t30\\nJane\t25'";
            case LLMTaskDescriptionOutputFormats.Yaml:
                return "'name: John\\nage: 30'";
            case LLMTaskDescriptionOutputFormats.Toml:
                return "'[owner]\\nname = \"Tom Preston-Werner\"\\ndob = 1979-05-27T07:32:00-08:00'";
            case LLMTaskDescriptionOutputFormats.Ini:
                return "'[settings]\\nresolution = 1920x1080\\nfullscreen = true'";
            case LLMTaskDescriptionOutputFormats.Markdown:
                return "'**bold text**'";
            case LLMTaskDescriptionOutputFormats.RichText:
                return "'This is <b>bold</b> and this is <i>italic</i>'";
            case LLMTaskDescriptionOutputFormats.Binary:
                return "b'\\x89PNG\\r\\n\\x1a\\n'";
            case LLMTaskDescriptionOutputFormats.Image:
                return "'path/to/image.jpg'";
            case LLMTaskDescriptionOutputFormats.Audio:
                return "'path/to/audio.mp3'";
            case LLMTaskDescriptionOutputFormats.Video:
                return "'path/to/video.mp4'";
            //case LLMTaskDescriptionOutputFormats.DocumentTxt:
            //    return "'path/to/document.txt'";
            //case LLMTaskDescriptionOutputFormats.DocumentBin:
            //    return "'path/to/document.docx'";
            //case LLMTaskDescriptionOutputFormats.SpreadsheetCsv:
            //    return "'path/to/spreadsheet.csv'";
            //case LLMTaskDescriptionOutputFormats.ArchiveZip:
            //    return "'path/to/archive.zip'";
            default:
                return "None";
        }
    }
}

