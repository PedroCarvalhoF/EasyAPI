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
    public async Task<IEnumerable<UserEntity>> GetUsersAsync()
    {
        string query = "SELECT * FROM aspnetusers";
        return await _dbConnection.QueryAsync<UserEntity>(query);
    }
    public async Task<UserEntity> GetUserByIdAsync(Guid id)
    {
        string query = "SELECT * FROM aspnetusers WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<UserEntity>(query, new { Id = id });
    }
    public async Task<UserEntity> GetUserByEmailAsync(string email)
    {
        string query = "SELECT * FROM aspnetusers WHERE Email = @email";
        return await _dbConnection.QueryFirstOrDefaultAsync<UserEntity>(query, new { Email = email });
    }
}
