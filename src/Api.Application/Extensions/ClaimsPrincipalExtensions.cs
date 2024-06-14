using Domain.Dtos;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;
using System.Security.Claims;

namespace Api.Extensions
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

        public static UserMasterUserDtoCreate GetUserMasterUser(this ClaimsPrincipal user)
        {
            var userId = Guid.Parse(user.FindFirst("UserId")?.Value);
            var userMasterClienteIdentityId = Guid.Parse(user.FindFirst("UserMasterClienteIdentityId")?.Value);

            return new UserMasterUserDtoCreate
            {
                UserId = userId,
                UserMasterClienteIdentityId = userMasterClienteIdentityId,
            };
        }
        public static DtoUserClaims GetUserMasterUserDatalhes(this ClaimsPrincipal user)
        {
            return new DtoUserClaims
                (
                 userMasterId: user.FindFirst("UserMasterClienteIdentityId")?.Value,
                 userId: user.FindFirst("UserId")?.Value,
                 userName: user.FindFirst(ClaimTypes.Email)?.Value
                );
        }
    }
}