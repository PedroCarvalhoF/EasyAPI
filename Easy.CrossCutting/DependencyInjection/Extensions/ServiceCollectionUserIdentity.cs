using Microsoft.Extensions.DependencyInjection;

namespace Easy.CrossCutting.DependencyInjection.Extensions
{
    public static class ServiceCollectionUserIdentity
    {
        public static void Configure(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<UserIdentityHandler>();
            //serviceCollection.AddTransient<UserGetHandler>();
            //serviceCollection.AddTransient<UserMasterClienteHandler>();

            //serviceCollection.AddScoped<UserMasterUserHadler>();
        }
    }
}
