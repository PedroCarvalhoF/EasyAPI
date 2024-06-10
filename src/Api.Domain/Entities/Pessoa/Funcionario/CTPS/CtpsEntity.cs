using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoa.Funcionario.CTPS
{
    public class CtpsEntity : BaseEntity
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
