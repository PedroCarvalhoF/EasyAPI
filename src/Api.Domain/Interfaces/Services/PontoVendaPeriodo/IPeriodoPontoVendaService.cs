using Domain.Dtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;

namespace Domain.Interfaces.Services.PeriodoPontoVenda
{
    public interface IPeriodoPontoVendaService
    {
        Task<ResponseDto<List<PeriodoPontoVendaDto>>> GetAll();
        Task<ResponseDto<List<PeriodoPontoVendaDto>>> Get(Guid id);
        Task<ResponseDto<List<PeriodoPontoVendaDto>>> Get(string descricao);
        Task<ResponseDto<List<PeriodoPontoVendaDto>>> Create(PeriodoPontoVendaDtoCreate create);
        Task<ResponseDto<List<PeriodoPontoVendaDto>>> Desabilitar(Guid id);
    }
}
