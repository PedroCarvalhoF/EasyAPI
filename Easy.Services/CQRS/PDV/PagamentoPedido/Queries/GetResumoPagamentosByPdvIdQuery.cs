using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PagamentoPedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Queries
{
    public class GetResumoPagamentosByPdvIdQuery : BaseCommands<List<PagamentoPedidoDtoResumoPdv>>
    {
        public Guid PdvId { get; set; }
        public class GetResumoPagamentosByPdvIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetResumoPagamentosByPdvIdQuery, RequestResult<List<PagamentoPedidoDtoResumoPdv>>>
        {
            public async Task<RequestResult<List<PagamentoPedidoDtoResumoPdv>>> Handle(GetResumoPagamentosByPdvIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();

                    var pedidosFiltrados = await _repository.PedidoRepository.SelectAsync(new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                    {
                        PontoVendaEntityId = request.PdvId,
                        Finalizado = true,
                        Cancelado = false
                    }, filtro, true);

                    var pagamentos = DtoMapper.ParcePagamentoPedidoDto(pedidosFiltrados);

                    // Agrupar por FormaPagamento e calcular qtd, soma e média
                    var resultado = pagamentos
                      .GroupBy(p => p.FormaPagamento)
                      .Select(g => new PagamentoPedidoDtoResumoPdv(
                          pdvId: request.PdvId,              // Substitua pelo ID correto, se necessário
                          formaPagamento: g.Key,
                          quantidade: g.Count(),              // Quantidade de pagamentos
                          soma: g.Sum(p => p.ValorPago),      // Soma dos valores pagos
                          media: g.Average(p => p.ValorPago)  // Média dos valores pagos
                      )).OrderBy(g => g.FormaPagamento)
                      .ToList();


                    return RequestResult<List<PagamentoPedidoDtoResumoPdv>>.Ok(resultado);
                }
                catch (Exception ex)
                {

                    return RequestResult<List<PagamentoPedidoDtoResumoPdv>>.BadRequest(ex.Message);
                }
            }
        }
    }
}
