using Dapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.User;
using System.Data;

namespace Easy.InfrastructureData.Repository.User;

public class UserDapperRepository : IUserDapperRepository
{
    private readonly IDbConnection _dbConnection;

    public UserDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<IEnumerable<UserEntity>> GetUsers()
    {
        string query = "SELECT `aspnetusers`.`Id`,    `aspnetusers`.`Nome`,    `aspnetusers`.`SobreNome`,        `aspnetusers`.`UserName`,      `aspnetusers`.`Email`   FROM `desenvolvimento`.`aspnetusers`;\r\n";
        return await _dbConnection.QueryAsync<UserEntity>(query);
    }
    public async Task<UserEntity> GetUserById(Guid id)
    {
        string query = "SELECT * FROM desenvolvimento.aspnetuser where Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<UserEntity>(query, new { Id = id });
    }
}
