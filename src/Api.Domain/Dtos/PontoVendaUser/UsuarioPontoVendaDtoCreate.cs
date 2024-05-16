using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PontoVendaUser
{
    public class UsuarioPontoVendaDtoCreate
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id usuário")]
        public Guid UserId { get; set; }
    }
}
