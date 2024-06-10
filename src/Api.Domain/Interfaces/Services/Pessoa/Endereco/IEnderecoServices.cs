using Domain.Dtos;
using Domain.Dtos.Pessoas.Endereco;

namespace Domain.Interfaces.Services.Pessoas.Endereco
{
    public interface IEnderecoServices
    {
        Task<ResponseDto<List<EnderecoDto>>> GetAll(bool include);
        Task<ResponseDto<List<EnderecoDto>>> Create(EnderecoDtoCreate create);
        Task<ResponseDto<List<EnderecoDto>>> Update(EnderecoDtoUpdate update);
    }
}
