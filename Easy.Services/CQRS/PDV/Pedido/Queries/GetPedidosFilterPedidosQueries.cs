using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Queries;

public class GetPedidosFilterPedidosQueries : BaseCommandsForUpdate
{
    public PedidoEntityFilter FiltroPedido { get; set; }
    public class GetPedidosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetPedidosFilterPedidosQueries, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPedidosFilterPedidosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.PedidoRepository.SelectAsync(request.FiltroPedido, request.GetFiltro());

                var pedido = entities.FirstOrDefault();

                pedido.CalcularTotalPedido();


                return new RequestResultForUpdate().Ok(entities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}
