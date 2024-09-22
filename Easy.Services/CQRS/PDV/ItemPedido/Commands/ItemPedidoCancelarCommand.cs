using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Service.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoCancelarCommand : BaseCommands<PedidoDto>
{
    public Guid IdItemPedido { get; set; }

    public class ItemPedidoCancelarCommandHandler(IUnitOfWork _repository, IPedidoServices _pedidoServices) : IRequestHandler<ItemPedidoCancelarCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(ItemPedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var itemPedidoSelecionaodo = await _repository.ItemPedidoBaseRepository.SelectAsync(request.IdItemPedido, filtro);
                if (itemPedidoSelecionaodo.Id == Guid.Empty)
                    throw new ArgumentException("Item do pedido não localizado.");


                var verificar_pedido = (await _repository.PedidoRepository.SelectAsync(new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                {
                    IdPedido = itemPedidoSelecionaodo.PedidoId
                }, filtro)).SingleOrDefault() ?? new Domain.Entities.PDV.Pedido.PedidoEntity();

                if (verificar_pedido.Id == Guid.Empty)
                    throw new ArgumentException("Pedido não localizado");

                var pedido_manipulavel = verificar_pedido!.Manipular;

                itemPedidoSelecionaodo.CancelarItem();
                await _repository.ItemPedidoBaseRepository.Update(itemPedidoSelecionaodo);
                if (!await _repository.CommitAsync())
                    throw new ArgumentException("Não foi possível cancelar item.");

                if (!await _pedidoServices.AtualizarPedido(itemPedidoSelecionaodo.PedidoId, filtro))
                    throw new ArgumentException("Não foi possível atualizar pedido");

                var pedidoAtualizado = await _pedidoServices.GetPedidoById(itemPedidoSelecionaodo.PedidoId, filtro);

                return RequestResult<PedidoDto>.Ok(pedidoAtualizado);

            }
            catch (Exception ex)
            {

                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}
