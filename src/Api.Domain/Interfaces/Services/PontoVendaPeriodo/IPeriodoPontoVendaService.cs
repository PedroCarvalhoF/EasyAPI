using Domain.Dtos.PontoVendaPeriodoVendaDtos;

namespace Domain.Interfaces.Services.PeriodoPontoVenda
{
    public interface IPeriodoPontoVendaService
    {
        Task<IEnumerable<PeriodoPontoVendaDto>> GetAll();
        Task<PeriodoPontoVendaDto> Get(Guid id);
        Task<IEnumerable<PeriodoPontoVendaDto>> Get(string descricao);
        Task<PeriodoPontoVendaDto> Create(PeriodoPontoVendaDtoCreate create);

        Task<bool> Desabilitar(Guid id);
    }
}
