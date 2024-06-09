using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Interfaces.Services.Pessoas.PessoaEndereco
{
    public interface IPessoaEnderecoServices
    {
        Task<bool> CreatePessoaEndereco(PessoaEnderecoEntity pessoaEnderecoEntity);
    }
}
