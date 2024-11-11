using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoUpdateCommand, RequestResultForUpdate>
{
    public async Task<RequestResultForUpdate> Handle(FormaPagamentoUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            


            return new RequestResultForUpdate().BadRequest("Não foi possível realizar alteração");
        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}
