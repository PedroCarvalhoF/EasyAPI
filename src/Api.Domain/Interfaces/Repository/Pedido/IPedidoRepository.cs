using Api.Domain.Entities.Pedido;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository.Pedido
{
    public interface IPedidoRepository
    {
        Task<PedidoEntity> Get(Guid idPedido);
        Task<IEnumerable<PedidoEntity>> GetAll(Expression<Func<PedidoEntity, bool>> funcao, bool inlude = true);
        Task<IEnumerable<PedidoEntity>> GetAll(Guid idPdv);
        Task<IEnumerable<PedidoEntity>> GetAllBySituacao(Guid idPdv, Guid idSituacao);
        Task<IEnumerable<PedidoEntity>> GetAllByCategoriaPreco(Guid idPdv, Guid idCategoriaPreco);
        Task<IEnumerable<PedidoEntity>> GetAllByUser(Guid idPdv, Guid idUserCreatePedido);

    }
}
