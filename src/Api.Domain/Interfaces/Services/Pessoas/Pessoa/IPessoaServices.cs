using Domain.Dtos;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Enuns.Pessoas;

namespace Domain.Interfaces.Services.Pessoas.Pessoa
{
    public interface IPessoaServices
    {
        Task<ResponseDto<List<PessoaDto>>> GetAll(bool include = false);
        Task<ResponseDto<List<PessoaDto>>> Get(Guid idPessoa, bool include = false);
        Task<ResponseDto<List<PessoaDto>>> GetAllByPessoaTipo(PessoaTipoEnum pessoaTipo, bool include = false);
        Task<ResponseDto<List<PessoaDto>>> Create(PessoaDtoCreate pessoaDtoCreate);
        Task<ResponseDto<List<PessoaDto>>> Update(PessoaDtoUpdate pesssoaUpdate);
    }
}
