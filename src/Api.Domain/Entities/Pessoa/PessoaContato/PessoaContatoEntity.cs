using Domain.Entities.Pessoa.Contato;
using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Entities.Pessoa.PessoaContato
{
    public class PessoaContatoEntity
    {
        public Guid PessoaEntityId { get; set; }
        public PessoaEntity? PessoaEntity { get; set; }
        public Guid ContatoEntityId { get; set; }
        public ContatoEntity? ContatoEntity { get; set; }
    }
}
