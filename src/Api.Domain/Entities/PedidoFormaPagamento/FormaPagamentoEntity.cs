using Api.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.FormaPagamento
{
    public class FormaPagamentoEntity : BaseEntity
    {

        [MaxLength(80, ErrorMessage = "Número máximo de caracteres {0}")]
        [DisplayName("Descricao Forma de Pagamento")]
        [Required(ErrorMessage = "Informe a {0}")]
        public string? DescricaoFormaPg { get; set; }
    }
}
