using Domain.Dtos;
using Domain.Dtos.Pessoa.Funcionario.Funcao;

namespace Domain.Interfaces.Services.Pessoa.Funcionario.Funcao
{
    public interface IFuncaoFuncionarioServices
    {
       
        Task<ResponseDto<List<FuncaoFuncionarioDto>>> GetAll();
        Task<ResponseDto<List<FuncaoFuncionarioDto>>> GetById(Guid funcaoId);
        Task<ResponseDto<List<FuncaoFuncionarioDto>>> CreateFuncao(FuncaoFuncionarioDtoCreate create);
        Task<ResponseDto<List<FuncaoFuncionarioDto>>> Update(FuncaoFuncionarioDtoUpdate update);
    }
}
