﻿using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Signatures;
using OpenAgenticLabs.LLMZeroPrompt.Core.Elevate.Types;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.LLMTasksN;


/// <summary>
/// The TextSummarization class is designed to work with the corresponding LLM
/// to summarize input text. This class offers a variety of methods to assist with
/// tasks related to text summarization.
/// </summary>
/// <param name="llmConnector">The connector to be used to make a calls to LLM.</param>
public class ValidateAzureBicep(ILLMConnectorV2 llmConnector)
{

    private string _question = string.Empty;
    private string _context = string.Empty;
    private readonly ILLMConnectorV2 _llmConnector = llmConnector;

    public ValidateAzureBicep Inp(string question, string context)
    {
        _question = question;
        _context = context;
        return this;
    }


    /// <summary>
    /// Calling this method will invoke the LLM and summarize  the input text.
    /// </summary>
    /// <returns>The summarized input text</returns>
    public async Task<OperationResult<bool, string, string>> ExAsABoolAsync(int? numberOfWords = null)
    {
        var target = GetType().FullName;
        var tdca = new LLMTaskDescriptionBuilder<string, bool>(target, LLMTaskDescriptionInputFormats.AzureBICEPTemplate, LLMTaskDescriptionOutputFormats.Boolean, _llmConnector);
        var result = await tdca.InvokeAsync(_question);

        return OperationResult<bool, string, string>.Success(result.SuccessValue);
    }




}



