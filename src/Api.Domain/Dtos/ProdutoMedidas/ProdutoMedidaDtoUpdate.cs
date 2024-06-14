using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ProdutoMedidaDtos
{
    public class ProdutoMedidaDtoUpdate
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Informe a {0}")]
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a {0}")]
        public string? Descricao { get; set; }
        public bool Habilitado { get; set; }
    }
}