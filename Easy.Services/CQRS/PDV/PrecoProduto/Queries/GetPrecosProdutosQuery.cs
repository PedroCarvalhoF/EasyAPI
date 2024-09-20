using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PrecoProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Queries;

public class GetPrecosProdutosQuery : BaseCommands<List<PrecoProdutoDtoView>>
{

    public class GetPrecosProdutosQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPrecosProdutosQuery, RequestResult<List<PrecoProdutoDtoView>>>
    {
        public async Task<RequestResult<List<PrecoProdutoDtoView>>> Handle(GetPrecosProdutosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var precosProdutoEntities = await _repository.PrecoProdutoRepository.SelectAsync(filtro);

                List<PrecoProdutoDtoView> listaPrecoProdutoView = new List<PrecoProdutoDtoView>();

                foreach (var pr in precosProdutoEntities)
                {
                    var precoView = DtoMapper.ParcePrecoProduto(pr);
                    listaPrecoProdutoView.Add(precoView);
                }

                return RequestResult<List<PrecoProdutoDtoView>>.Ok(listaPrecoProdutoView ?? new List<PrecoProdutoDtoView>());
            }
            catch (Exception ex)
            {

                return RequestResult<List<PrecoProdutoDtoView>>.BadRequest(ex.Message);
            }
        }
    }
}
