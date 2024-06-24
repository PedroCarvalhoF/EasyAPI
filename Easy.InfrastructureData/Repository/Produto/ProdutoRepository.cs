using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.Produto;

public class ProdutoRepository<T, F> : IProdutoRepository<T, F> where T : ProdutoEntity where F : FiltroBase
{
    private readonly DbSet<ProdutoEntity> _dbSet;
    private readonly MyContext _contexto;

    public ProdutoRepository(MyContext contexto)
    {
        _dbSet = contexto.Set<ProdutoEntity>();
        _contexto = contexto;
    }

    public async Task<bool> CodigoNomeExists(string codigo, string nome, F userFiltro)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            query = query.FiltroUserMasterCliente(userFiltro).Where(p => p.NomeProduto.ToLower() == nome || p.Codigo == codigo);

            var produto = await query.SingleOrDefaultAsync();
            if (produto != null)
                return true;

            return false;
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
            var query = _dbSet.AsNoTracking();
            query = query.FiltroUserMasterCliente(userFiltro);

            query = query.Where(p => p.Id == id);

            var produto = await query.SingleOrDefaultAsync();
            if (produto != null)
            {
                _contexto.Remove(produto);
                return true;
            }


            return false;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<ProdutoEntity> InsertAsync(T item, F userFiltro)
    {
        try
        {
            var codigoNomeExists = await CodigoNomeExists(item.Codigo, item.NomeProduto, userFiltro);
            if (codigoNomeExists)
                throw new ArgumentException("Nome e código devem ser exclusívos.");

            _contexto.Add(item);
            return item;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<ProdutoEntity> SelectAsync(Guid id, F userFiltro)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            query = query.FiltroUserMasterCliente(userFiltro).Where(p => p.Id == id);

            var produto = await query.SingleOrDefaultAsync();
            if (produto == null)
                return new ProdutoEntity();

            return produto;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<ProdutoEntity>> SelectAsync(F userFiltro)
    {
        try
        {
            var query = _dbSet.AsNoTracking();

            query = query.FiltroUserMasterCliente(userFiltro);

            var produtos = await query.ToArrayAsync();

            return produtos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProdutoEntity> UpdateAsync(T item, F userFiltro)
    {
        try
        {
            var result = await _contexto.Produtos.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            _contexto.Produtos.Entry(result).CurrentValues.SetValues(item);
            _contexto.Update(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
