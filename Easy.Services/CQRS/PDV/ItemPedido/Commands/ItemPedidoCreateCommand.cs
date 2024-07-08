using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.PDV.ItemPedido.Notifications;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoCreateCommand : BaseCommandsForUpdate
{
    public decimal Quantidade { get; set; }
    public decimal Preco { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid PedidoId { get; set; }

    public class ItemPedidoCreateCommandHandler(IUnitOfWork _repository, IMediator _mediator) : IRequestHandler<ItemPedidoCreateCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(ItemPedidoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var itemPedidoEntity = ItemPedidoEntity.InserirItem(request.Quantidade, request.Preco, request.ProdutoId, request.PedidoId, filtro);
                if (!itemPedidoEntity.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                await _repository.ItemPedidoBaseRepository.InsertAsync(itemPedidoEntity);
                if (!await _repository.CommitAsync())
                    return new RequestResultForUpdate().BadRequest("Não foi possível inserir item.");


                //atualizar pedido
                await _mediator.Publish(new ItemPedidoNotification(itemPedidoEntity.PedidoId, filtro));

                return new RequestResultForUpdate().Ok("Item inserido com sucesso.");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}
