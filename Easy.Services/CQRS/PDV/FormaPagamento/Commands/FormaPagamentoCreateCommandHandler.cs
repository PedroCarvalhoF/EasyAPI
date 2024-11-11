using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.PDV.FormaPagamento.Commands;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Command;

public class FormaPagamentoCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoCreateCommand, RequestResultForUpdate>
{
    public async Task<RequestResultForUpdate> Handle(FormaPagamentoCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
           

            return new RequestResultForUpdate().BadRequest("Não foi possível criar forma de pagamento.");

        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
        finally
        {
            _repository.FinalizarContexto();
        }
    }
}
