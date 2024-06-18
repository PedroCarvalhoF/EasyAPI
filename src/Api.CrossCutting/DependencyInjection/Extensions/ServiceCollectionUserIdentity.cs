using Application.UseCases.Handlers.User;
using Application.UseCases.Handlers.UserMasterCliente;
using Application.UseCases.Handlers.UserMasterUser;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ServiceCollectionUserIdentity
    {
        public static void Configure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserIdentityHandler>();
            serviceCollection.AddTransient<UserGetHandler>();
            serviceCollection.AddTransient<UserMasterClienteHandler>();

            serviceCollection.AddScoped<UserMasterUserHadler>();
        }
    }
}
