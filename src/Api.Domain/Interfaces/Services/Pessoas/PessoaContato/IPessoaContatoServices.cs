using Domain.Dtos;
using Domain.Dtos.Pessoas.PessoaContato;
using Domain.Entities.Pessoa.PessoaContato;

namespace Domain.Interfaces.Services.Pessoas.PessoaContato
{
    public interface IPessoaContatoServices
    {
        Task<bool> CreateContatoEndereco(PessoaContatoEntity pessoaContatoEntity);

        Task<ResponseDto<List<PessoaContatoDto>>> GetPessoaContatoByPessoaId(Guid pessoaId);

    }
}
