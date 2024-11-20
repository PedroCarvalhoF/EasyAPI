using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.InfrastructureData.Dapper.Mapping;
using Easy.InfrastructureData.Dapper.Queries;
using System.Data;

namespace Easy.InfrastructureData.Dapper.Repository;

public class CategoriaProdutoDapperRepository(IDbConnection _dbConnection) : ICategoriaProdutoDapperRepository<FiltroBase>
{
    private readonly string nomeTabela = ContextMappingDapper.GetTableNameCagoriasProdutos();
    public async Task<CategoriaProdutoEntity> GetCategoriaProdutoByIdCategoria(Guid? idCategoria, FiltroBase filtro)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoByIdQuery(idCategoria, filtro);
            var entities = await _dbConnection.QuerySingleOrDefaultAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasProdutoAsync(FiltroBase filtro)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoQuery(filtro);
            var entities = await _dbConnection.QueryAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoEqualsCategoriaQuery(FiltroBase filtro, string descricaoCategoria)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoEqualsCategoriaQuery(filtro, descricaoCategoria);
            var entities = await _dbConnection.QueryAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoContainsCategoriaQuery(FiltroBase filtro, string descricaoCategoria)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriaProdutoContainsCategoriaQuery(filtro, descricaoCategoria);
            var entities = await _dbConnection.QueryAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasProdutosHabilitadosDesabilitados(FiltroBase filtro, bool? habilitado)
    {
        try
        {
            var query = CategoriaProdutoDapperQueries<FiltroBase>.GetCategoriasProdutosHabilitadosDesabilitados(filtro, habilitado);
            var entities = await _dbConnection.QueryAsync<CategoriaProdutoEntity>(query.Query!, query.Parameter);
            return entities;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
