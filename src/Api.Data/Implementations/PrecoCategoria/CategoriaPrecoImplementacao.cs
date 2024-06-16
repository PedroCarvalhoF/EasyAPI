using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CategoriaPreco;
using Data.Query;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PrecoCategoria
{
    public class CategoriaPrecoImplementacao : BaseRepository<CategoriaPrecoEntity>, ICategoriaPrecoRepository
    {
        private readonly DbSet<CategoriaPrecoEntity> _dbSet;
        public CategoriaPrecoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<CategoriaPrecoEntity>();
        }

        public async Task<bool> Exists(CategoriaPrecoEntity entity, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);
                return await query.AnyAsync(p => p.DescricaoCategoria.ToLower() == entity.DescricaoCategoria.ToLower());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CategoriaPrecoEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).OrderBy(cat => cat.DescricaoCategoria);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaPrecoEntity> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

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
