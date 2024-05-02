using Domain.Entities.FormaPagamento;

namespace Domain.Interfaces.Repository.PedidoFormaPagamento
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<FormaPagamentoEntity>> GetByDescricao(string descricao);
    }
}
