using Domain.Dtos;
using Domain.Dtos.Pessoas.DadosBancarios;

namespace Domain.Interfaces.Services.Pessoas.Pessoa
{
    public interface IDadosBancariosServices
    {
        Task<ResponseDto<List<DadosBancariosDto>>> GetAll(bool include = false);
        Task<ResponseDto<List<DadosBancariosDto>>> GetByAgencia(string agencia, bool include = false);
        Task<ResponseDto<List<DadosBancariosDto>>> GetByContaCorrente(string ContaComDigito, bool include = false);
        Task<ResponseDto<List<DadosBancariosDto>>> Create(DadosBancariosDtoCreate create);
        Task<ResponseDto<List<DadosBancariosDto>>> Update(DadosBancariosDtoUpdate update);
    }
}
