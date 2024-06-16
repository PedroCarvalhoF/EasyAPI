using Api.Data.Context;
using Api.Data.Repository;
using Data.Query;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.Identity.UserIdentity;
using Domain.Interfaces.Repository.Produto;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Produto.ProdutoTipo
{
    public class ProdutoTipoImplementacao : BaseRepository<ProdutoEntity>, IProdutoTipoRepository
    {
        private readonly DbSet<ProdutoTipoEntity> _dbSet;
        public ProdutoTipoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<ProdutoTipoEntity>();
        }

        public async Task<bool> Exists(ProdutoTipoEntity entity, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                var exits = await query.AnyAsync(pt => pt.DescricaoTipoProduto.ToLower() == entity.DescricaoTipoProduto.ToLower());

                return exits;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoTipoEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoTipoEntity> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

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
