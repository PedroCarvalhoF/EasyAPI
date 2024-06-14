using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.ProdutoMedida;
using Data.Query;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Produto.ProdutoMedida
{
    public class ProdutoMedidaImplementacao : BaseRepository<ProdutoMedidaEntity>, IProdutoMedidaRepository
    {
        private readonly DbSet<ProdutoMedidaEntity> _dbSet;
        public ProdutoMedidaImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<ProdutoMedidaEntity>();
        }

        public async Task<IEnumerable<ProdutoMedidaEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                IQueryable<ProdutoMedidaEntity> query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);
                query = query.OrderBy(p => p.Descricao);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoMedidaEntity> GetByIdMididaProduto(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                IQueryable<ProdutoMedidaEntity> query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).Where(p => p.Id == id);

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