using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Services.DTOs.PrecoProduto;

namespace Easy.Services.Tools.UseCase.Dto;

public partial class DtoMapper
{
    public static PrecoProdutoDtoView ParcePrecoProduto(PrecoProdutoEntity pr)
    {
        return
            new PrecoProdutoDtoView(pr.Produto.Id, pr.Produto.Codigo, pr.Produto.NomeProduto, pr.Produto.CategoriaProdutoEntity.Id, pr.Produto.CategoriaProdutoEntity.DescricaoCategoria, pr.CategoriaPreco.Id, pr.CategoriaPreco.DescricaoCategoriaPreco, pr.Preco);

    }
}
