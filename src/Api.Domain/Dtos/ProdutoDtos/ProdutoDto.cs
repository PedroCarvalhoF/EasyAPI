using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Entities.ProdutoMedida;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.ProdutoTipo;

namespace Domain.Dtos.ProdutoDtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoBarrasPersonalizado { get; set; }
        public string? Descricao { get; set; }
        public string? Observacoes { get; set; }
        public CategoriaProdutoDto? CategoriaProdutoEntity { get; set; }
        public ProdutoMedidaDto? ProdutoMedidaEntity { get; set; }
        public ProdutoTipoDto? ProdutoTipoEntity { get; set; }
        public string? ImgUrl { get; set; }        
    }
}
