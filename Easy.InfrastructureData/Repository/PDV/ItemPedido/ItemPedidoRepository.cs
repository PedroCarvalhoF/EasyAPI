using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces.Repository.PDV.ItemPedido;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.PDV.ItemPedido;

public class ItemPedidoRepository : BaseRepository<ItemPedidoEntity, FiltroBase>, IItemPedidoRepository<ItemPedidoEntity, FiltroBase>
{
    private DbSet<ItemPedidoEntity> _dbSet;
    public ItemPedidoRepository(MyContext context) : base(context)
    {
        _dbSet = context.Set<ItemPedidoEntity>();
    }

    public async Task<IEnumerable<ItemPedidoEntity>> SelectAsync(ItemPedidoEntityFilter itemFiltro, FiltroBase filtro, bool includeAll = false)
    {
        try
        {
            try
            {
                IQueryable<ItemPedidoEntity> query = _dbSet.AsNoTracking();

                query = ItemPedidoEntityFilter.QueryablePedidoEntity(query, itemFiltro);

                query = query.FiltroCliente(filtro);

                if (includeAll)
                {
                    query = query.Include(item_produto => item_produto.Produto);

                    query = query.Include(item_pedido => item_pedido.Pedido);
                }

                query = query.OrderBy(item => item.Cancelado).ThenBy(item=>item.CreateAt);

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
