using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Identity.Context
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityDataContext>
    {
        public IdentityDataContext CreateDbContext(string[] args)
        {
            //string DefaultConnectionDESENVOLVIMENTO = "Server=localhost;Port=3306;DataBase=RESET_BANCO;Uid=root;password=010203;";

            string TestUmbler = "Server=mysql246.umbler.com;Port=41890;DataBase=teste_easy;Uid=admin_teste;password=010203++teste;";

            DbContextOptionsBuilder<IdentityDataContext> optionsBuilder = new DbContextOptionsBuilder<IdentityDataContext>();
            optionsBuilder.UseMySql(TestUmbler, new MySqlServerVersion(new Version(8, 0, 21)));

            return new IdentityDataContext(optionsBuilder.Options);
        }
    }
}
