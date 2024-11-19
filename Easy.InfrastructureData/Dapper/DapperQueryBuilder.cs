using Easy.Domain.Entities;

namespace Easy.InfrastructureData.Dapper
{
    public static class DapperQueryBuilder<T> where T : class
    {
        public static string BuildQuery(string tableName, FiltroBase filtro, string whereClause = "")
        {
            var baseWhere = $"WHERE UserMasterClienteIdentityId = {filtro.clienteId}";

            if (!string.IsNullOrWhiteSpace(whereClause))
            {
                baseWhere += $" AND {whereClause}";
            }

            var query = $"SELECT * FROM {tableName} {baseWhere}";

            return query;
        }


    }

}
