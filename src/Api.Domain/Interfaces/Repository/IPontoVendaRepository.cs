using Api.Domain.Entities.PontoVenda;
using Domain.Dtos.PontoVendaDtos;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IPontoVendaRepository
    {
        Task<IEnumerable<PontoVendaEntity>> ConsultarPdvsById(List<Guid> idsPdvs);
        Task<IEnumerable<PontoVendaEntity>> ConsultarPontoVendaByData(PdvGetByData pdvGetByData);
        Task<IEnumerable<PontoVendaEntity>> GetByIdsPdvs(List<Guid> idsPdvs);
        Task<IEnumerable<PontoVendaEntity>> GetPontoVenda(Expression<Func<PontoVendaEntity, bool>> funcao, bool inlude = true);
        Task<IEnumerable<PontoVendaEntity>> InfoDashPdvsByPeriodo(PdvGetByData filtroConsultaPdvDashDto);
    }
}
