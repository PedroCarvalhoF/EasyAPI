using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Repository.PessoaRepositorys.Pessoa
{
    public interface IPessoaRepository
    {
        Task<PessoaEntity> Get(Guid idPessoa, bool include = true);
        Task<IEnumerable<PessoaEntity>> GetAll(bool include = true);
        Task<IEnumerable<PessoaEntity>> GetAll(Guid pessoaTipo, bool include = true);
    }
}
