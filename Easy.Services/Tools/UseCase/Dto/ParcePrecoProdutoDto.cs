using Easy.Domain.EntitiesBD.PrecoProduto;
using Easy.Services.DTOs.PrecoProduto;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PrecoProdutoDto ParcePrecoProdutoDto(PrecoProdutoEntityViewBD precoEntity)
        {
            return new PrecoProdutoDto(precoEntity.PrecoProdutoId, precoEntity.PrecoProdutoId, precoEntity.PrecoHabilitado, precoEntity.ProdutoId, precoEntity.CodigoProduto, precoEntity.NomeProduto, precoEntity.Preco, precoEntity.CategoriaPrecoId, precoEntity.DescricaoCategoriaPreco);
        }

        public static IEnumerable<PrecoProdutoDto> ParcePrecoProdutoDto(IEnumerable<PrecoProdutoEntityViewBD> precosEntities)
        {
            foreach (var preco_produto in precosEntities)
            {
                yield return ParcePrecoProdutoDto(preco_produto);
            }
        }
    }
}
