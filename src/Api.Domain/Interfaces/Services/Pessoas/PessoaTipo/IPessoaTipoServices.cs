using Api.Domain.Dtos.PessoasDtos.PessoaTipoDtos;

namespace Api.Domain.Interfaces.Services.Pessoas.PessoaTipo
{
    public interface IPessoaTipoServices
    {
        Task<IEnumerable<PessoaTipoDto>> GetAll();

    }
}