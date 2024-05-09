using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos.ProdutoDtos;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDto : BaseDto
    {
        public DateTime UpdateAt { get; set; }
        public ProdutoDto? ProdutoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
        public decimal PrecoProduto { get; set; }

    }
}