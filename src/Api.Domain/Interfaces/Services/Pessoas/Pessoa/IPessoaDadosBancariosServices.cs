using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Interfaces.Services.Pessoas.Pessoa
{
    public interface IPessoaDadosBancariosServices
    {
        Task<bool> CreatePessoaDadosBancarios(PessoaDadosBancariosEntity entity);
    }
}
