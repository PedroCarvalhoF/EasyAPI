using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Easy.InfrastructureData.Tools.CategoriaPreco;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.CategoraPreco;

public class CategoriaPrecoRepository : ICategoriaPrecoRepository<CategoriaPrecoEntity, FiltroBase>
{
    protected readonly MyContext _context;
    private readonly DbSet<CategoriaPrecoEntity> _dbSet;
    public CategoriaPrecoRepository(MyContext contexto)
    {
        _context = contexto;
        _dbSet = contexto.Set<CategoriaPrecoEntity>();
    }

    public async Task<IEnumerable<CategoriaPrecoEntity>> GetAllAsync(FiltroBase filtro)
    {
        try
        {
            IQueryable<CategoriaPrecoEntity> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = CategoriaPrecoExtensionsInclude.FullInclude(query);

            query = query.OrderBy(cat => cat.DescricaoCategoriaPreco);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<CategoriaPrecoEntity> GetByIdAsync(Guid id, FiltroBase filtro)
    {
        try
        {
            IQueryable<CategoriaPrecoEntity> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = CategoriaPrecoExtensionsInclude.FullInclude(query);

            var result = await query.SingleAsync(cat => cat.Id == id) ?? new CategoriaPrecoEntity();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<CategoriaPrecoEntity> GetByCodigoAsync(int codigo, FiltroBase filtro)
    {
        try
        {
            IQueryable<CategoriaPrecoEntity> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = CategoriaPrecoExtensionsInclude.FullInclude(query);

            var result = await query.SingleOrDefaultAsync(cat => cat.Codigo == codigo) ?? new CategoriaPrecoEntity();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<CategoriaPrecoEntity> GetByDescricaoCategoriaAsync(string descricao, FiltroBase filtro)
    {
        try
        {
            IQueryable<CategoriaPrecoEntity> query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            query = CategoriaPrecoExtensionsInclude.FullInclude(query);

            var result = await query.SingleOrDefaultAsync(cat => cat.DescricaoCategoriaPreco == descricao) ?? new CategoriaPrecoEntity();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<CategoriaPrecoEntity> InsertAsync(CategoriaPrecoEntity item, FiltroBase filtro)
    {
        try
        {
            await _context.AddAsync(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public CategoriaPrecoEntity UpdateAsync(CategoriaPrecoEntity item, FiltroBase filtro)
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
