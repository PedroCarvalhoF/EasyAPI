using Api.Data.Context;
using Api.Data.Repository;
using Data.Query;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.FormaPagamento
{
    public class FormaPagamentoImplementacao : BaseRepository<FormaPagamentoEntity>, IFormaPagamentoRepository
    {
        private readonly DbSet<FormaPagamentoEntity> _dbSet;
        public FormaPagamentoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<FormaPagamentoEntity>();
        }

        public async Task<bool> Exists(FormaPagamentoEntity entity, UserMasterUserDtoCreate user)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(user);

                var exists = await query.AnyAsync(f => f.DescricaoFormaPg == entity.DescricaoFormaPg);

                return exists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoEntity> GetById(Guid id, UserMasterUserDtoCreate user)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(user);

                query = query.Where(f => f.Id == id);

                return await query.SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<FormaPagamentoEntity>> GetAll(UserMasterUserDtoCreate user)
        {
            IQueryable<FormaPagamentoEntity> query = _dbSet.AsNoTracking();

            query = query.FiltroUserMasterCliente(user);

            query = query.OrderBy(f => f.DescricaoFormaPg);

            var entities = await query.ToArrayAsync();

            return entities;
        }
    }
}
