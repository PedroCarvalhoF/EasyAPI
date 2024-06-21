using Dapper;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using System.Data;

namespace Easy.InfrastructureData.Repository.Dapper;

public class UserMasterUserDapperRepository : IUserMasterUserDapperRepository
{
    private readonly IDbConnection _dbConnection;

    public UserMasterUserDapperRepository(IDbConnection db)
    {
        _dbConnection = db;
    }

    public async Task<UserMasterUserEntity> GetUserMasterClienteByIdAsync(Guid id)
    {
        string query = "SELECT * FROM usermasteruserentity WHERE Id = @UserClienteId";
        return await _dbConnection.QueryFirstOrDefaultAsync<UserMasterUserEntity>(query, new { UserClienteId = id });
    }

    public async Task<IEnumerable<UserMasterUserEntity>> GetUsersMastersClientesAsync()
    {
        string query = "SELECT * FROM usermasteruserentity";
        return await _dbConnection.QueryAsync<UserMasterUserEntity>(query);
    }
}
