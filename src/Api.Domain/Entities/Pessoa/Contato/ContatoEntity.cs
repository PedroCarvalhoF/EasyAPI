using Api.Domain.Entities;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Enuns.Pessoas;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoa.Contato
{
    public class ContatoEntity : BaseEntity
    {
        [DisplayName("Tipo Contato")]
        [Required(ErrorMessage = "Informe o {0}")]
        public TipoContatoEnum? TipoContatoEnum { get; set; }
        
        [DisplayName("Contato")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? Numero { get; set; }

        public IEnumerable<PessoaContatoEntity>? PessoaContatos { get; set; }
    }
}
