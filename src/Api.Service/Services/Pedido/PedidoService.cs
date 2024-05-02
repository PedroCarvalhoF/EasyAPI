using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using Domain.Dtos.PedidoDtos;
using Domain.Enuns;

namespace Api.Service.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        public PedidoService()
        {

        }

        public Task<PedidoDto> AtualizarValorPedido(Guid pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> CancelarPedido(PedidoDtoCancelamento dtoCancelamento)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> CancelarTodosItensPedidoReturnPedido(Guid idPedido)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> EncerrarPedido(Guid pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoDto>> Get(SituacaoPedidoEnum situacaoPedido)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoDto>> Get(Guid idPdv)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoDto>> GetByIdPedido(Guid idPedido, bool fullConsulta)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> RemoverAllItensPedido(Guid idPedido)
        {
            throw new NotImplementedException();
        }
    }
}