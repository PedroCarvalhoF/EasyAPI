using Domain.Entities.Pessoa.Endereco;

namespace Domain.Entities.Pessoa.PessoaEndereco
{
    public class PessoaEnderecoEntity
    {
        public Guid PessoaEntityId { get; set; }
        public PessoaEntity? PessoaEntity { get; set; }
        public Guid EnderecoEntityId { get; set; }
        public EnderecoEntity? EnderecoEntity { get; set; }
    }
}
