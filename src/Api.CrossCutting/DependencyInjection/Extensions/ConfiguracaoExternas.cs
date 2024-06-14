using Domain.Interfaces.Services.HGApis;
using Domain.Interfaces.Services.ViaCEP;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.HGApis;
using Service.Services.ViaCEP;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoExternas
    {
        public static void Configure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IViaCepService, ViaCEPServices>();
            serviceCollection.AddScoped<ITaxasCDISelicService, TaxasCDISelicService>();
        }
    }
}
