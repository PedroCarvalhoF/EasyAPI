using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CategoriaProdutoImplementacao : BaseRepository<CategoriaProdutoEntity>, ICategoriaProdutoRepository
    {
        private readonly DbSet<CategoriaProdutoEntity> _dataset;

        public CategoriaProdutoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<CategoriaProdutoEntity>();
            _dataset.AsNoTracking();
        }

        public async Task<IEnumerable<CategoriaProdutoEntity>> Get(string categoria)
        {
            try
            {
                categoria = categoria.ToLower();

                IQueryable<CategoriaProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(cat => cat.DescricaoCategoria!.ToLower().Contains(categoria));

                var entities = await query.ToArrayAsync();

                return entities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
