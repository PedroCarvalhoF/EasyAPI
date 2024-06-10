using Domain.Dtos.Pessoa.Funcionario.CTPS;
using Domain.Dtos;

namespace Domain.Interfaces.Services.Pessoa.Funcionario.CTPS
{
    public interface ICtpsServices
    {
        Task<ResponseDto<List<CtpsDto>>> GetAll();
        Task<ResponseDto<List<CtpsDto>>> GetByIdCtps(Guid ctpsId);
        Task<ResponseDto<List<CtpsDto>>> Create(CtpsDtoCreate create);
        Task<ResponseDto<List<CtpsDto>>> Update(CtpsDtoUpdate update);
    }
}
