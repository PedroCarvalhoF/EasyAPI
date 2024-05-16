using Domain.Dtos;
using Domain.Dtos.PontoVendaUser;

namespace Domain.Interfaces.Services.PontoVendaUser
{
    public interface IUsuarioPontoVendaService
    {
        Task<ResponseDto<List<UsuarioPontoVendaDto>>> GetAll();
        Task<ResponseDto<List<UsuarioPontoVendaDto>>> Get(Guid id);
        Task<ResponseDto<List<UsuarioPontoVendaDto>>> GetByIdUser(Guid userId);
        Task<ResponseDto<List<UsuarioPontoVendaDto>>> Create(UsuarioPontoVendaDtoCreate userCreate);
    }
}
