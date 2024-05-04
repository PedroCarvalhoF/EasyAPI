using Microsoft.AspNetCore.Identity;

namespace Identity.Interfaces
{
    public interface IUserRole
    {
        Task<bool> AddRole(Guid pessoaId, Guid roldId);
        Task<bool> CreateRole(string UserRole);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
