using Api.Domain.Interfaces.Services.Identity;
using Api.Identity.Interfaces;
using Api.Identity.Services;
using Data.Implementations.UserMasterCliente;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.Interfaces.Services.UserMasterCliente;
using Identity.Interfaces;
using Identity.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.UserMaster;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoUsersUsersIdentities
    {
        public static void UsersUsersIdentities(this IServiceCollection serviceCollection)
        {
            //USERS
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRole, UserRoleServices>();
            serviceCollection.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            
            //USERS CLIENTES/SUB USERS
            serviceCollection.AddTransient<IUserMasterClienteServices, UserMasterClienteServices>();
            serviceCollection.AddTransient<IUserMasterClienteRepository, UserMasterClienteImplementacao>();
        }
    }
}
