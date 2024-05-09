using Microsoft.AspNetCore.Authorization;

namespace Api.Identity.PolicyRequirements
{
    public class HorarioComercialHandler : AuthorizationHandler<HorarioComercialRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HorarioComercialRequirement requirement)
        {
            TimeOnly horarioAtual = TimeOnly.FromDateTime(DateTime.Now);
            if (horarioAtual.Hour >= 8 && horarioAtual.Hour <= 22)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
