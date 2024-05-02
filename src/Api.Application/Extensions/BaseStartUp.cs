using Api.Domain.Interfaces.Services.CategoriaPreco;

namespace Api.Extensions
{
    public class BaseStartUp
    {
        public async Task CriarCategoriaPrecoBaseAsync(WebApplication app)
        {
            IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (IServiceScope? scope = scopedFactory?.CreateScope())
            {
                ICategoriaPrecoService? service = scope?.ServiceProvider.GetService<ICategoriaPrecoService>();


            }
        }
    }
}
