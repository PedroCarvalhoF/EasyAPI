using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.FormaPagamento;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoUpdateCommand : BaseCommands<FormaPagamentoDto>
{
    public required FormaPagamentoDtoUpdate FormaPagamentoDtoUpdate { get; set; }
    public class FormaPagamentoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<FormaPagamentoUpdateCommand, RequestResult<FormaPagamentoDto>>
    {
        public async Task<RequestResult<FormaPagamentoDto>> Handle(FormaPagamentoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var formaPagamentoUpdateEntity = FormaPagamentoEntity.
                                                                      Update(id: request.FormaPagamentoDtoUpdate.Id,
                                                                     habilitado: request.FormaPagamentoDtoUpdate.Habilitado,
                                                         descricaFormaPagamento: request.FormaPagamentoDtoUpdate.DescricaFormaPagamento,
                                                                         codigo: request.FormaPagamentoDtoUpdate.Codigo,
                                                                           user: filtro);

                if (!formaPagamentoUpdateEntity.Validada)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Entidade inválida");

                var entityExist = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                {
                    FormaPagamentoId = formaPagamentoUpdateEntity.Id
                }, filtro)).SingleOrDefault();

                if (entityExist == null)
                    return RequestResult<FormaPagamentoDto>.BadRequest("Forma de pagamento não localizada.");


                var entityCodigoExisteEntity = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                {
                    Codigo = formaPagamentoUpdateEntity.Codigo
                }, filtro)).SingleOrDefault();

                if (entityCodigoExisteEntity != null)
                {
                    if (formaPagamentoUpdateEntity.Id != entityCodigoExisteEntity.Id)
                        return RequestResult<FormaPagamentoDto>.BadRequest("Código da forma de pagamento está existe.");
                }


                var entityDescricaoExisteEntity = (await _repository.FormaPagamentoRepository.SelectAsync(new FormaPagamentoEntityFilter
                {
                    DescricaFormaPagamentoEquals = formaPagamentoUpdateEntity.DescricaFormaPagamento
                }, filtro)).SingleOrDefault();

                if (entityDescricaoExisteEntity != null)
                    if (formaPagamentoUpdateEntity.Id != entityDescricaoExisteEntity.Id)
                        return RequestResult<FormaPagamentoDto>.BadRequest("Descrição da forma de pagamento está existe.");

                var result = await _repository.FormaPagamentoBaseRepository.Update(formaPagamentoUpdateEntity);
                if (!await _repository.CommitAsync())
                    return RequestResult<FormaPagamentoDto>.BadRequest("Não foi possível salvar no banco.");

                var dto = DtoMapper.ParceFormaPagamentoDto(formaPagamentoUpdateEntity);

                return RequestResult<FormaPagamentoDto>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<FormaPagamentoDto>.BadRequest(ex.Message);
            }
        }
    }
}
