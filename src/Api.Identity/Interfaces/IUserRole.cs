using Domain.Identity.UserIdentity;

namespace Identity.Interfaces
{
    public interface IUserRole
    {
        Task<bool> AddRole(Guid pessoaId, Guid roldId);
        Task<bool> CreateRole(string UserRole);
        Task<IEnumerable<Role>> GetRoles();
    }
}
