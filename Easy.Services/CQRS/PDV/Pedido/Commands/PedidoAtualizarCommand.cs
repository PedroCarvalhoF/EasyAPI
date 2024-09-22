using Easy.Domain.Entities.PDV.Pedido;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Service.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoAtualizarCommand : BaseCommands<PedidoDto>
{
    public Guid IdPedido { get; set; }

    public class PedidoAtualizarCommandHandler(IPedidoServices _pedidoServices) : IRequestHandler<PedidoAtualizarCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(PedidoAtualizarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var pedidoFiltro = new PedidoEntityFilter
                {
                    IdPedido = request.IdPedido,
                };

                var pedidoAtualizado = await _pedidoServices.AtualizarPedido(request.IdPedido, filtro);

                var pedidoDto = await _pedidoServices.GetPedidoById(request.IdPedido, filtro);

                return RequestResult<PedidoDto>.Ok(pedidoDto);
            }
            catch (Exception ex)
            {
                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}
