using Domain.Entities.Pessoa.Pessoas;
using Domain.Enuns;

namespace Domain.Interfaces.Repository.PessoaRepositorys.Pessoa
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<PessoaEntity>> GetAll(bool include = false);
        Task<PessoaEntity> Get(Guid idPessoa, bool include = false);
        Task<IEnumerable<PessoaEntity>> GetAllByPessoaTipo(PessoaTipoEnum pessoaTipo, bool include = false);
    }
}
