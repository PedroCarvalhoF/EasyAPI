using Domain.Entities.Pessoa.Funcionario.Funcao;

namespace Domain.Interfaces.Repository.Pessoa.Funcionario.Funcao
{
    public interface IFuncaoFuncionarioRepository
    {
        Task<IEnumerable<FuncaoFuncionarioEntity>> GetAll();
        Task<FuncaoFuncionarioEntity> GetById(Guid funcaoId);
    }
}
