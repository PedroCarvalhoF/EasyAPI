using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Interfaces.Services.Pessoas.PessoaDadosBancarios
{
    public interface IPessoaDadosBancariosServices
    {
        Task<bool> CreatePessoaDadosBancarios(PessoaDadosBancariosEntity entity);
    }
}
