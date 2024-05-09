using Api.Domain.Dtos;

namespace Domain.Dtos.ProdutoTipo
{
    public class ProdutoTipoDto : BaseDto
    {
        public DateTime? UpdateAt { get; set; }
        public string? DescricaoTipoProduto { get; set; }
    }
}
