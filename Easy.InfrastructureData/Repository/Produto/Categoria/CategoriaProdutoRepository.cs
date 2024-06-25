using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.Produto.Categoria;

public class CategoriaProdutoRepository<T, F> : ICategoriaProdutoRepository<T, F> where T : CategoriaProdutoEntity where F : FiltroBase
{
    private readonly MyContext _context;

    public CategoriaProdutoRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<CategoriaProdutoEntity> Create(T create)
    {
        try
        {
            FiltroBase filtro = new FiltroBase(create.UserMasterClienteIdentityId, create.UserId);

            var categoriaEmUso = await _context.CategoriasProdutos.AsNoTracking()
                .Where(c => c.DescricaoCategoria.ToLower() == create.DescricaoCategoria.ToLower()).FiltroCliente(filtro)
                .FirstOrDefaultAsync();

            if (categoriaEmUso != null)
            {
                throw new ArgumentException("Categoria já existe.");
            }

            await _context.AddAsync(create);
            return create;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public async Task<bool> Delete(Guid id, F users)
    {
        var categoria = await GetById(id, users);
        _context.Remove(categoria);
        return false;
    }

    public async Task<CategoriaProdutoEntity> GetById(Guid categoriaId, F users)
    {
        var categoria = await _context.CategoriasProdutos.AsNoTracking()
                              .FiltroCliente(users).Where(c => c.Id == categoriaId).SingleOrDefaultAsync();
        return categoria;
    }

    public async Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasProdutoAsync(F users)
    {
        try
        {
            var categorias = await _context.CategoriasProdutos.AsNoTracking()
                                  .FiltroCliente(users).ToArrayAsync();
            return categorias;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public CategoriaProdutoEntity Update(T create)
    {
        _context.Update(create);
        return create;
    }
}