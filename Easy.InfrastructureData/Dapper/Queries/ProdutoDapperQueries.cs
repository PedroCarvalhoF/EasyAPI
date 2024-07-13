using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public class ProdutoDapperQueries<F> where F : FiltroBase
    {
        public static QueryModel GetProdutosQuery(F filtro)
        {
            var tableProduto = ContextMappingDapper.GetProdutoTable();
            var tableCategoriaProduto = ContextMappingDapper.GetCategoriaProdutoTable();

            var query = $@"SELECT * FROM
                           {tableProduto} as prod
                           JOIN
                           {tableCategoriaProduto} as cat_prod
                           ON prod.CategoriaProdutoEntityId = cat_prod.Id
                           WHERE prod.UserMasterClienteIdentityId = @idCliente";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);
        }

        public static QueryModel GetProdutoByIdQuery(Guid idProduto, F filtro)
        {
            var tableProduto = ContextMappingDapper.GetProdutoTable();
            var tableCategoriaProduto = ContextMappingDapper.GetCategoriaProdutoTable();

            var query = $@"SELECT * FROM
                           {tableProduto} as prod
                           JOIN
                           {tableCategoriaProduto} as cat_prod
                           ON prod.CategoriaProdutoEntityId = cat_prod.Id
                           WHERE prod.UserMasterClienteIdentityId = @idCliente and prod.Id=@idProd;";

            var parameters = new { idCliente = filtro.clienteId, idProd = idProduto };

            return new QueryModel(query, parameters);
        }
    }
}
