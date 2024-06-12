using Microsoft.Extensions.DependencyInjection;
using OpenAgenticLabs.LLMZeroPrompt.Core;
using OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.FactoryN;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI;


//Set up dependency inject, dependency inject enables us to inject
//the required components into the Zero Prompt classes.
var serviceProvider = new ServiceCollection();
serviceProvider.RegisterOpenAiConnector();
serviceProvider.RegisterZeroPrompt();
var sp = serviceProvider.BuildServiceProvider();


//Get a copy of the Zero Prompt factory that we can use
//to create instances of the Zero Prompt Actions.
var __ = sp.GetService<ILLMActionFactory>();


//Now we can use the Zero Prompt Actions to interact with the OpenAI API, this one is the Question Action. Result will be a single word
var resultQSingleWord = await __.QuestionAnswer().Inp("What is the capital of Ireland", "A geographical question").ExAsSingleWordAsync();
if (resultQSingleWord.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultQSingleWord.FailureValue);
Console.WriteLine(resultQSingleWord.SuccessValue);


var resultQDouble = await __.QuestionAnswer().Inp("What is the population of Ireland", "A geographical question").ExAsAsDoubleAsync();
if (resultQDouble.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultQDouble.FailureValue);
Console.WriteLine(resultQDouble.SuccessValue.ToString());


//lets use the question again, now we will get the result as a sentence
var resultQSentence = await __.QuestionAnswer().Inp("What is the capital of Ireland", "A geographical question").ExAsASentenceAsync();
if (resultQSentence.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultQSentence.FailureValue);
Console.WriteLine(resultQSentence.SuccessValue);


//We are off to a good start, lets try a boolean
var resultQBool = await __.QuestionAnswer().Inp("The capital city of Ireland is the city of Cork", "A geographical question").ExAsAsBooleanAsync();
if (resultQBool.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultQBool.FailureValue);
Console.WriteLine(resultQBool.SuccessValue);

//and lets try return a bool
var resultSmBool = await __.SentimentClassification().Inp("Is it true this statement is positive: 'I was a bright and wonderful day in the small and happy town in Ireland called Fetahrd.'", "A Sentiment Classification of input").ExAsAsBooleanAsync();
if (resultSmBool.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultSmBool.FailureValue);
Console.WriteLine(resultSmBool.SuccessValue);

//And sentence
var resultSmSentence01 = await __.SentimentClassification().Inp("Classify the sentiment of the following text: 'I was a bright and wonderful day in the small and happy town in Ireland called Fetahrd.'", "I am trying to understand the sentiment of the text").ExAsASentenceAsync();
if (resultSmSentence01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultSmSentence01.FailureValue);
Console.WriteLine(resultSmSentence01.SuccessValue);

//And sentence
var resultSmSentence02 = await __.SentimentClassification().Inp("Classify the sentiment of following text in three words: 'I was a bright and wonderful day in the small and happy town in Ireland called Fetahrd.'", "A Sentiment Classification of input in just three words").ExAsASentenceAsync();
if (resultSmSentence02.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultSmSentence02.FailureValue);
Console.WriteLine(resultSmSentence02.SuccessValue);

//And we can forget to try out a little text summary
var resultTs01 = await __.TextSummarization().Inp(
    @"The rapid advancements in technology over the past few decades have transformed every aspect of our lives. From the way we communicate to how we work, learn, and entertain ourselves, technology has played a pivotal role. The advent of the internet and mobile devices has made information more accessible than ever before, allowing people to stay connected regardless of their geographical location. Moreover, innovations in artificial intelligence and machine learning are driving significant changes in various industries, including healthcare, finance, and transportation. As we move forward, it's essential to consider the ethical implications of these technological advancements and strive to use them for the greater good of society.",
    "I need this input text summarized").ExAsASentenceAsync();
if (resultTs01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultTs01.FailureValue);
Console.WriteLine(resultTs01.SuccessValue);

//And we can forget to try out a little text summary with a limit
var resultTs02 = await __.TextSummarization().Inp(
    @"The rapid advancements in technology over the past few decades have transformed every aspect of our lives. From the way we communicate to how we work, learn, and entertain ourselves, technology has played a pivotal role. The advent of the internet and mobile devices has made information more accessible than ever before, allowing people to stay connected regardless of their geographical location. Moreover, innovations in artificial intelligence and machine learning are driving significant changes in various industries, including healthcare, finance, and transportation. As we move forward, it's essential to consider the ethical implications of these technological advancements and strive to use them for the greater good of society.",
    "I need this input text summarized").ExAsASentenceAsync(10);
if (resultTs02.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultTs02.FailureValue);
Console.WriteLine(resultTs02.SuccessValue);

//We have to try out some text completion
var resultTc01 = await __.TextCompletion().Inp("In a galaxy far, far away, a young starship pilot named Zara was on a mission to deliver vital supplies to a remote space station", "Preform text completion").ExAsSentenceAsync();
if (resultTc01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultTc01.FailureValue);
Console.WriteLine(resultTc01.SuccessValue);

//And some paraphrasing
var resultPp01 = await __.Paraphrasing().Inp("The book was so engaging that she couldn't put it down until she had read the final page.", "Paraphrasing text input").ExAsASentenceAsync();
if (resultPp01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultPp01.FailureValue);
Console.WriteLine(resultPp01.SuccessValue);

//Amazing, have to try some grammar.
var resultGr01 = await __.GrammarCorrection().Inp("Me and my friend goed to the store to bought some milk but their was none left on the shelfs.", "Correct grammar text input").ExAsASentenceAsync();
if (resultGr01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultPp01.FailureValue);
Console.WriteLine(resultGr01.SuccessValue);

//So we are near the end of the action for now, this is our first actions and we have many more to come.
var result = await __.TextSimplification().Inp("The Great Wall of China, built over several centuries starting from the 7th century BC, is a series of fortifications and walls that stretch over 13,000 miles across the historical northern borders of ancient Chinese states and Imperial China.\nThe Great Wall of China is a famous ancient fortification in China. It was constructed over many centuries, beginning in the 7th century BC. The walls and fortifications extend for over 13,000 miles along the historical northern borders of ancient Chinese states and Imperial China, making it one of the largest building projects ever completed.", "Simplify text input").ExAsSentenceAsync();
if (resultGr01.OperationStatus != OperationResultOperationStatus.Success) throw new Exception(resultPp01.FailureValue);
Console.WriteLine(resultGr01.SuccessValue);

Console.WriteLine("Finished");
Console.ReadLine();