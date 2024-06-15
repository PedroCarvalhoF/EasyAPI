using Api.Domain.Dtos.CategoriaProdutoDtos;

namespace Domain.Dtos.ProdutoDtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoBarrasPersonalizado { get; set; }
        //public string? Descricao { get; set; }
        //public string? Observacoes { get; set; }
        public CategoriaProdutoDto? CategoriaProdutoEntity { get; set; }
        //public ProdutoMedidaDto? ProdutoMedidaEntity { get; set; }
        //public ProdutoTipoDto? ProdutoTipoEntity { get; set; }
        //public string? ImgUrl { get; set; }
    }
}
