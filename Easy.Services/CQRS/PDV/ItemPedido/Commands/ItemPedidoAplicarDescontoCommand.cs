using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands
{
    public class ItemPedidoAplicarDescontoCommand : BaseCommandsForUpdate
    {
        public Guid IdItemPedido { get; set; }
        public decimal? DescontoValorReal { get; set; }
        public decimal? DescontoPercentual { get; set; }

        public class ItemPedidoAplicarDescontoCommandHandler(IUnitOfWork _repository) : IRequestHandler<ItemPedidoAplicarDescontoCommand, RequestResultForUpdate>
        {
            public async Task<RequestResultForUpdate> Handle(ItemPedidoAplicarDescontoCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();
                    var itemPedidoSelecionado = await _repository.ItemPedidoBaseRepository.SelectAsync(request.IdItemPedido, filtro);
                    if (itemPedidoSelecionado == null)
                        throw new ArgumentException("Item do pedido não foi localizado.");

                    if (request.DescontoValorReal == null || request.DescontoValorReal > 0)
                    {
                        itemPedidoSelecionado.AplicarDescontoValorReal(request.DescontoValorReal ?? 0m);
                    }
                    else
                    {
                        itemPedidoSelecionado.AplicarDescontoPedidoPercentual(request.DescontoPercentual ?? 0m);
                    }

                    await _repository.ItemPedidoBaseRepository.UpdateAsync(itemPedidoSelecionado, filtro);
                    if (!await _repository.CommitAsync())
                        return new RequestResultForUpdate().BadRequest("Não foi possível aplicar desconto.");

                    return new RequestResultForUpdate().Ok("Desconto aplicado.");
                }
                catch (Exception ex)
                {

                    return new RequestResultForUpdate().BadRequest(ex.Message);
                }
            }
        }
    }
}
