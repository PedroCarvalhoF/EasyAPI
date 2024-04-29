using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos;

namespace Api.Domain.Interfaces.Services.PontoVenda
{
    public interface IPontoVendaService
    {
        Task<ResponseDto<List<PontoVendaDto>>> GetPdvs();
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPdv(Guid pdvId);
        Task<ResponseDto<List<PontoVendaDto>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV);
        Task<ResponseDto<List<PontoVendaDto>>> AbertosFechados(bool abertoFechado);
        Task<ResponseDto<List<PontoVendaDto>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate);
        Task<ResponseDto<List<PontoVendaDto>>> Encerrar(Guid pontoVendaId);


    }
}
