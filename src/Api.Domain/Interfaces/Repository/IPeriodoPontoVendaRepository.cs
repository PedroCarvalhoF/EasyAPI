using Domain.Entities.PontoVendaPeriodoVenda;

namespace Domain.Interfaces.Repository
{
    public interface IPeriodoPontoVendaRepository
    {
        Task<IEnumerable<PeriodoPontoVendaEntity>> Get(string descricao);
    }
}
