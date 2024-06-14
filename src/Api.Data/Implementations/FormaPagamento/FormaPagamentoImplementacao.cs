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
        private readonly DbSet<FormaPagamentoEntity> _dataset;
        public FormaPagamentoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<FormaPagamentoEntity>();
            _dataset.AsNoTracking();
        }

        public async Task<IEnumerable<FormaPagamentoEntity>> GetAll(UserMasterUserDtoCreate user)
        {
            IQueryable<FormaPagamentoEntity> query = _dataset.AsNoTracking();

            query = query.FiltroUserMasterCliente(user);

            query = query.OrderBy(f => f.DescricaoFormaPg);

            var entities = await query.ToArrayAsync();

            return entities;
        }
    }
}
