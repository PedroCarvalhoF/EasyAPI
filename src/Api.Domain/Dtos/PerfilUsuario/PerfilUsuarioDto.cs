using Api.Domain.Dtos;

namespace Domain.Dtos.PerfilUsuario
{
    public class PerfilUsuarioDto : BaseDto
    {
        public Guid IdentityId { get; set; }
        public string? Nome { get; set; }

    }
}
