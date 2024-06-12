using OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;
using static System.Net.Mime.MediaTypeNames;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.FactoryN;


public interface ILLMActionFactory
{
	/// <summary>
	/// Question and answer LLM task.
	/// </summary>
	/// <returns></returns>
	public QuestionAnswer QuestionAnswer();

	/// <summary>
	/// Sentiment classification LLM task.
	/// </summary>
	/// <returns></returns>
	public SentimentClassification SentimentClassification();

	/// <summary>
	///  Text summarization LLM task.
	/// </summary>
	/// <returns></returns>
	public TextSummarization TextSummarization();


	/// <summary>
	///  Named entity recognition LLM task.
	/// </summary>
	/// <returns></returns>
	public NamedEntityRecognition NamedEntityRecognition();

	/// <summary>
	///  Text completion LLM task.
	/// </summary>
	/// <returns></returns>
	public TextCompletion TextCompletion();


	/// <summary>
	/// Paraphrasing LLM task.
	/// </summary>
	/// <returns></returns>
	public Paraphrasing Paraphrasing();

	/// <summary>
	/// Grammar correction LLM task.
	/// </summary>
	/// <returns></returns>
	public GrammarCorrection GrammarCorrection();


	/// <summary>
	/// Text simplification LLM task.
	/// </summary>
	/// <returns></returns>
	public TextSimplification TextSimplification();



	/// <summary>
	/// Create an Azure template LLM task.
	/// </summary>
	/// <returns></returns>
	public CreateMicrosoftBICEPTemplate CreateMicrosoftBICEPTemplate();


	/// <summary>
	/// Validate an Azure template LLM task.
	/// </summary>
	/// <returns></returns>
	public ValidateAzureBicep ValidateAzureBicep();


	/// <summary>
	/// Create an Azure PowerShell script LLM task.
	/// </summary>
	/// <returns></returns>
	public CreateAzurePowerShellScript CreateAzurePowerShellScript();




}