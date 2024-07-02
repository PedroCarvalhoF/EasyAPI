using Easy.Domain.Entities;
using Easy.Services.CQRS.PDV.Pedido.Commands;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Notifications;

public class ItemPedidoNotification : INotification
{
    public Guid IdPedido { get; }
    public FiltroBase Filtro { get; }
    public ItemPedidoNotification(Guid idPedido, FiltroBase filtro)
    {
        IdPedido = idPedido;
        Filtro = filtro;
    }

    public class ItemPedidoNotificationHandler(IMediator _mediator) : INotificationHandler<ItemPedidoNotification>
    {
        public async Task Handle(ItemPedidoNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                PedidoAtualizarCommand atualizarPedidoCommand = new PedidoAtualizarCommand();
                atualizarPedidoCommand.SetUsers(notification.Filtro);
                atualizarPedidoCommand.IdPedido = notification.IdPedido;
                await _mediator.Send(atualizarPedidoCommand);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
