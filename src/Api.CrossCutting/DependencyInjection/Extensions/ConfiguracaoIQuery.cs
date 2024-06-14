using Domain.IQueres;
using Domain.IQueres.UserMasterCliente;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoIQuery
    {
        public static void Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IQueryBase<>), typeof(UserMasterClienteQuery<>));
        }
    }
}
