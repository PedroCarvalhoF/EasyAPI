using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public static class PrecoProdutoDapperQueries<F, FD> where F : FiltroBase where FD : PrecoProdutoEntityFilterDapper
    {
        static string _tableViewName = string.Empty;
        static PrecoProdutoDapperQueries()
        {
            if (string.IsNullOrEmpty(_tableViewName))
                _tableViewName = ContextMappingDapper.GetPrecoProdutoNomeView();
        }

        public static QueryModel GetAllPrecosProdutosAsync(F filtro)
        {
            var query = $@"SELECT * FROM {_tableViewName}
                           WHERE UserMasterClienteIdentityId = @idCliente 
                           ORDER BY NomeProduto,DescricaoCategoriaPreco";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);
        }

        public static QueryModel GetPrecoProdutoByIdAsync(FiltroBase filtro, Guid? idPrecoProdutoInput)
        {
            var query = $@"SELECT * FROM {_tableViewName}
                           WHERE UserMasterClienteIdentityId = @idCliente AND PrecoProdutoId= @idPrecoProduto";

            var parameters = new { idCliente = filtro.clienteId, idPrecoProduto = idPrecoProdutoInput };

            return new QueryModel(query, parameters);
        }

        public static QueryModel GetPrecosProdutosByNomeProdutoAsync(FiltroBase filtro, string? nomeDescricaoEqualsInput)
        {
            var query = $@"SELECT * FROM {_tableViewName}
                           WHERE UserMasterClienteIdentityId = @idCliente AND NomeProduto= @nome_produto
                           ORDER BY NomeProduto,DescricaoCategoriaPreco" ;

            var parameters = new { idCliente = filtro.clienteId, nome_produto = nomeDescricaoEqualsInput };

            return new QueryModel(query, parameters);
        }

        public static QueryModel GetPrecosProdutosByProdutoIdAsync(FiltroBase filtro, Guid? idProdutoInput)
        {
            var query = $@"SELECT * FROM {_tableViewName}
                           WHERE UserMasterClienteIdentityId = @idCliente AND ProdutoId= @produto_id
                           ORDER BY NomeProduto,DescricaoCategoriaPreco";

            var parameters = new { idCliente = filtro.clienteId, produto_id = idProdutoInput };

            return new QueryModel(query, parameters);
        }

        internal static QueryModel GetPrecosProdutoByHabilitado(FiltroBase filtro, bool? habilitadoInput)
        {
            var query = $@"SELECT * FROM {_tableViewName}
                           WHERE UserMasterClienteIdentityId = @idCliente AND PrecoHabilitado= @preco_habilitado
                           ORDER BY NomeProduto,DescricaoCategoriaPreco";

            var parameters = new { idCliente = filtro.clienteId, preco_habilitado = habilitadoInput };

            return new QueryModel(query, parameters);
        }
    }
}
