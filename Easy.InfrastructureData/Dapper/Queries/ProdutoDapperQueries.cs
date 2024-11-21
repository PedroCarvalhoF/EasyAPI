using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public class ProdutoDapperQueries<F> where F : FiltroBase
    {
        public static QueryModel GetProdutosQuery(F filtro)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();            

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);
        }        
    }
}
