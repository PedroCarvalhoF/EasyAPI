using Easy.Domain.Entities;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.User;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Easy.InfrastructureData.Repository.UserMasterUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;

namespace Easy.CrossCutting.DependencyInjection.Extensions
{
    public static class IdentityConfiguration
    {
        public static void Configurar(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersionAutoDetec = ServerVersion.AutoDetect(connectionString);

            string? desenvolvimento = "Server=localhost;Port=3306;DataBase=desenvolvimento;Uid=root;password=010203;";
            serviceCollection.
            AddDbContext<MyContext>(options =>
                         options.UseMySql(desenvolvimento, serverVersionAutoDetec));


            serviceCollection.AddDefaultIdentity<UserEntity>()
                .AddRoles<RoleEntity>()
                .AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders();

            serviceCollection.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            serviceCollection.AddScoped<IUserDappperRepository, UserDapperRepository>();
            serviceCollection.AddScoped<IUserMasterClienteDapperRepository, UserMasterClienteDapperRepository>();
            serviceCollection.AddScoped<IUserMasterUserDapperRepository<FiltroBase>, UserMasterUserDapperRepository>();
        }
    }
}
