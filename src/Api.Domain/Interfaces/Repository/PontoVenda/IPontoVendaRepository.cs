using Api.Domain.Entities.PontoVenda;

namespace Domain.Interfaces.Repository.PontoVenda
{
    public interface IPontoVendaRepository
    {
        Task<IEnumerable<PontoVendaEntity>> GetPdvs();
        Task<PontoVendaEntity> GetByIdPdv(Guid pdvId);
        Task<IEnumerable<PontoVendaEntity>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV);
        Task<IEnumerable<PontoVendaEntity>> AbertosFechados(bool abertoFechado);
    }
}
