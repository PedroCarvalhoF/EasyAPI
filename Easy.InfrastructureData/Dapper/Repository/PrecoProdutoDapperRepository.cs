using Dapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.EntitiesBD.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.InfrastructureData.Dapper.Queries;
using System.Data;

namespace Easy.InfrastructureData.Dapper.Repository
{
    public class PrecoProdutoDapperRepository(IDbConnection _dbConnection) : IPrecoProdutoDapperRepository<FiltroBase, PrecoProdutoEntityFilterDapper>
    {
        public async Task<IEnumerable<PrecoProdutoEntityViewBD>> GetPrecoProdutoFilterAsync(FiltroBase filtro, PrecoProdutoEntityFilterDapper filtroDapper)
        {
            try
            {
                if (filtroDapper.Id is { } id && id != Guid.Empty)
                {
                    var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecoProdutoByIdAsync(filtro, filtroDapper.Id);
                    var entityViewBD = await _dbConnection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                    return entityViewBD;
                }

                if (filtroDapper.GetAll.HasValue)
                {
                    if (filtroDapper.GetAll.Value)
                    {
                        var query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetAllPrecosProdutosAsync(filtro);
                        var entityViewBD = await _dbConnection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                        return entityViewBD;
                    }
                }

                if (!string.IsNullOrEmpty(filtroDapper.NomeDescricaoEquals))
                {
                    //REALIZEI UTILIZANDO NOME PRA APROVEITAR A CLASS PRECO PRODUTO ENTITY FILTER DAPPER
                    //BOM SERIA CONSULTAR VIA GUID DO PRODUTO
                    QueryModel query = PrecoProdutoDapperQueries<FiltroBase, PrecoProdutoEntityFilterDapper>.GetPrecosProdutosByNomeProdutoAsync(filtro, filtroDapper.NomeDescricaoEquals);
                    var entityViewBD = await _dbConnection.QueryAsync<PrecoProdutoEntityViewBD>(query.Query!, query.Parameter);
                    return entityViewBD;
                }

                throw new ArgumentException("Não foi possível realizar consulta com banco.Motivo: Não foi localizado filtro necessário para realizar consulta.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
