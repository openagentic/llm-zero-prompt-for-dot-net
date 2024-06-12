using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAgenticLabs.LLMZeroPrompt.Core.ConnectorsN;
using OpenAgenticLabs.LLMZeroPrompt.Core.OptimisedPromptPackN;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.Connector;
using OpenAgenticLabs.LLMZeroPrompt.OpenAI.OptimisedPromptPack;


namespace OpenAgenticLabs.LLMZeroPrompt.OpenAI;


public static class ServiceCollectionExtensions
{

    public static IServiceCollection RegisterOpenAiConnector(this IServiceCollection services)
    {

        services.AddSingleton<IOptimisedPromptPack, OptimisedPromptPackForOpenAi>();
        services.AddTransient<ILLMConnectorV2, ConnectorOpenForAiV2>();
        services.AddSingleton<IConnectorSettingsV2>(RegisterOpenAiConnector());


        return services;
    }

    public static OpenAiConnectorSettingsV2 RegisterOpenAiConnector()
    {
        var openAiConnectorSettings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();



        var modelConfig = new OpenAiConnectorModelSettingsV2(
            openAiConnectorSettings["OpenAIConnectorSetting:Model"],
            double.Parse(openAiConnectorSettings["OpenAIConnectorSetting:Temperature"]),
            double.Parse(openAiConnectorSettings["OpenAIConnectorSetting:TopP"]),
            int.Parse(openAiConnectorSettings["OpenAIConnectorSetting:N"]),
         bool.Parse(openAiConnectorSettings["OpenAIConnectorSetting:Stream"])

        );

        var connectorConfig = new OpenAiConnectorSettingsV2(
            Guid.Parse(openAiConnectorSettings["OpenAIConnectorSetting:SystemId"]),
            openAiConnectorSettings["OpenAIConnectorSetting:ApiKey"],
            modelConfig,
            openAiConnectorSettings["OpenAIConnectorSetting:BaseUrl"]
        );
        return connectorConfig;
    }


}




