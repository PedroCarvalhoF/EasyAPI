using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.FormaPagamento;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Queries
{
    public class GetFormaPagamentosQueries : BaseCommands<IEnumerable<FormaPagamentoDto>>
    {
        public class GetFormaPagamentosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetFormaPagamentosQueries, RequestResult<IEnumerable<FormaPagamentoDto>>>
        {
            public async Task<RequestResult<IEnumerable<FormaPagamentoDto>>> Handle(GetFormaPagamentosQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _repository.FormaPagamentoRepository.SelectAsync(request.GetFiltro());

                    var formasPagamentosDtos = DtoMapper.ParceFormaPagamentoDto(entities);

                    return RequestResult<IEnumerable<FormaPagamentoDto>>.Ok(formasPagamentosDtos);
                }
                catch (Exception ex)
                {

                    return RequestResult<IEnumerable<FormaPagamentoDto>>.BadRequest(ex.Message);
                }
            }
        }
    }
}
