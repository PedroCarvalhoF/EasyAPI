using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries;

public class GetCategoriaProdutoEntityFilter : BaseCommands<IEnumerable<CategoriaProdutoDto>>
{
    public required CategoriaProdutoEntityFilter CategoriaProdutoEntityFilter { get; set; }
    public class GetCategoriaQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriaProdutoEntityFilter, RequestResult<IEnumerable<CategoriaProdutoDto>>>
    {
        public async Task<RequestResult<IEnumerable<CategoriaProdutoDto>>> Handle(GetCategoriaProdutoEntityFilter request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var categoriasEntities = await _repository.CategoriaProdutoRepository.SelectAsync(request.CategoriaProdutoEntityFilter, filtro);

                var dtos = DtoMapper.ParceCategoriaProdutoDto(categoriasEntities);

                return new RequestResult<IEnumerable<CategoriaProdutoDto>>().ResultOk(dtos);

            }
            catch (Exception ex)
            {

                return new RequestResult<IEnumerable<CategoriaProdutoDto>>().Erro(ex);
            }
        }
    }
}
