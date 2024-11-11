using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.FormaPagamento;

namespace Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;

public interface IFormaPagamentoRepository<T, F> where T : FormaPagamentoEntity where F : FiltroBase
{
    Task<IEnumerable<T>> SelectAsync(FormaPagamentoEntityFilter filter, F filtro, bool includeAll = true);
}
