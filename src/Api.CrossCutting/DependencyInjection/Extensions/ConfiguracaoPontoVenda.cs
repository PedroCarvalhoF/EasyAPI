using Application.UseCases.Handlers.PontoVenda.Periodo;
using Application.UseCases.Handlers.PontoVenda;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Handlers.PontoVenda.Usuario;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoPontoVenda
    {
        public static void PontoVendas(this IServiceCollection serviceCollection)
        {
            //PERIODO PONTO DE VENDA
            serviceCollection.AddTransient<PeriodoPontoVendaServiceHandler>();

            //PONTO DE VENDA
            serviceCollection.AddTransient<PontoVendaServiceHandler>();

            //USUARIO PONTO DE VENDA
            serviceCollection.AddTransient<RegistrarUsuarioPontoVendaHandler>();
        }
    }
}
