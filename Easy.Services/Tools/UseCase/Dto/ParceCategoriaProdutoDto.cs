using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Services.DTOs.CategoriaProduto;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static CategoriaProdutoDto ParceCategoriaProdutoDto(CategoriaProdutoEntity categoriaProdutoEntity)
        {
            return new CategoriaProdutoDto(id: categoriaProdutoEntity.Id,
                                             habilitado: categoriaProdutoEntity.Habilitado,
                               descricaoCategoria: categoriaProdutoEntity.DescricaoCategoria!);
        }

        public static IEnumerable<CategoriaProdutoDto> ParceCategoriaProdutoDto(IEnumerable<CategoriaProdutoEntity> categoriasProdutosEntities)
        {
            foreach (var categoria_produto in categoriasProdutosEntities)
            {
                yield return ParceCategoriaProdutoDto(categoria_produto);
            }
        }
    }
}
