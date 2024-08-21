using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoCancelarCommand : BaseCommandsForUpdate
{
    public Guid IdItemPedido { get; set; }

    public class ItemPedidoCancelarCommandHandler(IUnitOfWork _repository) : IRequestHandler<ItemPedidoCancelarCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(ItemPedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var itemPedidoSelecionaodo = await _repository.ItemPedidoBaseRepository.SelectAsync(request.IdItemPedido, filtro);
                if (itemPedidoSelecionaodo == null)
                    throw new ArgumentException("Item não localizado");

                itemPedidoSelecionaodo.CancelarItem();

                 _repository.ItemPedidoBaseRepository.Update(itemPedidoSelecionaodo);
                if (!await _repository.CommitAsync())
                    throw new ArgumentException("Não foi possível cancelar item.");

                return new RequestResultForUpdate().Ok("Item do pedido cancelado.");

            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}
