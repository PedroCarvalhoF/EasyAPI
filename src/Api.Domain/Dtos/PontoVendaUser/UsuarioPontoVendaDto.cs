using Api.Domain.Dtos;
using Domain.Identity.UserIdentity;

namespace Domain.Dtos.PontoVendaUser
{
    public class UsuarioPontoVendaDto : BaseDto
    {
        public User? User { get; set; }
    }
}
