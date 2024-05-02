using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos.ProdutoDtos;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public ProdutoDto? ProdutoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
        public decimal PrecoProduto { get; set; }

    }
}