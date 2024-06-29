using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces.Repository.PDV.Periodo;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
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


    public async Task<T> InsertAsync(T item, F filtro)
    {
        await _context.Set<T>().AddAsync(item);
        return item;
    }
    public async Task<IEnumerable<T>> SelectAsync(F filtro)
    {
        var result = await
            _dbSet.AsNoTracking()
            .FiltroCliente(filtro)
            .ToArrayAsync();

        return result;
    }
    public async Task<T>? SelectAsync(Guid idPeriodo, F filtro)
    {
        var result = await
            _dbSet.AsNoTracking()
            .FiltroCliente(filtro)
            .SingleOrDefaultAsync(per => per.Id == idPeriodo);

        return result;
    }
    public async Task<T>? SelectAsync(string descricaoPerido, F filtro)
    {
        var result = await
           _dbSet.AsNoTracking()
           .FiltroCliente(filtro)
           .SingleOrDefaultAsync(per => per.DescricaoPeriodo == descricaoPerido);

        return result;
    }
    public async Task<T> Update(T item, F filtro)
    {
        try
        {
            var result = await SelectAsync(item.Id, filtro);
            item.DataCriacao(result.CreateAt);
            _context.Set<T>().Entry(result).CurrentValues.SetValues(item);          
            _context.Update(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    //private bool _disposed = false;
    //public void Dispose()
    //{
    //    if (!_disposed)
    //        _context.Dispose();
    //    GC.SuppressFinalize(this);
    //}
    //~PeriodoPdvRepository() => Dispose();
}
