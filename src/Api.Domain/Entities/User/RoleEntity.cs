using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public List<UserRoleEntity>? UserRoles { get; set; }
    }
}
