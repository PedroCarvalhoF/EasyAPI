using Api.Domain.Entities.PontoVenda;
using Domain.Dtos.PontoVenda.Filtros;

namespace Domain.Interfaces.Repository.PontoVenda
{
    public interface IPontoVendaRepository
    {
        Task<IEnumerable<PontoVendaEntity>> GetPdvs(bool include = false);
        Task<PontoVendaEntity> GetByIdPdv(Guid pdvId, bool include = false);
        Task<IEnumerable<PontoVendaEntity>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV, bool include = false);
        Task<IEnumerable<PontoVendaEntity>> AbertosFechados(bool abertoFechado, bool include = false);
        Task<IEnumerable<PontoVendaEntity>> FiltrarByData(PontoVendaDtoFiltrarData data, bool include = false);
    }
}
