using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.DTOs.PagamentoPedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Queries;

public class GetItensPedidoResumoByPdvQuery : BaseCommands<List<ItemPedidoDtoResumoSimples>>
{
    public required ItemPedidoEntityFilter ItemPedidoEntityFilter { get; set; }

    public class GetItensPedidoResumoByPdvQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetItensPedidoResumoByPdvQuery, RequestResult<List<ItemPedidoDtoResumoSimples>>>
    {
        public async Task<RequestResult<List<ItemPedidoDtoResumoSimples>>> Handle(GetItensPedidoResumoByPdvQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var itensPedido = await _repository.ItemPedidoRepository.SelectAsync(request.ItemPedidoEntityFilter, request.GetFiltro(), true);

                var agrupadosPorProduto = itensPedido
                    .GroupBy(item => item.ProdutoId)
                    .Select(grupo => new ItemPedidoDtoResumoSimples
                    {
                        ProdutoId = grupo.Key,
                        NomeProduto = grupo.First().Produto.NomeProduto, // Pegando o nome do produto
                        QuantidadeTotal = grupo.Sum(item => item.Quantidade),
                    })
                    .ToList();

                return RequestResult<List<ItemPedidoDtoResumoSimples>>.Ok(agrupadosPorProduto);
            }
            catch (Exception ex)
            {

                return RequestResult<List<ItemPedidoDtoResumoSimples>>.BadRequest(ex.Message);
            }
        }
    }
}
