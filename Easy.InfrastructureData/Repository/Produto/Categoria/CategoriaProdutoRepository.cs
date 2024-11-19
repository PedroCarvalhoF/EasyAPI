using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.Produto.Categoria;

public class CategoriaProdutoRepository : BaseRepository<CategoriaProdutoEntity, FiltroBase>, ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>
{

    private DbSet<CategoriaProdutoEntity> _dbSet;

    public CategoriaProdutoRepository(MyContext context) : base(context)
    {
        _dbSet = context.Set<CategoriaProdutoEntity>();
    }

    public async Task<IEnumerable<CategoriaProdutoEntity>> SelectAsync(CategoriaProdutoEntityFilter filter, FiltroBase filtro, bool includeAll = true)
    {
        try
        {
            try
            {
                IQueryable<CategoriaProdutoEntity> query = _dbSet.AsNoTracking();

                query = CategoriaProdutoEntityFilter.QueryableEntity(query, filter);

                if (includeAll)
                {
                }

                query = query.FiltroCliente(filtro);

                query = query.OrderBy(categoria => categoria.DescricaoCategoria);

                var resultQuery = await query.ToArrayAsync();

                return resultQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}