using Easy.Domain.Entities;
using System.Security.Claims;

namespace Easy.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value!;
        }

        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        }

        public static Guid GetFiltroId(this ClaimsPrincipal user)
        {
            var filtroIdClaim = user.FindFirst("FiltroId")?.Value;
            if (Guid.TryParse(filtroIdClaim, out var filtroId))
            {
                return filtroId;
            }
            return Guid.Empty;
        }

        public static FiltroBase GetUserMasterUserDatalhes(this ClaimsPrincipal user)
        {
            return new FiltroBase(Guid.Parse(user.FindFirst("ClienteId")?.Value ?? throw new ArgumentException("Cliente não localizado.")), Guid.Parse(user.FindFirst("UserId")?.Value ?? throw new ArgumentException("Usuário não localizado")));
        }
    }
}