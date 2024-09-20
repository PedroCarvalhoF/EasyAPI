using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.PDV.ItemPedido.Notifications;
using Easy.Services.CQRS.PDV.Pedido.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.DTOs.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoInserirCommand : BaseCommands<PedidoDto>
{
    public required ItemPedidoDtoInserir ItemPedidoDto { get; set; }
    public class ItemPedidoCreateCommandHandler(IUnitOfWork _repository, IMediator _mediator) : IRequestHandler<ItemPedidoInserirCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(ItemPedidoInserirCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var itemPedidoEntity =
                    ItemPedidoEntity.InserirItem(request.ItemPedidoDto.Quantidade, request.ItemPedidoDto.Preco, request.ItemPedidoDto.ProdutoId, request.ItemPedidoDto.PedidoId, filtro);

                if (!itemPedidoEntity.Validada)
                    return RequestResult<PedidoDto>.BadRequest();

                //validações
                //pedido nao pode esta abertou/cancelado
                var pedido = await _repository.PedidoBaseRepository.SelectAsync(itemPedidoEntity.PedidoId, filtro, false);
                if (pedido.Id == Guid.Empty)
                    return RequestResult<PedidoDto>.BadRequest("Pedido não localizado");

                if (pedido.Cancelado)
                    return RequestResult<PedidoDto>.BadRequest("Não é possível inserir item em um pedido cancelado");

                if (pedido.Finalizado)
                {
                    return RequestResult<PedidoDto>.BadRequest("Não é possível inserir item em um pedido finalizado");
                }

                //inserindo item do pedido
                await _repository.ItemPedidoBaseRepository.InsertAsync(itemPedidoEntity);
                if (!await _repository.CommitAsync())
                    return RequestResult<PedidoDto>.BadRequest("Não foi possível inserir item do pedido.");

                // atualizar pedido
                await _mediator.Publish(new ItemPedidoNotification(itemPedidoEntity.PedidoId, filtro));


                GetPedidosFilterPedidosQueries commandQueryGetPedidoSelecionado = new GetPedidosFilterPedidosQueries
                {
                    FiltroPedido = new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                    {
                        IdPedido = pedido.Id
                    }
                };

                commandQueryGetPedidoSelecionado.SetUsers(filtro);
                var pedidoAtualizadoFilter = await _mediator.Send(commandQueryGetPedidoSelecionado);

                PedidoDto pedidoAtualizado = pedidoAtualizadoFilter.Data.SingleOrDefault();

                return RequestResult<PedidoDto>.Ok(pedidoAtualizado);
            }
            catch (Exception ex)
            {
                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}
