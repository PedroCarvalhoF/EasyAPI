using Easy.CrossCutting.DependencyInjection.Extensions;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Repository;
using Easy.InfrastructureData.Repository.Dapper;
using Easy.InfrastructureData.Repository.Produto;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<BaseEntity,FiltroBase>), typeof(BaseRepository<BaseEntity, FiltroBase>));
            serviceCollection.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            ConfiguracaoBancoDados.Configurar(serviceCollection, configuration);
            ServiceCollectionUserIdentity.Configure(serviceCollection);

            // UnitOfWork
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //Dapper
            serviceCollection.AddScoped<IUserMasterClienteDapperRepository, UserMasterClienteDapperRepository>();
            serviceCollection.AddScoped<IUserDapperRepository, UserDapperRepository>();
            serviceCollection.AddScoped<IUserMasterUserDapperRepository, UserMasterUserDapperRepository>();


            serviceCollection.AddScoped<ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>, CategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>>();

            var myhandlers = AppDomain.CurrentDomain.Load("Easy.Services");
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

        }
    }
}
