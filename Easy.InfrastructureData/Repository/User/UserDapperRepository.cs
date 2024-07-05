using Dapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.User;
using System.Data;

namespace Easy.InfrastructureData.Repository.User
{
    public class UserDapperRepository : IUserDappperRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAscyn()
        {
            string query = "SELECT * FROM desenvolvimento.aspnetusers;";
            return await _dbConnection.QueryAsync<UserEntity>(query);
        }
    }
}
