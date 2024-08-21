using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces.Repository.PDV.Pedido;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.Pedido;

public class PedidoRepository : BaseRepository<PedidoEntity,FiltroBase>, IPedidoRepository<PedidoEntity, FiltroBase>
{
    protected readonly MyContext _contexto;
    private DbSet<PedidoEntity> _dbSet;
    public PedidoRepository(MyContext context) : base(context)
    {
        _contexto = context;
        _dbSet = context.Set<PedidoEntity>();
    }

    public async Task<IEnumerable<PedidoEntity>> SelectAsync(PedidoEntityFilter filter, FiltroBase filtro)
    {
        try
        {
            var query = _dbSet.AsQueryable();

            if (filter.Include)
            {
                query = query.Include(p_itens => p_itens.ItensPedido);
            }

            query = PedidoEntityFilter.QueryablePedidoEntity(query, filter);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
