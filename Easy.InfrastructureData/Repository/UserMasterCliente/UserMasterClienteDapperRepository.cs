using Dapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using System.Data;

namespace Easy.InfrastructureData.Repository.UserMasterCliente
{
    public class UserMasterClienteDapperRepository : IUserMasterClienteDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserMasterClienteDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<UserEntity>> GetUsersClientesAsync()
        {
            try
            {
                string query =
                    @"SELECT * FROM desenvolvimento.usermastercliente as user_master
                      JOIN desenvolvimento.aspnetusers as user on user_master.UserMasterId = user.Id";
                return await _dbConnection.QueryAsync<UserEntity>(query);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
