using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.CategoraPreco;

public class CategoriaPrecoRepository<T, F> : ICategoriaPrecoRepository<T, F> where T : CategoriaPrecoEntity where F : FiltroBase
{
    protected readonly MyContext _contexto;
    private readonly DbSet<CategoriaPrecoEntity> _dbSet;
    public CategoriaPrecoRepository(MyContext contexto)
    {
        _contexto = contexto;
        _dbSet = contexto.Set<CategoriaPrecoEntity>();
    }

    public async Task<bool> CodigoDescricaoExists(int codigo, string descricao, F filtro)
    {
        try
        {
            var result = await _dbSet
                                .AsNoTracking()
                                .FiltroCliente(filtro)
                                .AnyAsync(c => c.DescricaoCategoriaPreco.ToLower() == descricao.ToLower() || c.Codigo == codigo);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteAsync(Guid id, F userFiltro)
    {
        try
        {
            var categoria = await _dbSet
                            .AsNoTracking()
                            .FiltroCliente(userFiltro)
                            .SingleOrDefaultAsync(c => c.Id == id);

            var result = _contexto.CategoriasPrecos.Remove(categoria);

            if (result == null)
                return await Task.FromResult(false);

            return await Task.FromResult(true);

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<CategoriaPrecoEntity> InsertAsync(T item, F filtro)
    {
        try
        {
            var codigoDescricaoExists = await CodigoDescricaoExists(item.Codigo, item.DescricaoCategoriaPreco, filtro);
            if (codigoDescricaoExists)
                throw new ArgumentException("Código e descrição precisam ser unicos");

            await _contexto.AddAsync(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<CategoriaPrecoEntity> SelectAsync(Guid id, F filtro)
    {
        try
        {
            return await _dbSet
                //.AsNoTracking()
                .FiltroCliente(filtro)
                .SingleOrDefaultAsync(c => c.Id == id) ?? new CategoriaPrecoEntity();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaPrecoEntity>> SelectAsync(F filtro)
    {
        return await _dbSet
            .AsNoTracking()
            .FiltroCliente(filtro)
            .OrderBy(cat => cat.DescricaoCategoriaPreco)
            .ToArrayAsync();
    }

    public async Task<CategoriaPrecoEntity> UpdateAsync(T item, F filtro)
    {
        try
        {
            var result = await _dbSet.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            item.DataCriacao(result!.CreateAt);
            _contexto.Entry(result).CurrentValues.SetValues(item);
            _contexto.Update(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
