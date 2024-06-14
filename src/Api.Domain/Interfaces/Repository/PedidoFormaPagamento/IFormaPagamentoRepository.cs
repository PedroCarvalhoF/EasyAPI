using Domain.Entities.FormaPagamento;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.PedidoFormaPagamento
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<FormaPagamentoEntity>> GetAll(UserMasterUserDtoCreate user);    
    }
}
