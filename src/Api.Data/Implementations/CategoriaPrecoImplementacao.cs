using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CategoriaPreco;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CategoriaPrecoImplementacao : BaseRepository<CategoriaPrecoEntity>, ICategoriaPrecoRepository
    {
        private readonly DbSet<CategoriaPrecoEntity> _dataset;
        public CategoriaPrecoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<CategoriaPrecoEntity>();
        }

        public async Task<IEnumerable<CategoriaPrecoEntity>> ConsultarTodasCategoriasPrecosIncludeProdutos()
        {
            try
            {
                IQueryable<CategoriaPrecoEntity> query = _dataset.AsNoTracking();

                query = query?.Include(produto => produto.PrecoProdutoEntities);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
