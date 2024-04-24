using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.PedidoDtos;
using Domain.Dtos.PontoVendaDtos;
using Service.Services.PontoVendaService;

namespace Api.Domain.Interfaces.Services.PontoVenda
{
    public interface IPontoVendaService
    {
        Task<PontoVendaDto> GerarPontoVenda(PontoVendaDtoCreate pontoVendaDtoCreate);
        Task<PontoVendaDto> EncerrarPontoVenda(Guid pontoVendaId);
        Task<IEnumerable<PontoVendaDto>> ConsultarPontoVenda(bool abertoFechado);
        Task<PontoVendaResumoDetalhadoDto> ConsultarPontoVenda(Guid pontoVendaId);
        Task<IEnumerable<PontoVendaDto>> ConsultarPdvsById(List<Guid> idsPdvs);
        Task<IEnumerable<PontoVendaResumoDiaDto>> InfoDashPdvsByPeriodo(PdvGetByData FiltroConsultaPdvDashDto);
        Task<DashPontoVendaDtosV2> DashPdvsByIdsPdvs(List<Guid> idsPdvs);
        Task<IEnumerable<PontoVendaDto>> ConsultarPontoVendaByData(PdvGetByData pdvGetByData);
    }
}
