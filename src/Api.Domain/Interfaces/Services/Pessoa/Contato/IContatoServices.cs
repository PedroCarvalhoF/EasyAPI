using Domain.Dtos;
using Domain.Dtos.Pessoas.Contato;

namespace Domain.Interfaces.Services.Pessoas.Contato
{
    public interface IContatoServices
    {
        Task<ResponseDto<List<ContatoDto>>> GetAllContatos();
        Task<ResponseDto<List<ContatoDto>>> GetByContatoId(Guid idContato);
        Task<ResponseDto<List<ContatoDto>>> CreateContato(ContatoDtoCreate create);
        Task<ResponseDto<List<ContatoDto>>> UpdateContato(ContatoDtoUpdate update);
        Task<ResponseDto<List<ContatoDto>>> DeleteContato(Guid idContato);
    }
}
