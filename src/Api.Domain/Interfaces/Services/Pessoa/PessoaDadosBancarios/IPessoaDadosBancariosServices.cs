using Domain.Entities.Pessoa.PessoaDadosBancarios;

namespace Domain.Interfaces.Services.Pessoas.PessoaDadosBancarios
{
    public interface IPessoaDadosBancariosServices
    {
        Task<bool> CreatePessoaDadosBancarios(PessoaDadosBancariosEntity entity);
    }
}
