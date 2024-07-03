using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Queries;

public class GetFormaPagamentoByIdQuery : IRequest<RequestResult>
{
    public Guid Id { get; set; }
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetFormaPagamentoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetFormaPagamentoByIdQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetFormaPagamentoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var formaPagamento = await _repository.FormaPagamentoRepository.SelectAsync(request.Id, request.GetFiltro());

                return new RequestResult().Ok(formaPagamento);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
