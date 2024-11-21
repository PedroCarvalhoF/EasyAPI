using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.EntitiesBD.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.InfrastructureData.Dapper.Queries;
using System.Data;

namespace Easy.InfrastructureData.Dapper.Repository
{
    public class ProdutoDapperRepository : IProdutoDapperRepository<FiltroBase>
    {
        private readonly IDbConnection _dbConnection;
        public ProdutoDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutoByIdAsync(FiltroBase filtro, Guid produtoId)
        {
            try
            {
                var query = ProdutoDapperQueries<FiltroBase>.GetProdutoByIdAsync(filtro, produtoId);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetAllProdutosAsync(FiltroBase filtro)
        {
            try
            {
                var query = ProdutoDapperQueries<FiltroBase>.GetAllProdutosAsync(filtro);

                var entities = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByHabilitadoAsync(FiltroBase filtro, bool habilitado)
        {
            try
            {
                QueryModel query = ProdutoDapperQueries<FiltroBase>.GetProdutosByHabilitadoAsync(filtro, habilitado);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByNomeDescricaoEqualsAsync(FiltroBase filtro, string nomeProduto)
        {
            try
            {
                QueryModel query = ProdutoDapperQueries<FiltroBase>.GetProdutosByNomeDescricaoEqualsAsync(filtro, nomeProduto);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByNomeDescricaoContainsAsync(FiltroBase filtro, string nomeDescricaoContains)
        {
            try
            {
                QueryModel query = ProdutoDapperQueries<FiltroBase>.GetProdutosByNomeDescricaoContainsAsync(filtro, nomeDescricaoContains);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByCategoriaIdAsync(FiltroBase filtro, Guid? idCategoria)
        {
            try
            {
                QueryModel query = ProdutoDapperQueries<FiltroBase>.GetProdutosByCategoriaIdAsync(filtro, idCategoria);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByCodigoAsync(FiltroBase filtro, string codigo)
        {
            try
            {
                QueryModel query = ProdutoDapperQueries<FiltroBase>.GetProdutosByCodigoAsync(filtro, codigo);

                var entityViewBD = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entityViewBD;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
