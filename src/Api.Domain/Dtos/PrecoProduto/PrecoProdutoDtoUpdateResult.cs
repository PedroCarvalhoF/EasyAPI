using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos.ProdutoDtos;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoUpdateResult : BaseDto
    {
        public ProdutoDto? ProdutoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
        public Decimal PrecoProduto { get; set; }
        public bool Habilitado { get; set; }

    }
}