using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.UsuarioPdv
{
    public class UsuarioPdvDtoHabilitarDesabilitar
    {
        [Required]
        public Guid UserPdvId { get; private set; }
        [Required]
        public bool Habiitado { get; private set; }
        public UsuarioPdvDtoHabilitarDesabilitar(Guid userPdvId, bool habiitado)
        {
            UserPdvId = userPdvId;
            Habiitado = habiitado;
        }
    }
}
