using Easy.CrossCutting.DependencyInjection.Extensions;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Repository;
using Easy.InfrastructureData.Repository.Produto.Categoria;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Easy.InfrastructureData.Repository.UserMasterUser;
using Easy.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easy.CrossCutting.DependencyInjection
{
    public static class RegisterServices
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            IdentityConfiguration.Configurar(serviceCollection, configuration);

            serviceCollection.AddScoped(typeof(IBaseRepository<BaseEntity, FiltroBase>), typeof(BaseRepository<BaseEntity, FiltroBase>));

            serviceCollection.AddScoped<IUserService, UserService>();

            // UnitOfWork
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped(typeof(IUserMasterClienteRepository<>), typeof(UserMasterClienteRepository<>));
            serviceCollection.AddScoped(typeof(IUserMasterUserRepository<>), typeof(UserMasterUserRepository<>));

            serviceCollection.AddScoped
                (typeof(ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>),
                 typeof(CategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>));

            var myhandlers = AppDomain.CurrentDomain.Load("Easy.Services");
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));
        }
    }
}
