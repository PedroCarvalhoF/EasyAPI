using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public static class CategoriaProdutoDapperQueries<F> where F : FiltroBase
    {
        public static QueryModel GetCategoriaProdutoQuery(F filtro)
        {
            var table = ContextMappingDapper.GetCategoriaProdutoTable();
            var query = @$"SELECT * FROM {table}                           
                            WHERE
                            UserMasterClienteIdentityId=@idCliente";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);
        }


        public static QueryModel GetCategoriaProdutoByIdQuery(Guid idCategoria, F filtro)
        {
            var table = ContextMappingDapper.GetCategoriaProdutoTable();
            var query = @$"SELECT * FROM {table}                           
                            WHERE
                            UserMasterClienteIdentityId=@idCliente
                            and
                            Id=@idCat";

            var parameters = new { idCliente = filtro.clienteId , idCat = idCategoria };

            return new QueryModel(query, parameters);
        }
    }
}
