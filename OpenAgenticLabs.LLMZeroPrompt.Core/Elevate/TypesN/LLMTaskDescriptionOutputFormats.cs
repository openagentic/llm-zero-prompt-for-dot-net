namespace OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;

/// <summary>
/// These represent the types of answers that can be returned from the Elevate API.
/// </summary>
public enum LLMTaskDescriptionOutputFormats
{
    None = 0, ///<summary>Indicates the absence of a specified return type.</summary>
    SingleWord = 1, ///<summary>Represents a single word as a return type.</summary>
    TwoWords = 2, ///<summary>Represents a pair of words as a return type.</summary>
    ThreeWords = 3, ///<summary>Represents a trio of words as a return type.</summary>
    CommaDelimited = 4, ///<summary>Comma-separated list of items.</summary>
    Json = 5, ///<summary>Data formatted as JSON (JavaScript Object Notation).</summary>
    Xml = 6, ///<summary>Data formatted as XML (eXtensible Markup Language).</summary>
    Sentence = 7, ///<summary>A single sentence.</summary>
    Paragraph = 8, ///<summary>A single paragraph of text.</summary>
    SpaceSeparated = 9, ///<summary>List of items separated by spaces.</summary>
    PipeSeparated = 10, ///<summary>List of items separated by pipes (|).</summary>
    NewlineSeparated = 11, ///<summary>List of items separated by newline characters.</summary>
    MultipleSentences = 12, ///<summary>Multiple sentences grouped together.</summary>
    MultipleParagraphs = 13, ///<summary>Multiple paragraphs of text.</summary>
    Int = 14, ///<summary>An integer number.</summary>
    Float = 15, ///<summary>A floating-point number.</summary>
    Boolean = 16, ///<summary>A Boolean value (true or false).</summary>
    Date = 17, ///<summary>A date without time.</summary>
    Time = 18, ///<summary>A specific time without a date.</summary>
    DateTime = 19, ///<summary>A combination of date and time.</summary>
    Url = 20, ///<summary>A Uniform Resource Locator (URL).</summary>
    Email = 21, ///<summary>An email address.</summary>
    PhoneNumber = 22, ///<summary>A telephone number.</summary>
    Uuid = 23, ///<summary>A universally unique identifier (UUID).</summary>
    Regex = 24, ///<summary>A regular expression pattern.</summary>
    Html = 25, ///<summary>Data formatted as HTML (HyperText Markup Language).</summary>
    Csv = 26, ///<summary>Data formatted as CSV (Comma-Separated Values).</summary>
    Tsv = 27, ///<summary>Data formatted as TSV (Tab-Separated Values).</summary>
    Yaml = 28, ///<summary>Data formatted as YAML (YAML Ain't Markup Language).</summary>
    Toml = 29, ///<summary>Data formatted as TOML (Tom's Obvious, Minimal Language).</summary>
    Ini = 30, ///<summary>Data formatted in INI file format.</summary>
    Markdown = 31, ///<summary>Text formatted in Markdown.</summary>
    RichText = 32, ///<summary>Text formatted in a rich text format.</summary>
    Binary = 33, ///<summary>Binary data.</summary>
    Image = 34, ///<summary>An image file.</summary>
    Audio = 35, ///<summary>An audio file.</summary>
    Video = 36, ///<summary>A video file.</summary>
    TextDocument = 37, ///<summary>A text document file.</summary>
    SpreadsheetCsv = 38, ///<summary>A spreadsheet file formatted as CSV.</summary>
    ArchiveZip = 39, ///<summary>A ZIP archive file.</summary>
    UserDecided = 40, ///<summary>This is a user defined value.</summary>
    Double = 41, ///<summary>A number.</summary>
    Summary = 42, ///<summary>A summary of input text.</summary>
    JsonArrayKeyValuePairs = 43, ///<summary>A json array of key value pairs.</summary>
    JsonArray = 44, ///<summary>A json array of key value pairs.</summary>
    JsonObject = 45, ///<summary>A json array of key value pairs.</summary>
    AzureBICEPTemplate = 46, ///<summary>Azure BICEP template.</summary>
	PythonCode = 47, ///<summary>Python Code.</summary>
	AzurePowerShellScript = 48, ///<summary>Azure PowerShell Script.</summary>
	DotNetCode = 49, ///<summary>Dot NET code</summary>
    AzurePowerShellScriptRequirements = 50, ///<summary>Azure PowerShell script requirements</summary>





}
