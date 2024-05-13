using Domain.Dtos;
using Domain.Identity.UserIdentity;

namespace Identity.Interfaces
{
    public interface IUserRole
    {
        Task<ResponseDto<List<Role>>> AddRole(Guid pessoaId, Guid roldId);
        Task<ResponseDto<List<Role>>> CreateRole(string UserRole);
        Task<ResponseDto<List<Role>>> GetRoles();
    }
}
