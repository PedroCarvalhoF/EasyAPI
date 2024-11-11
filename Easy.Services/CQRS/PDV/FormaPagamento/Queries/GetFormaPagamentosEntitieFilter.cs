using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.FormaPagamento;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Queries
{
    public class GetFormaPagamentosEntitieFilter : BaseCommands<IEnumerable<FormaPagamentoDto>>
    {
        public required FormaPagamentoEntityFilter FormaPagamentoEntityFilter { get; set; }
        public class GetFormaPagamentosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetFormaPagamentosEntitieFilter, RequestResult<IEnumerable<FormaPagamentoDto>>>
        {
            public async Task<RequestResult<IEnumerable<FormaPagamentoDto>>> Handle(GetFormaPagamentosEntitieFilter request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _repository.FormaPagamentoRepository.SelectAsync(request.FormaPagamentoEntityFilter, request.GetFiltro());
                    var dtos = DtoMapper.ParceFormaPagamentoDto(entities);

                    return RequestResult<IEnumerable<FormaPagamentoDto>>.Ok(dtos);
                }
                catch (Exception ex)
                {

                    return RequestResult<IEnumerable<FormaPagamentoDto>>.BadRequest(ex.Message);
                }
            }
        }
    }
}
