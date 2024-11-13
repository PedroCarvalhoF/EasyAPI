using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces.Repository.PDV.Periodo;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.PDV.Periodo;

public class PeriodoPdvRepository : BaseRepository<PeriodoPdvEntity, FiltroBase>, IPeriodoPdvRepository<PeriodoPdvEntity, FiltroBase>
{
    private DbSet<PeriodoPdvEntity> _dbSet;
    public PeriodoPdvRepository(MyContext contexto) : base(contexto)
    {
        _dbSet = contexto.Set<PeriodoPdvEntity>();
    }

    public async Task<IEnumerable<PeriodoPdvEntity>> SelectAsync(PeriodoPdvEntityFilter filter, FiltroBase filtro, bool includeAll = true)
    {
        try
        {
            IQueryable<PeriodoPdvEntity> query = _dbSet.AsNoTracking();

            query = PeriodoPdvEntityFilter.QueryableEntity(query, filter);

            query = query.FiltroCliente(filtro);

            if (includeAll)
            {
            }

            query = query.OrderByDescending(pedido => pedido.CreateAt);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
