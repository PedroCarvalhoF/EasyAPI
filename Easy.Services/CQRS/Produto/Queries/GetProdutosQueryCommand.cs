#region Using
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.EntitiesBD.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
#endregion
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
                var filtro = request.GetFiltro();

                if (request.ProdutoEntityFilterDapper.Id is { } produtoId && produtoId != Guid.Empty)
                {
                    var produtoEntitiesViewBD = await _repositoryDapper.GetProdutoByIdAsync(filtro, request.ProdutoEntityFilterDapper.Id.Value);
                    if (produtoEntitiesViewBD == null || produtoEntitiesViewBD.Count() == 0)
                        return new RequestResult<IEnumerable<ProdutoDto>>().Erro("Produto não encontrado.");

                    var dto = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);
                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dto);
                }
                if (request.ProdutoEntityFilterDapper.GetAll.HasValue)
                {
                    if (request.ProdutoEntityFilterDapper.GetAll.Value)
                    {
                        var produtoEntitiesViewBD = await _repositoryDapper.GetAllProdutosAsync(request.GetFiltro());
                        var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                        return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
                    }
                }
                if (request.ProdutoEntityFilterDapper.Habilitado.HasValue)
                {
                    IEnumerable<ProdutoEntityViewBD> produtoEntitiesViewBD = await _repositoryDapper.GetProdutosByHabilitadoAsync(filtro, request.ProdutoEntityFilterDapper.Habilitado.Value);
                    var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
                }
                if (request.ProdutoEntityFilterDapper.NomeDescricaoEquals is { } descricao && !string.IsNullOrEmpty(descricao))
                {
                    IEnumerable<ProdutoEntityViewBD> produtoEntitiesViewBD = await _repositoryDapper.GetProdutosByNomeDescricaoEqualsAsync(filtro, request.ProdutoEntityFilterDapper.NomeDescricaoEquals);
                    var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
                }
                if (request.ProdutoEntityFilterDapper.NomeDescricaoContains is { } descricaoContains && !string.IsNullOrEmpty(descricaoContains))
                {
                    IEnumerable<ProdutoEntityViewBD> produtoEntitiesViewBD = await _repositoryDapper.GetProdutosByNomeDescricaoContainsAsync(filtro, request.ProdutoEntityFilterDapper.NomeDescricaoContains);
                    var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
                }
                if (request.ProdutoEntityFilterDapper.IdCategoria is { } categoriaId && categoriaId != Guid.Empty)
                {
                    IEnumerable<ProdutoEntityViewBD> produtoEntitiesViewBD = await _repositoryDapper.GetProdutosByCategoriaIdAsync(filtro, request.ProdutoEntityFilterDapper.IdCategoria);
                    var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
                }
                if (request.ProdutoEntityFilterDapper.Codigo is { } codigo_produto && !string.IsNullOrEmpty(codigo_produto))
                {
                    IEnumerable<ProdutoEntityViewBD> produtoEntitiesViewBD = await _repositoryDapper.GetProdutosByCodigoAsync(filtro, request.ProdutoEntityFilterDapper.Codigo);
                    var dtos = DtoMapper.ParceProdutoDto(produtoEntitiesViewBD);

                    return new RequestResult<IEnumerable<ProdutoDto>>().ResultOk(dtos);
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
