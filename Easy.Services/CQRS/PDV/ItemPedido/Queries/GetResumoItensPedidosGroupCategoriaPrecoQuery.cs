using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Queries;

public class GetResumoItensPedidosGroupCategoriaPrecoQuery : BaseCommands<List<ItemPedidoDtoResumoGroupCategoriaPreco>>
{
    public required PedidoEntityFilter PedidoEntityFilter { get; set; }
    public class GetResumoItensPedidosGroupCategoriaPrecoQueryHandler(IUnitOfWork _repository)
        : IRequestHandler<GetResumoItensPedidosGroupCategoriaPrecoQuery, RequestResult<List<ItemPedidoDtoResumoGroupCategoriaPreco>>>
    {
        public async Task<RequestResult<List<ItemPedidoDtoResumoGroupCategoriaPreco>>> Handle(GetResumoItensPedidosGroupCategoriaPrecoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidos_validos = await _repository.PedidoRepository.SelectAsync(request.PedidoEntityFilter, filtro, true);

                if (pedidos_validos == null || pedidos_validos.Count() == 0)
                    return RequestResult<List<ItemPedidoDtoResumoGroupCategoriaPreco>>.BadRequest("Nenhum pedido encontrado para gerar resumo.");

                IEnumerable<ItemPedidoDtoResumoGroupCategoriaPreco> result =
                                         from pedido in pedidos_validos
                                         from item in pedido.ItensPedido!
                                         where !item.Cancelado
                                         group item by new
                                         {
                                             DescricaoCategoriaPreco = pedido.CategoriaPreco?.DescricaoCategoriaPreco,
                                             NomeProduto = item.Produto?.NomeProduto,
                                             Preco = item.Preco
                                         }
                                         into produtoGroup
                                         orderby produtoGroup.Key.NomeProduto
                                         select new ItemPedidoDtoResumoGroupCategoriaPreco(
                                             produtoGroup.Key.DescricaoCategoriaPreco ?? "N/A",  // Valor padrão caso seja nulo
                                             produtoGroup.Key.NomeProduto ?? "Produto desconhecido", // Valor padrão caso seja nulo
                                             produtoGroup.Key.Preco,
                                             produtoGroup.Sum(i => i.Quantidade),
                                             produtoGroup.Sum(i => i.TotalItem)
                                         );

                return RequestResult<List<ItemPedidoDtoResumoGroupCategoriaPreco>>.Ok(result.ToList());
            }
            catch (Exception ex)
            {

                return RequestResult<List<ItemPedidoDtoResumoGroupCategoriaPreco>>.BadRequest(ex.Message);
            }
        }
    }
}
