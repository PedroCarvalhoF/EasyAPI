using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.FormaPagamento;

namespace Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;

public interface IFormaPagamentoRepository<T, F> where T : FormaPagamentoEntity where F : FiltroBase
{
    Task<FormaPagamentoEntity> InsertAsync(T item, F userFiltro);
    Task<FormaPagamentoEntity> UpdateAsync(T item, F userFiltro);
    Task<bool> DeleteAsync(Guid id, F userFiltro);
    Task<FormaPagamentoEntity> SelectAsync(Guid id, F userFiltro);
    Task<IEnumerable<FormaPagamentoEntity>> SelectAsync(F userFiltro);
    Task<bool> CodigoFormaPagamentoExists(int codigo, string formaPagamento, F userFiltro);
}
