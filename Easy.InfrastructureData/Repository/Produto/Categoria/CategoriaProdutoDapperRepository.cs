using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.InfrastructureData.Dapper.Queries;
using System.Data;

namespace Easy.InfrastructureData.Repository.Produto.Categoria;

public class CategoriaProdutoDapperRepository : ICategoriaProdutoDapperRepository<FiltroBase>
{
    private readonly IDbConnection _dbConnection;

    public CategoriaProdutoDapperRepository(IDbConnection connection)
    {
        _dbConnection = connection;
    }

    public async Task<CategoriaProdutoEntity> GetCategoriaProdutoById(Guid idCategoria, FiltroBase filtro)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoByIdQuery(idCategoria, filtro);
            var entities = await _dbConnection.QuerySingleOrDefaultAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities ?? new CategoriaProdutoEntity();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoEnity(FiltroBase filtro)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoQuery(filtro);
            var entities = await _dbConnection.QueryAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities ?? new List<CategoriaProdutoEntity>();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
