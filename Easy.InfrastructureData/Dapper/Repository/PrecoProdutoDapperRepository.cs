using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.EntitiesBD.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.InfrastructureData.Dapper.Queries;
using System.Data;

namespace Easy.InfrastructureData.Dapper.Repository
{
    public class PrecoProdutoDapperRepository : IPrecoProdutoDapperRepository<FiltroBase, PrecoProdutoEntityFilterDapper>
    {
        private readonly Func<IDbConnection> _connectionFactory;
        public PrecoProdutoDapperRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<PrecoProdutoEntityViewBD>> GetPrecoProdutoFilterAsync(FiltroBase filtro, PrecoProdutoEntityFilterDapper filtroDapper)
        {
            try
            {
                using var connection = _connectionFactory();
                connection.Open();

                if (filtroDapper.Id is { } id && id != Guid.Empty)
                {
                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecoProdutoByIdAsync(filtro, filtroDapper.Id);
                    return await connection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                }

                if (filtroDapper.GetAll.HasValue && filtroDapper.GetAll.Value)
                {
                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetAllPrecosProdutosAsync(filtro);
                    return await connection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                }

                if (filtroDapper.Habilitado.HasValue)
                {
                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecosProdutoByHabilitado(filtro, filtroDapper.Habilitado);
                    return await connection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                }

                if (filtroDapper.CategoriaPrecoid is { } cat_id && cat_id != Guid.Empty)
                {
                    if (filtroDapper.IdProduto.HasValue && filtroDapper.IdProduto != Guid.Empty)
                    {
                        var queryExistis = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecosProdutoExists(filtro, filtroDapper.IdProduto, filtroDapper.CategoriaPrecoid);
                        return await connection.QueryAsync<PrecoProdutoEntityViewBD>(queryExistis.Query!, queryExistis.Parameter);
                    }

                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecosProdutoByCategoriaId(filtro, filtroDapper.CategoriaPrecoid);
                    return await connection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                }

                if (filtroDapper.IdProduto is { } idProduto && idProduto != Guid.Empty)
                {
                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecosProdutosByProdutoIdAsync(filtro, filtroDapper.IdProduto);
                    return await connection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                }

                throw new ArgumentException("Não foi possível realizar consulta: Filtro inválido.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar preços: {ex.Message}", ex);
            }
        }
    }
}
