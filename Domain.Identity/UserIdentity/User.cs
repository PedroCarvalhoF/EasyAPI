using Microsoft.AspNetCore.Identity;

namespace Domain.Identity.UserIdentity
{
    public class User : IdentityUser<Guid>
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? ImagemURL { get; set; } = string.Empty;
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}