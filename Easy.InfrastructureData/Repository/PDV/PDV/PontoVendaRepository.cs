using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.PDV.Pdv;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.PDV;

public class PontoVendaRepository : IBaseRepository<PontoVendaEntity, FiltroBase>, IPontoVendaRepository<PontoVendaEntity, FiltroBase>
{
    protected readonly MyContext _context;
    private DbSet<PontoVendaEntity> _dbSet;

    public PontoVendaRepository(MyContext context)
    {
        _context = context;
        _dbSet = context.Set<PontoVendaEntity>();
    }

    public Task<PontoVendaEntity> InsertAsync(PontoVendaEntity item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PontoVendaEntity>> SelectAsync(FiltroBase filtro, bool includeAll = false)
    {
        throw new NotImplementedException();
    }

    public Task<PontoVendaEntity> SelectAsync(Guid id, FiltroBase filtro, bool includeAll = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PontoVendaEntity>> SelectAsync(PontoVendaQueryFilter pdvFiltro, FiltroBase filtro)
    {
        throw new NotImplementedException();
    }

    public PontoVendaEntity Update(PontoVendaEntity item)
    {
        throw new NotImplementedException();
    }
}
