using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos;
using Domain.Dtos.Pedidos;
using System.Linq.Expressions;

namespace Api.Domain.Interfaces.Services.Pedido
{
    public interface IPedidoService
    {
        Task<ResponseDto<List<PedidoDto>>> GetAll();
        Task<ResponseDto<List<PedidoDto>>> Get(Guid idPedido);
        Task<ResponseDto<List<PedidoDto>>> GetAll(Expression<Func<PedidoDto, bool>> funcao, bool inlude = true);
        Task<ResponseDto<List<PedidoDto>>> GetAll(Guid idPdv);
        Task<ResponseDto<List<PedidoDto>>> GetAllBySituacao(Guid idPdv, Guid idSituacao);
        Task<ResponseDto<List<PedidoDto>>> GetAllByCategoriaPreco(Guid idPdv, Guid idSituacao);
        Task<ResponseDto<List<PedidoDto>>> GetAllByUser(Guid idPdv, Guid idUserCreatePedido);
        Task<ResponseDto<List<PedidoDto>>> GerarPedido(PedidoDtoCreate pedidoDtoCreate);
        Task<ResponseDto<List<PedidoDto>>> AtualizarValorPedido(Guid idPedido);
        Task<ResponseDto<List<PedidoDto>>> EncerrarPedido(Guid idPedido);
        Task<ResponseDto<List<PedidoDto>>> CancelarPedido(PedidoDtoCancelar cancelamentoPedido);
        
    }
}
