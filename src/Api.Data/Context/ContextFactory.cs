using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {

            string DefaultConnectionDESENVOLVIMENTO = "Server=localhost;Port=3306;DataBase=RESET_BANCO;Uid=root;password=010203;";

            DbContextOptionsBuilder<MyContext> optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(DefaultConnectionDESENVOLVIMENTO, new MySqlServerVersion(new Version(8, 0, 21)));

            return new MyContext(optionsBuilder.Options);
        }
    }
}
