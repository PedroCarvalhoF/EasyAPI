using Domain.Entities.Pessoa.Pessoas;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.Pessoa.PessoaTipo
{
    public class PessoaTipoEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string? DescricaoPessoaTipo { get; set; }

        public IEnumerable<PessoaEntity>? PessoaEntities { get; set; }
    }
}