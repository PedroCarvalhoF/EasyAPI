using Domain.Dtos;
using Domain.Dtos.Cotacoes.TaxasCDISELIC;

namespace Domain.Interfaces.Services.HGApis
{
    public interface ITaxasCDISelicService
    {
        Task<ResponseDto<List<TaxasDtosHGBrasil>>> GetTaxas();
    }
}
