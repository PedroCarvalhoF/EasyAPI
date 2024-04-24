using Microsoft.AspNetCore.Authorization;

namespace Api.Identity.PolicyRequirements
{
    public class HorarioComercialRequirement : IAuthorizationRequirement
    {
        public HorarioComercialRequirement() { }
    }
}
