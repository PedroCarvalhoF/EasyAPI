using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
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

        public async Task<IEnumerable<ProdutoEntityViewBD>> GetAllProdutosAsync(FiltroBase filtro)
        {
            try
            {
                var query = ProdutoDapperQueries<FiltroBase>.GetProdutosQuery(filtro);

                var entities = await _dbConnection.QueryAsync<ProdutoEntityViewBD>(query.Query!, query.Parameter);

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<ProdutoEntity> GetProdutoById(Guid idProduto, FiltroBase filtro)
        {
            throw new NotImplementedException();
        }
    }
}
