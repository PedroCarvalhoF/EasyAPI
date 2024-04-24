using Domain.Dtos.PessoasDtos.PessoaDtos;

namespace Domain.Interfaces.Services.Pessoas.Pessoa
{
    public interface IPessoaServices
    {
        Task<PessoaDto> Get(Guid idPessoa);
        Task<IEnumerable<PessoaDto>> GetAll();
        Task<IEnumerable<PessoaDto>> GetAll(Guid pessoaTipo);
        Task<PessoaDto> Create(PessoaDtoCreate pessoaCreate);
        Task<PessoaDto> Update(PessoaDtoUpdate pessoaDto);
    }
}
