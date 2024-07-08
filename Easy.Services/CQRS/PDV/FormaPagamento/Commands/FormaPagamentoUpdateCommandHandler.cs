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
            var formaPagamentoUpdateEntyt = FormaPagamentoEntity.Update(request.Id, request.Habilitado, request.DescricaFormaPagamento, request.Codigo, request.GetFiltro());

            if (!formaPagamentoUpdateEntyt.isBaseValida)
                return new RequestResultForUpdate().EntidadeInvalida();

            await _repository.FormaPagamentoRepository.UpdateAsync(formaPagamentoUpdateEntyt, request.GetFiltro());
            var resultUpdate = await _repository.CommitAsync();
            if (resultUpdate)
                return new RequestResultForUpdate().Ok("Alteração realizada com sucesso.");


            return new RequestResultForUpdate().BadRequest("Não foi possível realizar alteração");
        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}
