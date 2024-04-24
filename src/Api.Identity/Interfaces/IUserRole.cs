using Microsoft.AspNetCore.Identity;

namespace Identity.Interfaces
{
    public interface IUserRole
    {
        Task<bool> AplicarRoleUser(Guid pessoaId, Guid roldId);
        Task<bool> CadastrarRole(string UserRole);

        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
