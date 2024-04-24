using Api.Domain.Entities;
using Api.Domain.Entities.Pessoa.PessoaTipo;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoa.Pessoas
{
    public class PessoaEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string? PrimeiroNome { get; set; }
        [Required]
        [MaxLength(200)]
        public string? SegundoNome { get; set; }
        [Required]
        [MaxLength(20)]
        public string? RgIE { get; set; }
        [Required]
        [MaxLength(20)]
        public string? CpfCnpj { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Sexo { get; set; }
        [Required]
        public DateTime DataNascimentoFundacao { get; set; }
        [Required]
        public Guid? PessoaTipoEntityId { get; set; }
        public PessoaTipoEntity? PessoaTipoEntity { get; set; }

    }
}
