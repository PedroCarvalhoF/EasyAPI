using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos;
using Domain.Dtos.PontoVenda.Dashboards;
using Domain.Dtos.PontoVenda.Filtros;

namespace Api.Domain.Interfaces.Services.PontoVenda
{
    public interface IPontoVendaService
    {
        Task<ResponseDto<List<PontoVendaDto>>> GetPdvs(bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPdv(Guid pdvId, bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV, bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> AbertosFechados(bool abertoFechado, bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> FiltrarByData(PontoVendaDtoFiltrarData data, bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate, bool include = false);
        Task<ResponseDto<List<PontoVendaDto>>> Encerrar(Guid pontoVendaId, bool include = false);
        Task<ResponseDto<List<DashPontoVendaResult>>> GetDashPdvById(Guid idPdv, bool include = false);

    }
}
