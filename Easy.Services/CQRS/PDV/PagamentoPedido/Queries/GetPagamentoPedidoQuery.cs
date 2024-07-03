using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Queries;

public class GetPagamentoPedidoQuery : BaseCommands
{
    public class GetPagamentoPedidoQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPagamentoPedidoQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetPagamentoPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pagamentoEntities = await _repository.PagamentoPedidoBaseRepository.SelectAsync(request.GetFiltro());
                return new RequestResult().Ok(pagamentoEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
