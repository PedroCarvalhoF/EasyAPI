using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces.Repository.PDV.ItemPedido;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.ItemPedido;

public class ItemPedidoRepository : BaseRepository<ItemPedidoEntity>, IItemPedidoRepository<ItemPedidoEntity, FiltroBase>
{
    private DbSet<ItemPedidoEntity> _dbSet;
    public ItemPedidoRepository(MyContext context) : base(context)
    {
        _dbSet = context.Set<ItemPedidoEntity>();
    }

    public async Task<IEnumerable<ItemPedidoEntity>> SelectAsync(ItemPedidoEntityFilter itemFiltro, FiltroBase filtro)
    {
        try
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = ItemPedidoEntityFilter.QueryableItemPedidoEntity(query, filtro);

                var result = await query.ToArrayAsync();

                return result;
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
