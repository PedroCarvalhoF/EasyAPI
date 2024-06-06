using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.IdentityRole
{
    public class RoleDtoCreate
    {
        [Required(ErrorMessage = "Informe a função")]
        public string? RoleName { get; set; }

    }
}
