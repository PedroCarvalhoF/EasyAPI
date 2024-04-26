using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PessoasDtos.PessoaDtos
{
    public class PessoaDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? PrimeiroNome { get; set; }

        [Required]
        public string? SegundoNome { get; set; }
        [Required]
        public string? CpfCnpj { get; set; }
        [Required]
        public string? RgIE { get; set; }

        [Required]
        public string? Sexo { get; set; }

        [Required]
        public DateTime DataNascimentoFundacao { get; set; }

        [Required]
        public Guid? PessoaTipoEntityId { get; set; }
    }
}
