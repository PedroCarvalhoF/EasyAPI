using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoUpdateCommand, RequestResult>
{
    public async Task<RequestResult> Handle(FormaPagamentoUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var formaPagamentoUpdateEntyt = FormaPagamentoEntity.Update(request.Id, request.Habilitado, request.DescricaFormaPagamento, request.Codigo, request.GetFiltro());

            if (!formaPagamentoUpdateEntyt.isBaseValida)
                return new RequestResult().EntidadeInvalida();

            await _repository.FormaPagamentoRepository.UpdateAsync(formaPagamentoUpdateEntyt, request.GetFiltro());
            var resultUpdate = await _repository.CommitAsync();
            if (resultUpdate)
                return new RequestResult().Ok("Alteração realizada com sucesso.");


            return new RequestResult().BadRequest("Não foi possível realizar alteração");
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}
