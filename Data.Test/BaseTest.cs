using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public abstract class BaseTest
    {
        protected BaseTest()
        {

        }
    }

    public class DtTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DtTeste()
        {
            ServiceCollection serviceColleciton = new ServiceCollection();
            string strConexao = $"Server=localhost;Port=3306;DataBase=dbTest_{dataBaseName};Uid=root;password=010203;";

            serviceColleciton.AddDbContext<MyContext>(o => o.UseMySql(strConexao, new MySqlServerVersion(new Version(8, 0, 21))), ServiceLifetime.Transient);

            ServiceProvider = serviceColleciton.BuildServiceProvider();
            using (MyContext? context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (MyContext? context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}