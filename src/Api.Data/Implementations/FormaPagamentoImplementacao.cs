using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.FormaPagamento;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<FormaPagamentoEntity>> SelectAsync(Expression<Func<FormaPagamentoEntity, bool>> funcao, bool fullConsulta = true)
        {
            try
            {
                IQueryable<FormaPagamentoEntity>? query = _context?.FormasPagamentos?.AsNoTracking();
                if (fullConsulta)
                {

                }

                query = query.Where(funcao);

                FormaPagamentoEntity[] entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
