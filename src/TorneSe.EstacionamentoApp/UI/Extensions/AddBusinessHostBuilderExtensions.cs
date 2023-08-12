using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Business;
using TorneSe.EstacionamentoApp.Business.Interfaces;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddBusinessHostBuilderExtensions
{
    public static IHostBuilder AddBusiness(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<IVeiculoBusiness, VeiculoBusiness>();
            services.AddTransient<IReservaBusiness, ReservaBusiness>();
            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
        });

        return hostBuilder;
    }
}
