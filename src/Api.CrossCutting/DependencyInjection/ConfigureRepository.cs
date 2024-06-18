using Api.Data.Repository;
using Application.Interfaces.Repository;
using CrossCutting.DependencyInjection.Extensions;
using Data.Repository;
using Domain.Entities.UserMasterCliente;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            serviceCollection.AddScoped(typeof(IUsuarioMasterClienteRepository<>),typeof(UsuarioMasterClienteRepository<>));

            ConfiguracaoBancoDados.Configurar(serviceCollection, configuration);
            ServiceCollectionUserIdentity.Configure(serviceCollection);

        }
    }
}
