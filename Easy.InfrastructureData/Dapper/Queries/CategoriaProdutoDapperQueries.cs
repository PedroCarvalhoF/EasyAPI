using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public static class CategoriaProdutoDapperQueries<F> where F : FiltroBase
    {
        private static readonly string nomeTabela = string.Empty;
        static CategoriaProdutoDapperQueries()
        {
            if (string.IsNullOrEmpty(nomeTabela))
                nomeTabela = ContextMappingDapper.GetTableNameCagoriasProdutos();
        }
        public static QueryModel GetCategoriaProdutoQuery(F filtro)
        {
            var query = @$"SELECT * FROM {nomeTabela}                           
                                WHERE
                                UserMasterClienteIdentityId=@idCliente";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);

        }
        public static QueryModel GetCategoriaProdutoByIdQuery(Guid? idCategoria, F filtro)
        {
            var query = @$"SELECT * FROM {nomeTabela}                           
                                  WHERE  UserMasterClienteIdentityId=@idCliente 
                                  AND Id=@idCat";

            var parameters = new { idCliente = filtro.clienteId, idCat = idCategoria };

            return new QueryModel(query, parameters);
        }
        public static QueryModel GetCategoriaProdutoEqualsCategoriaQuery(F filtro, string descricaoCategoria)
        {
            var query = @$"SELECT * FROM {nomeTabela}                           
                                  WHERE UserMasterClienteIdentityId=@idCliente
                                  AND    DescricaoCategoria  =@categoria  ";

            var parameters = new { idCliente = filtro.clienteId, categoria = descricaoCategoria };

            return new QueryModel(query, parameters);
        }
        public static QueryModel GetCategoriaProdutoContainsCategoriaQuery(F filtro, string descricaoCategoria)
        {
            var query = @$"SELECT * FROM {nomeTabela}                           
                                  WHERE UserMasterClienteIdentityId = @idCliente
                                  AND DescricaoCategoria LIKE @categoria";

            var parameters = new
            {
                idCliente = filtro.clienteId,
                categoria = descricaoCategoria
            };

            return new QueryModel(query, parameters);
        }

        public static QueryModel GetCategoriasProdutosHabilitadosDesabilitados(FiltroBase filtro, bool? habilitadoValue)
        {
            var query = @$"SELECT * FROM {nomeTabela}                           
                                  WHERE UserMasterClienteIdentityId = @idCliente
                                  AND Habilitado = @habilitado";

            var parameters = new
            {
                idCliente = filtro.clienteId,
                habilitado = habilitadoValue
            };

            return new QueryModel(query, parameters);
        }
    }
}
