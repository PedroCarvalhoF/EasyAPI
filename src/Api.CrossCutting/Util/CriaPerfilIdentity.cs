using Api.Identity.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Util
{
    public class CriaPerfilIdentity
    {
        public async Task CriarPerfisUsuariosAsync(WebApplication app)
        {
            IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (IServiceScope? scope = scopedFactory?.CreateScope())
            {
                ISeedUserRoleInitial? service = scope?.ServiceProvider.GetService<ISeedUserRoleInitial>();
                await service.SeedRolesAsync();
                // await service.SeedUsersAsync();

                //var service = scope.ServiceProvider.GetService<ISeedUserClaimsInitial>();
                //await service.SeedUserClaims();
            }
        }
    }
}
