using Api.Domain.Dtos.CategoriaPrecoDtos;
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

                IEnumerable<CategoriaPrecoDto> categorias = await service.ConsultarTodos();

                if (categorias.Count() == 0)
                {
                    await service.Cadastrar(
                       new CategoriaPrecoDtoCreate
                       {
                           DescricaoCategoria = "BALCAO",
                           Habilitado = true
                       });
                }

            }
        }
    }
}
