using Domain.Entities.PontoVendaPeriodoVenda;

namespace Domain.Repository
{
    public interface IPeriodoPontoVendaRepository
    {
        Task<IEnumerable<PeriodoPontoVendaEntity>> Get(string descricao);
    }
}
