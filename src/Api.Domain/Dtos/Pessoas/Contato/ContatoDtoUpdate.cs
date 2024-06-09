using Domain.Enuns.Pessoas;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoas.Contato
{
    public class ContatoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [DisplayName("Tipo Contato")]
        [Required(ErrorMessage = "Informe o {0}")]
        public TipoContatoEnum? TipoContatoEnum { get; set; }

        [DisplayName("Contato")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? Numero { get; set; }
    }
}
