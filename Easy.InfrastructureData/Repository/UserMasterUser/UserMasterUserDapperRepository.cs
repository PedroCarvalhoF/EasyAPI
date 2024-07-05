using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using System.Data;

namespace Easy.InfrastructureData.Repository.UserMasterUser;

public class UserMasterUserDapperRepository : IUserMasterUserDapperRepository<FiltroBase>
{
    private readonly IDbConnection _dbConnection;

    public UserMasterUserDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<UserEntity>> GetUsersMasterUsersAsync(FiltroBase filtro)
    {
        try
        {
            string query =
                @"SELECT * FROM desenvolvimento.usersmastersusers as user_master
                  JOIN desenvolvimento.aspnetusers as user
                  ON user_master.UserMasterUserId = user.Id
                  WHERE user_master.UserClienteId = @idCliente;"; 

            return await _dbConnection.QueryAsync<UserEntity>(query, new { idCliente = filtro.clienteId });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
