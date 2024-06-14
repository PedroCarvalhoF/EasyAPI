using Data.Implementations.UserMasterCliente;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.IQueres.UserMasterCliente;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoIQuery
    {
        public static void Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IUserMasterClienteQuery<>), typeof(UserMasterClienteQuery<>));
            serviceCollection.AddScoped<IUserMasterClienteRepository, UserMasterClienteImplementacao>();
        }
    }
}
