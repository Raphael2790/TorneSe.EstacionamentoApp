using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.UI.Factories;
using TorneSe.EstacionamentoApp.UI.Factories.Interfaces;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddFactoriesHostBuilderExtensions
{
    public static IHostBuilder AddFactories(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IViewFactory, ViewFactory>();
        });
        return hostBuilder;
    }
}
