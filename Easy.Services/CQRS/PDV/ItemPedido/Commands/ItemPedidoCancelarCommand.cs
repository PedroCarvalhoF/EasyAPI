using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoCancelarCommand : BaseCommands
{
    public Guid IdItemPedido { get; set; }

    public class ItemPedidoCancelarCommandHandler(IUnitOfWork _repository) : IRequestHandler<ItemPedidoCancelarCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(ItemPedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var itemPedidoSelecionaodo = await _repository.ItemPedidoBaseRepository.SelectAsync(request.IdItemPedido, filtro);
                if (itemPedidoSelecionaodo == null)
                    throw new ArgumentException("Item não localizado");

                itemPedidoSelecionaodo.CancelarItem();

                await _repository.ItemPedidoBaseRepository.UpdateAsync(itemPedidoSelecionaodo, filtro);
                if (!await _repository.CommitAsync())
                    throw new ArgumentException("Não foi possível cancelar item.");

                return new RequestResult().Ok("Item do pedido cancelado.");

            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
