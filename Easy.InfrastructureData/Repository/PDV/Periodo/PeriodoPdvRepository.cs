using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces.Repository.PDV.Periodo;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Easy.InfrastructureData.Tools.PeriodoPdv;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.Periodo;

public class PeriodoPdvRepository<T, F> : IPeriodoPdvRepository<T, F> where T : PeriodoPdvEntity where F : FiltroBase
{
    protected readonly MyContext _context;
    private DbSet<T> _dbSet;
    public PeriodoPdvRepository(MyContext contexto)
    {
        _context = contexto;
        _dbSet = contexto.Set<T>();
    }
    public async Task<IEnumerable<T>> SelectAsync(F filtro)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = PeriodoPdvExtensionsInclude.FullInclude(query);

            query = query.OrderBy(cat => cat.DescricaoPeriodo);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<T> SelectAsync(Guid idPeriodo, F filtro)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = PeriodoPdvExtensionsInclude.FullInclude(query);

            var result = await query.SingleOrDefaultAsync(p => p.Id == idPeriodo);

            return result ?? Activator.CreateInstance<T>();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<T> SelectAsync(string descricaoPerido, F filtro)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = PeriodoPdvExtensionsInclude.FullInclude(query);

            var result = await query.SingleOrDefaultAsync(p => p.DescricaoPeriodo.ToLower() == descricaoPerido.ToLower());

            return result ?? Activator.CreateInstance<T>();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<T> InsertAsync(T item, F filtro)
    {
        await _context.Set<T>().AddAsync(item);
        return item;
    }
    public T Update(T item, F filtro)
    {
        try
        {
            _context.Update(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
