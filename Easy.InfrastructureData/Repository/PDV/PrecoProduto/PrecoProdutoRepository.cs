﻿using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Easy.InfrastructureData.Tools.PrecoProduto;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.PrecoProduto;

public class PrecoProdutoRepository<T, F> : IPrecoProdutoRepository<T, F> where T : PrecoProdutoEntity where F : FiltroBase
{
    protected readonly MyContext _contexto;
    private DbSet<T> _dbSet;
    public PrecoProdutoRepository(MyContext contexto)
    {
        _contexto = contexto;
        _dbSet = contexto.Set<T>();
    }

    public async Task<T> InsertAsync(T item, F userFiltro)
    {
        try
        {
            await _dbSet.AddAsync(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<T>> SelectAsync(F userFiltro)
    {
        try
        {
            IQueryable<T> query = _dbSet.AsNoTracking().FiltroCliente(userFiltro);

            if (typeof(T) == typeof(PrecoProdutoEntity))
            {
                query = (IQueryable<T>)PrecoProdutoEntityExtensionsInclude.IncludePrecosProdutos((IQueryable<PrecoProdutoEntity>)query);
            }

            var result = await query.ToArrayAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T>? SelectAsync(Guid idProduto, Guid idCategoriaPreco, F userFiltro)
    {
        try
        {
            var result = await
                _dbSet.AsNoTracking()
                .FiltroCliente(userFiltro)
                .FirstOrDefaultAsync(cp => cp.ProdutoEntityId == idProduto && cp.CategoriaPrecoEntityId == idCategoriaPreco);

            if (result == null)
                return result;

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> UpdatePreco(T item, F userFiltro)
    {
        try
        {
            var existingItem = await SelectAsync(item.ProdutoEntityId, item.CategoriaPrecoEntityId, userFiltro);
            if (existingItem == null)
                throw new ArgumentException("Categoria de Preço não encontrada.");

            item.DataCriacao(existingItem.CreateAt);

            _contexto.Entry(existingItem).CurrentValues.SetValues(item);
            _contexto.Update(item);
            return existingItem;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
