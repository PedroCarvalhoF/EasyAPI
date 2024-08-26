using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Queries;

public class GetPedidosFilterPedidosQueries : BaseCommands<IEnumerable<PedidoDto>>
{
    public required PedidoEntityFilter FiltroPedido { get; set; }
    public class GetPedidosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetPedidosFilterPedidosQueries, RequestResult<IEnumerable<PedidoDto>>>
    {
        public async Task<RequestResult<IEnumerable<PedidoDto>>> Handle(GetPedidosFilterPedidosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.PedidoRepository.SelectAsync(request.FiltroPedido, request.GetFiltro());

                var dtos = DtoMapper.ParcePedidoDto(entities);
                return RequestResult<IEnumerable<PedidoDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {

                return RequestResult<IEnumerable<PedidoDto>>.BadRequest(ex.Message);
            }
        }
    }
}
