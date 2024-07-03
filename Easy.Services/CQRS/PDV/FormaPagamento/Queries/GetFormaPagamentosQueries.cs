using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Queries
{
    public class GetFormaPagamentosQueries : IRequest<RequestResult>
    {
        private FiltroBase FiltroBase { get; set; }
        public void SetUsers(FiltroBase user)
            => FiltroBase = user;
        public FiltroBase GetFiltro()
           => FiltroBase;

        public class GetFormaPagamentosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetFormaPagamentosQueries, RequestResult>
        {
            public async Task<RequestResult> Handle(GetFormaPagamentosQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _repository.FormaPagamentoRepository.SelectAsync(request.GetFiltro());
                    return new RequestResult().Ok(entities);
                }
                catch (Exception ex)
                {

                    return new RequestResult().BadRequest(ex.Message);
                }
            }
        }
    }
}
