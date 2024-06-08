using Domain.Dtos;
using Domain.Dtos.ViaCEP;

namespace Domain.Interfaces.Services.ViaCEP
{
    public interface IViaCepService
    {
        Task<ResponseDto<List<ViaCEPDto>>> BuscarCEP(string cep);
    }
}
