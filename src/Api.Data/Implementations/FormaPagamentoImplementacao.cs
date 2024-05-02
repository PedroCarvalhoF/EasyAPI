using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class FormaPagamentoImplementacao : BaseRepository<FormaPagamentoEntity>, IFormaPagamentoRepository
    {
        private readonly DbSet<FormaPagamentoEntity> _dataset;
        public FormaPagamentoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<FormaPagamentoEntity>();
            _dataset.AsNoTracking();
        }

        public async Task<IEnumerable<FormaPagamentoEntity>> GetByDescricao(string descricao)
        {
            IQueryable<FormaPagamentoEntity> query = _dataset;

            query = query.Where(forma => forma.DescricaoFormaPg.ToLower().Contains(descricao));

            FormaPagamentoEntity[] result = await query.ToArrayAsync();
            return result;
        }
    }
}
