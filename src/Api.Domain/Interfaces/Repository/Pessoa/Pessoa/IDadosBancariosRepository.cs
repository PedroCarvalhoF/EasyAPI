using Domain.Entities.Pessoa.DadosBancarios;

namespace Domain.Interfaces.Repository.Pessoa.Pessoa
{
    public interface IDadosBancariosRepository
    {
        Task<IEnumerable<DadosBancariosEntity>> GetAll(bool include = false);
        Task<IEnumerable<DadosBancariosEntity>> GetByAgencia(string agencia, bool include = false);
        Task<DadosBancariosEntity> GetByContaCorrente(string contaComDigito, bool include = false);
    }
}
