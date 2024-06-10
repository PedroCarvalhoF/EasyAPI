using Domain.Entities.Pessoa.PessoaEndereco;

namespace Domain.Interfaces.Services.Pessoas.PessoaEndereco
{
    public interface IPessoaEnderecoServices
    {
        Task<bool> CreatePessoaEndereco(PessoaEnderecoEntity pessoaEnderecoEntity);
    }
}
