using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Queries;

public class GetProdutosQueryCommand : BaseCommands<IEnumerable<ProdutoDto>>
{
    public required ProdutoEntityFilterDapper ProdutoEntityFilterDapper { get; set; }
    public class GetProdutosQueryHandler(IProdutoDapperRepository<FiltroBase> _repositoryDapper) : IRequestHandler<GetProdutosQueryCommand, RequestResult<IEnumerable<ProdutoDto>>>
    {
        public async Task<RequestResult<IEnumerable<ProdutoDto>>> Handle(GetProdutosQueryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.ProdutoEntityFilterDapper.GetAll.HasValue)
                {
                    if(request.ProdutoEntityFilterDapper.GetAll.Value)
                    {
                        var produtoEntitiesViewBD = await _repositoryDapper.GetAllProdutosAsync(request.GetFiltro());
                        var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                        return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);

                    }
                }

                return new RequestResult<IEnumerable<ProdutoDto>>().SemParamentroConsulta();
            }
            catch (Exception ex)
            {
                return new RequestResult<IEnumerable<ProdutoDto>>().Erro(ex);
            }
        }
    }
}
