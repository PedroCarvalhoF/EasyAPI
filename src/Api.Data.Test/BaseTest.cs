using Api.Data.Context;
using Api.Identity.Context;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            string desenvolvimento = $"Server=localhost;Port=3306;DataBase={dataBaseName};Uid=root;password=010203;";

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseMySql(desenvolvimento, serverVersion),
                  ServiceLifetime.Transient
            );

            serviceCollection.AddDbContext<IdentityDataContext>(options =>
                             options.UseMySql(desenvolvimento, serverVersion));

            // Adicionando DataProtection
            serviceCollection.AddDataProtection();

            // Adicionando Authentication
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            // Adicionando Identity
            serviceCollection.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
               .AddRoles<Role>()
               .AddRoleManager<RoleManager<Role>>()
               .AddSignInManager<SignInManager<User>>()
               .AddRoleValidator<RoleValidator<Role>>()
               .AddEntityFrameworkStores<IdentityDataContext>()
               .AddDefaultTokenProviders();

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}