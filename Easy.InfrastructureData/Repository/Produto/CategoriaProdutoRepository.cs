using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.Produto;

public class CategoriaProdutoRepository<T, U> : ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>
{
    private readonly MyContext _context;

    public CategoriaProdutoRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<CategoriaProdutoEntity> AddCategoriaAsync(CategoriaProdutoEntity categoria, FiltroBase filtro)
    {
        try
        {
            var descricaoCategoriaEmUso = await _context.CategoriasProdutos.AplicarFiltroCliente(filtro).Where(c => c.DescricaoCategoria == categoria.DescricaoCategoria).SingleOrDefaultAsync();

            if (descricaoCategoriaEmUso != null)
                throw new Exception("Categoría ja está em uso");

            var categoriaResult = await _context.AddAsync(categoria);
            return categoria;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<CategoriaProdutoEntity> DeleteCategoria(Guid categoriaId, FiltroBase filtro)
    {
        try
        {
            var categoria = await GetCategoriaByIdAsync(categoriaId, filtro);

            if (categoria is null)
                throw new InvalidOperationException("Categoria não encontrada.");

            _context.CategoriasProdutos.Remove(categoria);
            return categoria;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasAsync(FiltroBase filtro)
    {
        try
        {
            var categorias = await _context.CategoriasProdutos.AplicarFiltroCliente(filtro).ToArrayAsync();
            return categorias;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public Task<CategoriaProdutoEntity> GetCategoriaByIdAsync(Guid idCategoria, FiltroBase filtro)
    {
        try
        {
            return _context.CategoriasProdutos.AplicarFiltroCliente(filtro).SingleOrDefaultAsync(c => c.Id == idCategoria);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async void UpdateCategoria(CategoriaProdutoEntity categoria, FiltroBase filtro)
    {
        try
        {
            if (categoria is null)
                throw new ArgumentNullException(nameof(categoria));

            var categoriaExists = await GetCategoriaByIdAsync(categoria.Id, filtro);
            if (categoria is null)
                throw new InvalidOperationException("Categoria não encontrada.");

            _context.CategoriasProdutos.Update(categoria);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
