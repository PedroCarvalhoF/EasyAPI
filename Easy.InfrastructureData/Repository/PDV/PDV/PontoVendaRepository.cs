using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.PDV.Pdv;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.PDV;

public class PontoVendaRepository : IBaseRepository<PontoVendaEntity>, IPontoVendaRepository<PontoVendaEntity, FiltroBase>
{
    protected readonly MyContext _context;
    private DbSet<PontoVendaEntity> _dbSet;

    public PontoVendaRepository(MyContext context)
    {
        _context = context;
        _dbSet = context.Set<PontoVendaEntity>();
    }
    public async Task<PontoVendaEntity> InsertAsync(PontoVendaEntity item)
    {
        try
        {
            var result = await _dbSet.AddAsync(item);
            return item;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IEnumerable<PontoVendaEntity>> SelectAsync(FiltroBase filtro)
    {
        try
        {
            var result = await
                _dbSet.AsNoTracking()
                .FiltroCliente(filtro)
                .ToArrayAsync();
            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PontoVendaEntity> SelectAsync(Guid id, FiltroBase filtro)
    {
        try
        {
            var result = await
                _dbSet.AsNoTracking()
                .FiltroCliente(filtro)
                .SingleOrDefaultAsync(pdv => pdv.Id == id);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<PontoVendaEntity>> SelectAsync(PontoVendaQueryFilter pdvFiltro, FiltroBase filtro)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            query = query.FiltroCliente(filtro);

            query = PontoVendaQueryFilter.FiltroPontoVenda(query, pdvFiltro);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public Task<PontoVendaEntity> UpdateAsync(PontoVendaEntity item, FiltroBase filtro)
    {
        try
        {
            _context.Update(item);
            return Task.FromResult(item);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
