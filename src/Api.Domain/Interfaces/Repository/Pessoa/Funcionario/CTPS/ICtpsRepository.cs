using Domain.Entities.Pessoa.Funcionario.CTPS;

namespace Domain.Interfaces.Repository.Pessoa.Funcionario.CTPS
{
    public interface ICtpsRepository
    {
        Task<IEnumerable<CtpsEntity>> GetAll();
        Task<CtpsEntity> GetByIdCtps(Guid ctpsId);
    }
}
