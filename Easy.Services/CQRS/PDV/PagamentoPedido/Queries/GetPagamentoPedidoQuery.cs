using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Queries;

public class GetPagamentoPedidoQuery : BaseCommandsForUpdate
{
    public class GetPagamentoPedidoQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPagamentoPedidoQuery, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPagamentoPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pagamentoEntities = await _repository.PagamentoPedidoBaseRepository.SelectAsync(request.GetFiltro());
                return new RequestResultForUpdate().Ok(pagamentoEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}
