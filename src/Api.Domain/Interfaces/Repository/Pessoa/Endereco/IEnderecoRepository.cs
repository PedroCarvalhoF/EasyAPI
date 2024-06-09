using Domain.Entities.Pessoa.Endereco;

namespace Domain.Interfaces.Repository.Pessoa.Endereco
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<EnderecoEntity>> GetAll(bool include);
    }
}
