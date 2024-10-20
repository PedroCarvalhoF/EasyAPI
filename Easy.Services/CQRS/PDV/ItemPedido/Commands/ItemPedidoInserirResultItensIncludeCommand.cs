using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Service.Pedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Commands;

public class ItemPedidoInserirResultItensIncludeCommand : BaseCommands<PedidoDtoIncludeItens>
{
    public required ItemPedidoDtoInserir ItemPedidoDtoInserir { get; set; }

    public class ItemPedidoInserirResultItensIncludeCommandHandler(IUnitOfWork _repository, IPedidoServices _pedidoServices) : IRequestHandler<ItemPedidoInserirResultItensIncludeCommand, RequestResult<PedidoDtoIncludeItens>>
    {
        public async Task<RequestResult<PedidoDtoIncludeItens>> Handle(ItemPedidoInserirResultItensIncludeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var itemPedidoEntity =
                    ItemPedidoEntity.InserirItem(request.ItemPedidoDtoInserir.Quantidade, request.ItemPedidoDtoInserir.Preco, request.ItemPedidoDtoInserir.ProdutoId, request.ItemPedidoDtoInserir.PedidoId, filtro);

                if (!itemPedidoEntity.Validada)
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest();

                //validações
                //pedido nao pode esta abertou/cancelado
                var pedido = await _repository.PedidoBaseRepository.SelectAsync(itemPedidoEntity.PedidoId, filtro, false);
                if (pedido.Id == Guid.Empty)
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest("Pedido não localizado");

                if (pedido.Cancelado)
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest("Não é possível inserir item em um pedido cancelado");

                if (pedido.Finalizado)
                {
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest("Não é possível inserir item em um pedido finalizado");
                }

                //inserindo item do pedido
                await _repository.ItemPedidoBaseRepository.InsertAsync(itemPedidoEntity);
                if (!await _repository.CommitAsync())
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest("Não foi possível inserir item do pedido.");

                // atualizar pedido
                var updatePedido = await _pedidoServices.AtualizarPedido(pedido.Id, filtro);
                if (!updatePedido)
                    return RequestResult<PedidoDtoIncludeItens>.BadRequest("Não foi possível atualizar pedido.");

                var pedidoAtualizado = await _pedidoServices.GetPedidoById(pedido.Id, filtro);

                var listaItensPedidoEntities = await _repository.ItemPedidoRepository.SelectAsync(new ItemPedidoEntityFilter
                {
                    PedidoId = pedidoAtualizado.Id
                }, filtro, true);

                var listaItensPedidoDtos = DtoMapper.ParceItemPedidoDto(listaItensPedidoEntities);

                var pedidoDtoInclude = new PedidoDtoIncludeItens(listaItensPedidoDtos.ToList(), pedidoAtualizado.Id, pedidoAtualizado.TipoPedido, pedidoAtualizado.NumeroPedido, pedidoAtualizado.Desconto, pedidoAtualizado.SubTotal, pedidoAtualizado.Total, pedidoAtualizado.Observacoes, pedidoAtualizado.Cancelado, pedidoAtualizado.PontoVendaEntityId, pedidoAtualizado.CategoriaPrecoId, pedidoAtualizado.CategoriaPreco, pedidoAtualizado.UserId, pedidoAtualizado.CreateAt, pedidoAtualizado.Finalizado);

                return RequestResult<PedidoDtoIncludeItens>.Ok(pedidoDtoInclude);
            }
            catch (Exception ex)
            {
                return RequestResult<PedidoDtoIncludeItens>.BadRequest(ex.Message);
            }
        }
    }
}
