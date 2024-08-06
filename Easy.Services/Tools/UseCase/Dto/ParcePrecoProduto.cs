using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Services.DTOs.PrecoProduto;

namespace Easy.Services.Tools.UseCase.Dto;

public partial class DtoMapper
{
    public static PrecoProdutoDtoView ParcePrecoProduto(PrecoProdutoEntity pr)
    {
        return
            new PrecoProdutoDtoView
            {
                IdProduto = pr.Produto.Id,
                NomeProduto = pr.Produto.NomeProduto,
                IdCategoriaPreco = pr.CategoriaPreco.Id,
                CategoriaPreco = pr.CategoriaPreco.DescricaoCategoriaPreco,
                Preco = pr.Preco
            };
    }
}
