
using Easy.CrossCutting.DependencyInjection.Extensions;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Repository;
using Easy.InfrastructureData.Repository.UsuarioMasterCliente;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            ConfiguracaoBancoDados.Configurar(serviceCollection, configuration);
            ServiceCollectionUserIdentity.Configure(serviceCollection);

            // UnitOfWork
            serviceCollection.AddScoped<IUsuarioMasterClienteRepository, UsuarioMasterClienteRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
