using Api.Data.Context;
using Api.Data.Repository;
using Data.Query;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;
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

        public async Task<IEnumerable<CategoriaProdutoEntity>> GetAll(UserMasterUserDtoCreate user)
        {
            try
            {
                IQueryable<CategoriaProdutoEntity> query = _dataset.AsNoTracking();

                query = FiltroOrderBy(query);

                query = query.FiltroUserMasterCliente(user);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaProdutoEntity> GetByIdCategoria(Guid idCategoria, UserMasterUserDtoCreate user)
        {
            try
            {
                IQueryable<CategoriaProdutoEntity> query = _dataset.AsNoTracking();

                query = query.FiltroUserMasterCliente(user);

                query = query.Where(cat => cat.Id == idCategoria);

                var entities = await query.SingleOrDefaultAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IQueryable<CategoriaProdutoEntity> FiltroOrderBy(IQueryable<CategoriaProdutoEntity> query)
        {
            query = query.OrderBy(t => t.DescricaoCategoria);
            return query;
        }
    }
}
