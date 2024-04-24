using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos.ProdutoDtos;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoCreateResult /*: BaseDto*/
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        ////SIMPLIFICADO TESTE
        //public Guid Id { get; set; }
        //public DateTime CreateAt { get; set; }
        //public Guid ProdutoEntityId { get; set; }
        //public String? NomeProduto { get; set; }

        //public Guid CategoriaPrecoEntityId { get; set; }
        //public String? DescricaoCategoria { get; set; }
        //public bool Habilitado { get; set; }

        //FULL
        public ProdutoDto? ProdutoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
        public Decimal PrecoProduto { get; set; }
        public bool Habilitado { get; set; }

    }
}