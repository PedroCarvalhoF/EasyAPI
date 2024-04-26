using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ProdutoMedidaDtos
{
    public class ProdutoMedidaDtoCreate
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a {0}")]
        public string? Descricao { get; set; }
    }
}