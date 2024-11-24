using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PrecoProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Queries;

public class GetPrecoProdutoDapperFilterCommand : BaseCommands<IEnumerable<PrecoProdutoDto>>
{
    public required PrecoProdutoEntityFilterDapper PrecoProdutoEntityFilterDapper { get; set; }
    public class GetPrecosProdutosQueryHandler(IPrecoProdutoDapperRepository<FiltroBase, PrecoProdutoEntityFilterDapper> _dapperRepository) : IRequestHandler<GetPrecoProdutoDapperFilterCommand, RequestResult<IEnumerable<PrecoProdutoDto>>>
    {
        public async Task<RequestResult<IEnumerable<PrecoProdutoDto>>> Handle(GetPrecoProdutoDapperFilterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var precosEntitiesViewBD = await _dapperRepository.GetPrecoProdutoFilterAsync(request.GetFiltro(), request.PrecoProdutoEntityFilterDapper);
                var dtos = DtoMapper.ParcePrecoProdutoDto(precosEntitiesViewBD);

                return new RequestResult<IEnumerable<PrecoProdutoDto>>().ResultOk(dtos!);
            }
            catch (Exception ex)
            {

                return new RequestResult<IEnumerable<PrecoProdutoDto>>().Erro(ex);
            }
        }
    }
}
