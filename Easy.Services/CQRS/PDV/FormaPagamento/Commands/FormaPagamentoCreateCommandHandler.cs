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
            var formaPagamentoEntity = FormaPagamentoEntity.Create(request.DescricaFormaPagamento, request.Codigo, request.GetFiltro());
            if (!formaPagamentoEntity.isBaseValida)
                return new RequestResultForUpdate().EntidadeInvalida();

            await _repository.FormaPagamentoRepository.InsertAsync(formaPagamentoEntity, request.GetFiltro());
            var result = await _repository.CommitAsync();
            if (result)
                return new RequestResultForUpdate().Ok("Forma de pagamento criada com sucesso");

            return new RequestResultForUpdate().BadRequest("Não foi possível criar forma de pagamento.");

        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}
