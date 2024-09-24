using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Service.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoCancelarArrayItensByIdCommand : BaseCommands<PedidoDto>
{
    public required ItemPedidoEntityFilter ItemPedidoEntityFilter { get; set; }

    public class ItemPedidoCancelarArrayItensByIdCommandHandler(IUnitOfWork _repository, IPedidoServices _pedidoService) : IRequestHandler<ItemPedidoCancelarArrayItensByIdCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(ItemPedidoCancelarArrayItensByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var itens_pedido = await _repository.ItemPedidoRepository.SelectAsync(request.ItemPedidoEntityFilter, filtro);

                foreach (var item_pedido_selecionado in itens_pedido)
                {
                    if (!item_pedido_selecionado.Cancelado)
                        item_pedido_selecionado.CancelarItem();
                }

                int cancelar_varios_itens_pedido = await _repository.ItemPedidoBaseRepository.UpdateRange(itens_pedido);

                var atualizarPedido = await _pedidoService.AtualizarPedido(itens_pedido.First().PedidoId, filtro);

                var pedidoAtualizadoDto = await _pedidoService.GetPedidoById(itens_pedido.First().PedidoId, filtro);

                return RequestResult<PedidoDto>.Ok(pedidoAtualizadoDto);
            }
            catch (Exception ex)
            {

                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}
