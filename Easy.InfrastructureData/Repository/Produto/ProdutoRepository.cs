using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Easy.InfrastructureData.Tools.Produto;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.Produto;

public class ProdutoRepository<T, F> : IProdutoRepository<T, F> where T : ProdutoEntity where F : FiltroBase
{
    private readonly MyContext _contexto;
    private DbSet<ProdutoEntity> _dbSet;

    public ProdutoRepository(MyContext contexto)
    {
        _dbSet = contexto.Set<ProdutoEntity>();
        _contexto = contexto;
    }

    public async Task<ProdutoEntity> NomeProdutoExists(string nome, F userFiltro)
    {
        try
        {
            return await

                    _dbSet.AsNoTracking()
                          .IncludeProdutos()
                          .FiltroCliente(userFiltro)
                          .SingleOrDefaultAsync(p => p.NomeProduto.ToLower() == nome.ToLower()) ?? new ProdutoEntity();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProdutoEntity> CodigoProdutoExists(string codigo, F filtro)
    {
        try
        {
            return await
                     _dbSet.AsNoTracking()
                           .IncludeProdutos()
                           .FiltroCliente(filtro)                          
                           .SingleOrDefaultAsync(p => p.Codigo == codigo) ?? new ProdutoEntity();
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
            var produto = await

                _dbSet.AsNoTracking()
                      .FiltroCliente(userFiltro)
                      .SingleOrDefaultAsync(p => p.Id == id);

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
            var produto = await

                    _dbSet.AsNoTracking()
                          .FiltroCliente(userFiltro)
                          .IncludeProdutos()
                          .SingleOrDefaultAsync(p => p.Id == id);

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
            var produtos = await

                    _dbSet.AsNoTracking()
                          .FiltroCliente(userFiltro)
                          .IncludeProdutos()
                          .ToArrayAsync();

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
            var result = await _dbSet.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            _contexto.Produtos.Entry(result).CurrentValues.SetValues(item);
            item.DataCriacao(result.CreateAt);
            _contexto.Update(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }


}
