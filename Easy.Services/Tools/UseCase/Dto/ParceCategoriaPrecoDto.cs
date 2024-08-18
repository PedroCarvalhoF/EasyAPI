using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Services.DTOs.CategoriaPreco;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static CategoriaPrecoDto ParceCategoriaPrecoDto(CategoriaPrecoEntity catPreco)
        {
            return new CategoriaPrecoDto(catPreco.Id, catPreco.Habilitado, catPreco.Codigo, catPreco.DescricaoCategoriaPreco);
        }

        public static IEnumerable<CategoriaPrecoDto> ParceCategoriasPrecosDto(IEnumerable<CategoriaPrecoEntity> categoriasPrecos)
        {
            foreach (var categoria in categoriasPrecos)
            {
                yield return ParceCategoriaPrecoDto(categoria);
            }
        }
    }
}
