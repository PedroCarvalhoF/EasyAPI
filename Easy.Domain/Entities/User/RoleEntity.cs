using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Entities.User
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public List<UserRoleEntity>? UserRoles { get; set; }
    }
}
