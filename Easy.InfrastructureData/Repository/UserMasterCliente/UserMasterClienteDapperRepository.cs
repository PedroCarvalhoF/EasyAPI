using Dapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
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

        public async Task<IEnumerable<UserMasterClienteEntity>> GetUsersMastersClientesAsync()
        {
            string query = @"
                SELECT 
                    o.UserMasterId, 
                    c.Id AS UserId, 
                    c.Nome, 
                    c.SobreNome, 
                    c.Email, 
                    c.UserName 
                FROM 
                    desenvolvimento.usermastercliente o 
                INNER JOIN 
                    desenvolvimento.aspnetusers c ON o.UserMasterId = c.Id";

            var userMasters = await _dbConnection.QueryAsync<UserMasterClienteEntity, UserEntity, UserMasterClienteEntity>(
                query,
                (userMasterCliente, userEntity) =>
                {
                    userMasterCliente.UserMaster = userEntity;
                    return userMasterCliente;
                },
                splitOn: "UserId"
            );

            return userMasters;
        }

        public async Task<UserMasterClienteEntity> GetUserMasterClienteByIdAsync(Guid id)
        {
            string query = @"
                SELECT 
                    o.UserMasterId, 
                    c.Id AS UserId, 
                    c.Nome, 
                    c.SobreNome, 
                    c.Email, 
                    c.UserName 
                FROM 
                    desenvolvimento.usermastercliente o 
                INNER JOIN 
                    desenvolvimento.aspnetusers c ON o.UserMasterId = c.Id                ";

            var userMaster = await _dbConnection.QueryAsync<UserMasterClienteEntity, UserEntity, UserMasterClienteEntity>(
                query,
                (userMasterCliente, userEntity) =>
                {
                    userMasterCliente.UserMaster = userEntity;
                    return userMasterCliente;
                },
                new { UserMasterId = id },
                splitOn: "UserId"
            );

            return userMaster.FirstOrDefault();
        }
    }
}
