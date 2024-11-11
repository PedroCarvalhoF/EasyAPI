using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.FormaPagamento;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoCreateCommand : BaseCommands<FormaPagamentoDto>
{
    public required FormaPagamentoDtoCreate FormaPagamentoDtoCreate { get; set; }

    public class FormaPagamentoCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoCreateCommand, RequestResult<FormaPagamentoDto>>
    {
        public async Task<RequestResult<FormaPagamentoDto>> Handle(FormaPagamentoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var entityCreate = FormaPagamentoEntity.Create(descricaFormaPagamento: request.FormaPagamentoDtoCreate.DescricaFormaPagamento,
                                                                         codigo: request.FormaPagamentoDtoCreate.Codigo,
                                                                           user: filtro);

                if (!entityCreate.Validada)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Entidade inválida");

                var entityCodigoExisteEntity = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                {
                    Codigo = entityCreate.Codigo
                }, filtro)).SingleOrDefault();

                if (entityCodigoExisteEntity != null)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Código da forma de pagamento está existe.");

                var entityDescricaoExisteEntity = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                {
                    DescricaFormaPagamentoEquals = entityCreate.DescricaFormaPagamento
                }, filtro)).SingleOrDefault();

                if (entityDescricaoExisteEntity != null)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Descrição da forma de pagamento está existe.");


                await _repository.FormaPagamentoBaseRepository.InsertAsync(entityCreate);

                if (!await _repository.CommitAsync())
                    return RequestResult<FormaPagamentoDto>.BadRequest("Não foi possível salvar no banco.");

                var entityCreateResult = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                { FormaPagamentoId = entityCreate.Id }, filtro)).SingleOrDefault();

                if (entityCreateResult == null)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Forma de pagamento não localizada.");

                var dtoCreateResult = DtoMapper.ParceFormaPagamentoDto(entityCreateResult);

                return RequestResult<FormaPagamentoDto>.Ok(dtoCreateResult);
            }
            catch (Exception ex)
            {

                return RequestResult<FormaPagamentoDto>.BadRequest(ex.Message);
            }
        }
    }
}
