using Domain.Entities.Pessoa.PessoaContato;

namespace Domain.Interfaces.Services.Pessoas.PessoaContato
{
    public interface IPessoaContatoServices
    {
        Task<bool> CreateContatoEndereco(PessoaContatoEntity pessoaContatoEntity);
    }
}
