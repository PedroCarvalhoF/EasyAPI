using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PagamentoPedido;

namespace Easy.Domain.Intefaces.Repository.PDV.PagamentoPedido;

public interface IPagamentoPedidoRepository<T, F> where T : PagamentoPedidoEntity where F : FiltroBase
{
    Task<T> GetPagamentoPedidoById(Guid id, F filtro);
    Task<IEnumerable<T>> GetPagamentosByIdPedido(Guid idPedido, F filtro);
}
