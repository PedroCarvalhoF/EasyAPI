using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.IdentityRole
{
    public class UserRoleDtoAdd
    {
        [Required]
        public Guid PessoaId { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}
