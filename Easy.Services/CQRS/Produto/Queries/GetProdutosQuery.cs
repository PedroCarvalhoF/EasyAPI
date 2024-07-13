using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.CQRS.Produto.Helper;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Queries;

public class GetProdutosQuery : BaseCommands<IEnumerable<ProdutoDtoView>>
{
    public class GetProdutosQueryHandler(IProdutoDapperRepository<FiltroBase> _produtoDapperRepository) : IRequestHandler<GetProdutosQuery, RequestResult<IEnumerable<ProdutoDtoView>>>
    {
        public async Task<RequestResult<IEnumerable<ProdutoDtoView>>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtoEntities = await _produtoDapperRepository.GetProdutosAsync(request.GetFiltro());

            var produtos = produtoEntities.Select(prod => new ProdutoDtoView
            {
                Id = prod.Id,
                Codigo = prod.Codigo,
                DescricaoCategoria = prod.CategoriaProdutoEntity.DescricaoCategoria ?? string.Empty,
                Medida = ProdutoHelperDto.GetMedida(prod.MedidaProdutoEnum),
                NomeProduto = prod.NomeProduto ?? string.Empty,
                TipoProduto = ProdutoHelperDto.GetTipo(prod.TipoProdutoEnum),
            }).ToList();

            return RequestResult<IEnumerable<ProdutoDtoView>>.Ok(produtos);
        }
    }
}
