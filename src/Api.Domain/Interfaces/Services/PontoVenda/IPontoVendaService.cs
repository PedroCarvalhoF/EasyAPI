using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos;
using Domain.Dtos.PontoVenda.Dashboards;
using Domain.Dtos.PontoVenda.Filtros;

namespace Api.Domain.Interfaces.Services.PontoVenda
{
    public interface IPontoVendaService
    {
        Task<ResponseDto<List<PontoVendaDto>>> GetPdvs();
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPdv(Guid pdvId);
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV);
        Task<ResponseDto<List<PontoVendaDto>>> AbertosFechados(bool abertoFechado);
        Task<ResponseDto<List<PontoVendaDto>>> FiltrarByData(PontoVendaDtoFiltrarData data);
        Task<ResponseDto<List<PontoVendaDto>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate);
        Task<ResponseDto<List<PontoVendaDto>>> Encerrar(Guid pontoVendaId);
        Task<ResponseDto<List<DashPontoVendaResult>>> GetDashPdvById(Guid idPdv);

    }
}
