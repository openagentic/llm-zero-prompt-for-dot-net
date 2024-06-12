using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using OpenAgenticLabs.LLMZeroPrompt.Core.LlmN;
using OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;
using OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;

namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI.OptimisedPromptPack;


public class OptimisedPromptPackForOpenAi : IOptimisedPromptPack
{

    /// <summary>
    /// This will get a list of supported models.
    /// </summary>
    /// <returns>ModelInformationList will be returned and it container a list of information on supported LLM models.</returns>
    public OperationResult<ModelInformationList, string, string> GetModelsSupported()
    {
        return GetSupportedModels();
    }


    /// <summary>
    /// This will get a list of optimised prompt pack associated with a model.
    /// </summary>
    /// <param name="modelName">The model name to get the optimized prompt packs for.</param>
    /// <returns></returns>
    public OperationResult<List<OptimizedPromptPackItems>, string, string> GetPromptPacksForModel(string modelName)
    {

        return GetPromptPackForModels(modelName);

    }


    /// <summary>
    /// This will get the model optimised prompt pack by its name. 
    /// </summary>
    /// <param name="modelName"></param>
    /// <returns></returns>
    public OperationResult<OptimizedPromptPackItems, string, string> GetAllPromptPackForAllModels()
    {
        return GetPromptPackForAllModels();
    }



    /// <summary>
    /// This will get a list of supported models.
    /// </summary>
    /// <returns>ModelInformationList will be returned and it container a list of information on supported LLM models.</returns>
    public static OperationResult<ModelInformationList, string, string> GetSupportedModels()
    {
        var currentAssembly = typeof(OptimisedPromptPackForOpenAi).Assembly;
        var result = ModelInformation.GetAllSupportedModels(currentAssembly, "llm_supported_models.json");
        if (result.OperationStatus != OperationResultOperationStatus.Success) return result;

        return OperationResult<ModelInformationList, string, string>.Success(result.SuccessValue);
    }


    /// <summary>
    /// This will get a list of optimised prompt pack models for this name. 
    /// </summary>
    /// <param name="modelName"></param>
    /// <returns></returns>
    public static OperationResult<List<OptimizedPromptPackItems>, string, string> GetPromptPackForModels(string modelName)
    {

        var currentAssembly = Assembly.GetExecutingAssembly();

        var allPromptPackFileNames = GetListOptimisedPromptPackNames(currentAssembly, "OptimisedPromptPack");

        var promptPackNameList = allPromptPackFileNames.SuccessValue.PromptPacks;

        var optimizedPromptPackItems = new List<OptimizedPromptPackItems>();

        foreach (var item in promptPackNameList)
        {
            var getPromptPackResult = GetPromptPackFromAssemblyByName(currentAssembly, item.Name);
            if (getPromptPackResult.OperationStatus != OperationResultOperationStatus.Success)
            {
                OperationResult<List<OptimizedPromptPackItems>, string, string>.Failure(
                    getPromptPackResult.FailureValue);
            }

            optimizedPromptPackItems.Add(getPromptPackResult.SuccessValue);

        }

        var promptPackItemsListResult = SearchForSupportingPromptPackByModelName(optimizedPromptPackItems, modelName);

        return promptPackItemsListResult;

    }

    public static OperationResult<List<OptimizedPromptPackItems>, string, string> SearchForSupportingPromptPackByModelName(List<OptimizedPromptPackItems> promptPackList, string modelName)
    {

        var promptPackItemsList = new List<OptimizedPromptPackItems>();

        foreach (var item in promptPackList)
        {
            if (item!=null && item.OptimizedPromptPackItem.Count > 0)
            {

                if (item.OptimizedPromptPackItem.Count > 0)
                {
                    foreach (var optimizedPromptPackItem in item.OptimizedPromptPackItem)
                    {
                        if (optimizedPromptPackItem.Targets.Count > 0)
                        {
                            foreach (var target in optimizedPromptPackItem.Targets)
                            {
                                if (target.Models.Count > 0)
                                {
                                    foreach (var model in target.Models)
                                    {
                                        if (model.ModelName.Trim().ToLower() == modelName.ToLower())
                                        {
                                            promptPackItemsList.Add(item);
                                        }

                                    }
                                }

                            }
                        }
                    }
                }

            }

        }

        return OperationResult<List<OptimizedPromptPackItems>, string, string>.Success(promptPackItemsList);
    }

    /// <summary>
    /// This method will load a prompt pack item form an assembly
    /// </summary>
    /// <param name="assembly">Assembly to get the prompt pack item from.</param>
    /// <param name="promptPackName">The name of the prompt pack item.</param>
    /// <returns></returns>
    public static OperationResult<OptimizedPromptPackItems, string, string> GetPromptPackFromAssemblyByName(Assembly assembly, string promptPackName)
    {

        var json = string.Empty;

        using (Stream stream = assembly.GetManifestResourceStream(promptPackName))
        {
            if (stream == null)
            {
                return OperationResult<OptimizedPromptPackItems, string, string>.Failure($"Resource '{promptPackName}' not found. Make sure it is an Embedded Resource.");
            }

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
        }

        var promptPackItem = JsonConvert.DeserializeObject<OptimizedPromptPackItems>(json);

        return OperationResult<OptimizedPromptPackItems, string, string>.Success(promptPackItem);

    }


    /// <summary>
    /// This will get the model optimised prompt pack by its name. 
    /// </summary>
    /// <param name="modelName"></param>
    /// <returns></returns>
    public static OperationResult<OptimizedPromptPackItems, string, string> GetPromptPackForAllModels()
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var result = OptimizedPromptPackItems.ReadFromEmbeddedResource(currentAssembly, "llm_supported_models.json");
        if (result.OperationStatus != OperationResultOperationStatus.Success)
        {
            return result;
        }

        return OperationResult<OptimizedPromptPackItems, string, string>.Failure("modelInformation");

    }


    /// <summary>
    /// This will return a list names of all the prompt packs.
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="subFolder"></param>
    /// <returns></returns>
    private static OperationResult<PromptPackList, string, string> GetListOptimisedPromptPackNames(Assembly assembly, string subFolder)
    {

        var resourceName = "llm_optimized_prompt_packs.json";
        var json = string.Empty;

        string resourcePath = assembly.GetName().Name + "." + subFolder + "." + resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".");
        using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
        {
            if (stream == null)
            {
                return OperationResult<PromptPackList, string, string>.Failure($"Resource '{resourceName}' not found. Make sure it is an Embedded Resource.");
            }

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
        }

        var promptPackList = JsonConvert.DeserializeObject<PromptPackList>(json);

        return OperationResult<PromptPackList, string, string>.Success(promptPackList);

    }


    private class PromptPack
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    private class PromptPackList
    {
        [JsonProperty("promptPacks")]
        public List<PromptPack> PromptPacks { get; set; }
    }

}

