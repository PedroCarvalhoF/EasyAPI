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
        }
        private IQueryable<CategoriaProdutoEntity> FiltroOrderBy(IQueryable<CategoriaProdutoEntity> query)
        {
            query = query.OrderBy(t => t.DescricaoCategoria);

            return query;
        }

        public async Task<IEnumerable<CategoriaProdutoEntity>> GetAll()
        {
            try
            {
                IQueryable<CategoriaProdutoEntity> query = _dataset.AsNoTracking();


                query = FiltroOrderBy(query);

                var entities = await query.ToListAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaProdutoEntity> GetIdCategoriaProduto(Guid id)
        {
            try
            {
                IQueryable<CategoriaProdutoEntity> query = _dataset.AsNoTracking();
                query = FiltroOrderBy(query);

                var entity = await query.SingleOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
