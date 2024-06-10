using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoa.Funcionario.CTPS
{
    public class CtpsDtoCreate
    {
        [Required]
        public string? NumeroCTPS { get; set; }
        [Required]
        public string? Serie { get; set; }
        [Required]
        public string? Digito { get; set; }
        [Required]
        public string? NumeroPIS { get; set; }
    }
}
