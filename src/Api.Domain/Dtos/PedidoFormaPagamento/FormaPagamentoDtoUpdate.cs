using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.FormaPagamentoDtos
{
    public class FormaPagamentoDtoUpdate
    {
        [Required(ErrorMessage = "Necessário o Id para realizar alteração")]
        public Guid Id { get; set; }

        [MaxLength(80, ErrorMessage = "Número máximo de caracteres {0}.")]
        [DisplayName("Descricao Forma de Pagamento")]
        [Required(ErrorMessage = "Informe a {0}")]
        public string? DescricaoFormaPg { get; set; }


        [Required(ErrorMessage = "Informe se está habilitado ou não.")]
        public bool Habilitado { get; set; }
    }
}
