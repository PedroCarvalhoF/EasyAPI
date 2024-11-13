using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Easy.InfrastructureData.Repository.PDV.FormaPagamento
{
    public class FormaPagamentoRepository : BaseRepository<FormaPagamentoEntity, FiltroBase>, IFormaPagamentoRepository<FormaPagamentoEntity, FiltroBase>
    {
        private DbSet<FormaPagamentoEntity> _dbSet;
        public FormaPagamentoRepository(MyContext context) : base(context)
        {

            _dbSet = context.Set<FormaPagamentoEntity>();
        }

        public async Task<IEnumerable<FormaPagamentoEntity>> SelectAsync(FormaPagamentoEntityFilter filter, FiltroBase filtro, bool includeAll = true)
        {
            try
            {
                IQueryable<FormaPagamentoEntity> query = _dbSet.AsNoTracking();

                query = FormaPagamentoEntityFilter.QueryableEntity(query, filter);

                query = query.FiltroCliente(filtro);

                if (includeAll)
                {

                }

                query = query.OrderBy(pgt => pgt.DescricaFormaPagamento);

                var result = await query.ToArrayAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
