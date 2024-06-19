using Dapper;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using System.Data;

namespace Easy.InfrastructureData.Repository.Dapper
{
    //SELECT * FROM desenvolvimento.usermastercliente o INNER JOIN  desenvolvimento.aspnetusers c ON o.UserMasterId = c.Id;
    public class UserMasterClienteDapperRepository : IUserMasterClienteDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserMasterClienteDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<UserMasterClienteEntity>> GetUsersMastersClientesAsync()
        {
            string query = "SELECT * FROM desenvolvimento.usermastercliente o INNER JOIN  desenvolvimento.aspnetusers c ON o.UserMasterId = c.Id";
            var result = await _dbConnection.QueryAsync<UserMasterClienteEntity>(query);

            return result;
        }
        public async Task<UserMasterClienteEntity> GetUserMasterClienteByIdAsync(Guid id)
        {
            string query = "SELECT * FROM usermastercliente WHERE UserMasterId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<UserMasterClienteEntity>(query, new { UserMasterId = id });
        }
    }
}
