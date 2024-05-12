using Microsoft.AspNetCore.Identity;

namespace Domain.Identity.UserIdentity
{
    public class Role : IdentityRole<Guid>
    {
        public List<UserRole>? UserRoles { get; set; }
    }
}