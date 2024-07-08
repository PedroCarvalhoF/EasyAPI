using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Queries
{
    public class GetFormaPagamentosQueries : IRequest<RequestResultForUpdate>
    {
        private FiltroBase FiltroBase { get; set; }
        public void SetUsers(FiltroBase user)
            => FiltroBase = user;
        public FiltroBase GetFiltro()
           => FiltroBase;

        public class GetFormaPagamentosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetFormaPagamentosQueries, RequestResultForUpdate>
        {
            public async Task<RequestResultForUpdate> Handle(GetFormaPagamentosQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _repository.FormaPagamentoRepository.SelectAsync(request.GetFiltro());
                    return new RequestResultForUpdate().Ok(entities);
                }
                catch (Exception ex)
                {

                    return new RequestResultForUpdate().BadRequest(ex.Message);
                }
            }
        }
    }
}
