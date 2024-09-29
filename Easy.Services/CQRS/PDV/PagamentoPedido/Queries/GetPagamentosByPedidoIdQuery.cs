using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PagamentoPedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Queries;

public class GetPagamentosByPedidoIdQuery : BaseCommands<PagamentoPedidoDtoInserirResult>
{
    public required Guid PedidoId { get; set; }

    public class GetPagamentosByPedidoIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPagamentosByPedidoIdQuery, RequestResult<PagamentoPedidoDtoInserirResult>>
{
        public async Task<RequestResult<PagamentoPedidoDtoInserirResult>> Handle(GetPagamentosByPedidoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoid = request.PedidoId;
                var pagamentos = await _repository.PagamentoPedidoRespoitory.GetPagamentosByIdPedido(pedidoid, filtro);
                var dtos = DtoMapper.ParcePagamentoPedidoDto(pagamentos);

                var pedidoEntity = await _repository.PedidoRepository.SelectAsync(new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                {
                    IdPedido = pedidoid
                }, filtro, true);

                var total_pago = pedidoEntity.Single().ValorPedidoPago;

                decimal diferenca = pedidoEntity.Single().Total - total_pago;

                var result = new PagamentoPedidoDtoInserirResult(pedidoid, pedidoEntity.Single().Finalizado, dtos.ToList(), diferenca < 0 ? diferenca * -1 : 0, pedidoEntity.Single().Total);

                return RequestResult<PagamentoPedidoDtoInserirResult>.Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
