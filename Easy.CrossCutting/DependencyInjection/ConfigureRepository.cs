using Easy.CrossCutting.DependencyInjection.Extensions;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Repository;
using Easy.InfrastructureData.Repository.Dapper;
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
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //Dapper
            serviceCollection.AddScoped<IUserMasterClienteDapperRepository, UserMasterClienteDapperRepository>();
            serviceCollection.AddScoped<IUserDapperRepository, UserDapperRepository>();

            var myhandlers = AppDomain.CurrentDomain.Load("Easy.Services");
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

        }
    }
}
