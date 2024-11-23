using Easy.Domain.Entities.Produto;
using Easy.Domain.EntitiesBD.Produto;
using Easy.Services.DTOs.Produto;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static ProdutoDto ParceProdutoDto(ProdutoEntityViewBD produtoEntityViewBDs)
        {
            return new ProdutoDto(produtoId: produtoEntityViewBDs.ProdutoId,
                                nomeProduto: produtoEntityViewBDs.NomeProduto,
                                     codigo: produtoEntityViewBDs.Codigo,
                                  imagemUrl: produtoEntityViewBDs.ImagemUrl,
                          medidaProdutoEnum: produtoEntityViewBDs.MedidaProdutoEnum,
                            tipoProdutoEnum: produtoEntityViewBDs.TipoProdutoEnum,
                                categoriaId: produtoEntityViewBDs.CategoriaId,
                         descricaoCategoria: produtoEntityViewBDs.DescricaoCategoria,
                                 habilitado: produtoEntityViewBDs.Habilitado);
        }
        public static IEnumerable<ProdutoDto> ParceProdutoDto(IEnumerable<ProdutoEntityViewBD> produtoEntityViewBDs)
        {
            foreach (var produto in produtoEntityViewBDs)
            {
                yield return ParceProdutoDto(produto);
            }
        }
    }
}
