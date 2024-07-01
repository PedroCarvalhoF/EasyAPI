using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces.Repository.PDV.Pedido;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.Pedido;

public class PedidoRepository : BaseRepository<PedidoEntity>, IPedidoRepository<PedidoEntity, FiltroBase>
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
            var query = _dbSet.AsNoTracking();

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
