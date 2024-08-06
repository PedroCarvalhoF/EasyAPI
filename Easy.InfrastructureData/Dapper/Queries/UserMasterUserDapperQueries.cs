using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public class UserMasterUserDapperQueries<F> where F : FiltroBase
    {
        public static QueryModel GetUserMasterUserByIdUser(Guid userId)
        {
            var tableUserMasterUser = ContextMappingDapper.GetUserMasterUserTable();
            var tableUser = ContextMappingDapper.GetUserTable();

            var query = $@"SELECT * FROM
                           {tableUserMasterUser} as userMaster
                           JOIN 
                           {tableUser} as users
                           ON userMaster.UserMasterId = users.Id
                           WHERE userMaster.UserMasterId=@idUser;";

            var parameters = new { idUser = userId };

            return new QueryModel(query, parameters);
        }
    }
}
