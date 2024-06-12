using Microsoft.Extensions.DependencyInjection;
using OpenAgenticLabs.LLMZeroPrompt.Core.ElevateN.FactoryN;


namespace OpenAgenticLabs.LLMZeroPrompt.Core;


/// <summary>
/// This extension is for registering JetPackForAI with DI.
/// </summary>
public static class ServiceCollectionExtensions
{

    public static IServiceCollection RegisterZeroPrompt(this IServiceCollection services)
    {

        services.AddSingleton<ILLMActionFactory, IllmActionFactory>();
        return services;
    }

}