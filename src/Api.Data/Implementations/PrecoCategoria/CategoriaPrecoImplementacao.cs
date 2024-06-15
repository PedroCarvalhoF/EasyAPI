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
        private readonly DbSet<CategoriaPrecoEntity> _dataset;
        public CategoriaPrecoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<CategoriaPrecoEntity>();
        }

        public async Task<IEnumerable<CategoriaPrecoEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dataset.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).OrderBy(cat => cat.DescricaoCategoria);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaPrecoEntity> GetIdCategoriaPreco(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dataset.AsNoTracking();

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
