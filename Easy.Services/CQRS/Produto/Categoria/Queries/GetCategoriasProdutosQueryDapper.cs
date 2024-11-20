using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries
{
    public class GetCategoriaProdutoEntityDapper : BaseCommands<IEnumerable<CategoriaProdutoDto>>
    {
        public required CategoriaProdutoEntityFilterDapper CategoriaProdutoEntityFilterDapper { get; set; }
        public class GetCategoriaProdutoEntityDapperHandler(ICategoriaProdutoDapperRepository<FiltroBase> _dapperRepository) : IRequestHandler<GetCategoriaProdutoEntityDapper, RequestResult<IEnumerable<CategoriaProdutoDto>>>
        {
            public async Task<RequestResult<IEnumerable<CategoriaProdutoDto>>> Handle(GetCategoriaProdutoEntityDapper request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();
                    IEnumerable<CategoriaProdutoEntity>? entities = null;

                    if (request.CategoriaProdutoEntityFilterDapper.GetAll.HasValue)
                        if (request.CategoriaProdutoEntityFilterDapper.GetAll == true)
                        {
                            entities = await _dapperRepository.GetCategoriasProdutoAsync(filtro);
                            var dtos = DtoMapper.ParceCategoriaProdutoDto(entities);
                            return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(dtos);
                        }


                    if (request.CategoriaProdutoEntityFilterDapper.CategoriaProdutoId != null && request.CategoriaProdutoEntityFilterDapper.CategoriaProdutoId != Guid.Empty)
                    {
                        var entity = await _dapperRepository.GetCategoriaProdutoByIdCategoria(request.CategoriaProdutoEntityFilterDapper.CategoriaProdutoId, filtro);
                        var dtoById = DtoMapper.ParceCategoriaProdutoDto(entity);
                        return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(new List<CategoriaProdutoDto>
                        { dtoById});
                    }

                    if (!string.IsNullOrEmpty(request.CategoriaProdutoEntityFilterDapper.DescricaoCategoriasProdutosEquals))
                    {
                        entities = await _dapperRepository.GetCategoriaProdutoEqualsCategoriaQuery(filtro, request.CategoriaProdutoEntityFilterDapper.DescricaoCategoriasProdutosEquals);
                        var dtoByCategoriaEquals = DtoMapper.ParceCategoriaProdutoDto(entities);
                        return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(dtoByCategoriaEquals);
                    }
                    else
                    if (!string.IsNullOrEmpty(request.CategoriaProdutoEntityFilterDapper.DescricaoCategoriasProdutosContains))
                    {
                        entities = await _dapperRepository.GetCategoriaProdutoContainsCategoriaQuery(filtro, request.CategoriaProdutoEntityFilterDapper.DescricaoCategoriasProdutosEquals!);
                        var dtosByCategoriaContains = DtoMapper.ParceCategoriaProdutoDto(entities);
                        return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(dtosByCategoriaContains);
                    }

                    if(request.CategoriaProdutoEntityFilterDapper.Habilitado.HasValue)
                    {
                        entities = await _dapperRepository.GetCategoriasProdutosHabilitadosDesabilitados(filtro, request.CategoriaProdutoEntityFilterDapper.Habilitado);
                        var dtosByCategoriaContains = DtoMapper.ParceCategoriaProdutoDto(entities);
                        return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(dtosByCategoriaContains);
                    }


                    return new RequestResult<IEnumerable<CategoriaProdutoDto>>().Erro("Não foi possível realizar consulta.");
                }
                catch (Exception ex)
                {
                    return new RequestResult<IEnumerable<CategoriaProdutoDto>>().Erro(ex);
                }
            }
        }
    }
}
