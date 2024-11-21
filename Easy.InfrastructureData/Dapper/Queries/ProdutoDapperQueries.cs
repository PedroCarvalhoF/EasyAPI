using Easy.Domain.Entities;
using Easy.InfrastructureData.Dapper.Mapping;

namespace Easy.InfrastructureData.Dapper.Queries
{
    public class ProdutoDapperQueries<F> where F : FiltroBase
    {
        //select
        //    `prod`.`Id` as `ProdutoId`,
        //    `prod`.`NomeProduto` as `NomeProduto`,
        //    `prod`.`Codigo` as `Codigo`,
        //    `prod`.`ImagemUrl` as `ImagemUrl`,
        //    `prod`.`MedidaProdutoEnum` as `MedidaProdutoEnum`,
        //    `prod`.`TipoProdutoEnum` as `TipoProdutoEnum`,
        //    `prod`.`Habilitado` as `Habilitado`,
        //    `cat_prod`.`Id` as `CategoriaId`,
        //    `cat_prod`.`DescricaoCategoria` as `DescricaoCategoria`,
        //    `prod`.`UserMasterClienteIdentityId` as `UserMasterClienteIdentityId`,
        //    `prod`.`UserId` as `UserId`
        //from
        //    (`desenvolvimento`.`produtos` `prod`
        //join `desenvolvimento`.`categoriasprodutos` `cat_prod` on
        //    ((`prod`.`CategoriaProdutoEntityId` = `cat_prod`.`Id`)))
        //order by
        //    `prod`.`NomeProduto`;
        public static QueryModel GetAllProdutosAsync(F filtro)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente";

            var parameters = new { idCliente = filtro.clienteId };

            return new QueryModel(query, parameters);
        }
        public static QueryModel GetProdutoByIdAsync(FiltroBase filtro, Guid idProdutoParametro)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND ProdutoId = @idProduto";

            var parameters = new { idCliente = filtro.clienteId, idProduto = idProdutoParametro };

            return new QueryModel(query, parameters);
        }
        public static QueryModel GetProdutosByHabilitadoAsync(FiltroBase filtro, bool habilitado)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND Habilitado = @habilitadoInput";

            var parameters = new { idCliente = filtro.clienteId, habilitadoInput = habilitado };

            return new QueryModel(query, parameters);
        }
        public static QueryModel GetProdutosByNomeDescricaoEqualsAsync(FiltroBase filtro, string nomeProdutoParamenter)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND NomeProduto = @nomeInput";

            var parameters = new { idCliente = filtro.clienteId, nomeInput = nomeProdutoParamenter };

            return new QueryModel(query, parameters);
        }

        internal static QueryModel GetProdutosByCategoriaIdAsync(FiltroBase filtro, Guid? idCategoria)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();            

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND CategoriaId = @categoriaIdInput";

            var parameters = new { idCliente = filtro.clienteId, categoriaIdInput = idCategoria };

            return new QueryModel(query, parameters);
        }

        internal static QueryModel GetProdutosByCodigoAsync(FiltroBase filtro, string codigo)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND Codigo = @codigoIdInput";

            var parameters = new { idCliente = filtro.clienteId, codigoIdInput = codigo };

            return new QueryModel(query, parameters);
        }

        internal static QueryModel GetProdutosByNomeDescricaoContainsAsync(FiltroBase filtro, string nomeDescricaoContains)
        {
            var vw_produtos = ContextMappingDapper.GetProdutosNomeView();

            var nomeInput = $"%{nomeDescricaoContains}%";

            var query = $@"SELECT * FROM {vw_produtos}
                           WHERE UserMasterClienteIdentityId = @idCliente
                           AND NomeProduto LIKE @nomeInput";

            var parameters = new { idCliente = filtro.clienteId, nomeInput = nomeInput };

            return new QueryModel(query, parameters);
        }
    }
}
