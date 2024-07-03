using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.PDV.FormaPagamento.Commands;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Command;

public class FormaPagamentoCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoCreateCommand, RequestResult>
{
    public async Task<RequestResult> Handle(FormaPagamentoCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var formaPagamentoEntity = FormaPagamentoEntity.Create(request.DescricaFormaPagamento, request.Codigo, request.GetFiltro());
            if (!formaPagamentoEntity.isBaseValida)
                return new RequestResult().EntidadeInvalida();

            await _repository.FormaPagamentoRepository.InsertAsync(formaPagamentoEntity, request.GetFiltro());
            var result = await _repository.CommitAsync();
            if (result)
                return new RequestResult().Ok("Forma de pagamento criada com sucesso");

            return new RequestResult().BadRequest("Não foi possível criar forma de pagamento.");

        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}
