using Easy.Domain.Entities;
using Easy.Services.DTOs.UserClaims;
using System.Security.Claims;

namespace Easy.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
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

        public static FiltroBase GetUserMasterUser(this ClaimsPrincipal user)
        {
            var userId = Guid.Parse(user.FindFirst("UserId")?.Value);
            var userMasterClienteIdentityId = Guid.Parse(user.FindFirst("ClienteId")?.Value);

            return new FiltroBase(userMasterClienteIdentityId, userMasterClienteIdentityId);
        }
        public static DtoUserClaims GetUserMasterUserDatalhes(this ClaimsPrincipal user)
        {
            return new DtoUserClaims
                (
                 userMasterId: user.FindFirst("ClienteId")?.Value,
                 userId: user.FindFirst("UserId")?.Value,
                 userName: user.FindFirst(ClaimTypes.Email)?.Value
                );
        }
    }
}