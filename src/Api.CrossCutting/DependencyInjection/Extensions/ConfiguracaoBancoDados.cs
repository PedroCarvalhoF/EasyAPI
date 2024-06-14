using Api.Data.Context;
using Api.Identity.Context;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoBancoDados
    {
        public static void Configurar(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString == "desenvolvimento")
            {
                string? desenvolvimento = "Server=localhost;Port=3306;DataBase=desenvolvimento;Uid=root;password=010203;";
                serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(desenvolvimento, serverVersion));

                serviceCollection.
                    AddDbContext<IdentityDataContext>(options =>
                                 options.UseMySql(desenvolvimento, serverVersion));
            }
            else
            if (connectionString == "producao_montana_vale_sul")
            {
                string? PRODUCAO_MYSQL_MONTANA_VALE_SUL = "Server=mysql246.umbler.com;Port=41890;DataBase=teste_easy;Uid=admin_teste;password=010203++teste;";

                serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(PRODUCAO_MYSQL_MONTANA_VALE_SUL, serverVersion));

                serviceCollection.
                    AddDbContext<IdentityDataContext>(options =>
                                 options.UseMySql(PRODUCAO_MYSQL_MONTANA_VALE_SUL, serverVersion));
            }


            serviceCollection.AddIdentityCore<User>()
           .AddRoles<Role>()
           .AddRoleManager<RoleManager<Role>>()
           .AddSignInManager<SignInManager<User>>()
           .AddRoleValidator<RoleValidator<Role>>()
           .AddEntityFrameworkStores<IdentityDataContext>()
           .AddDefaultTokenProviders();
        }
    }
}
