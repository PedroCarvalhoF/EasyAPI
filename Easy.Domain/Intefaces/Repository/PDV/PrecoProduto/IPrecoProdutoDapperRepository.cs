using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.EntitiesBD.PrecoProduto;

namespace Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;

public interface IPrecoProdutoDapperRepository<F, FD> where F : FiltroBase where FD : PrecoProdutoEntityFilterDapper
{
    Task<IEnumerable<PrecoProdutoEntityViewBD>> GetPrecoProdutoFilterAsync(F filtro, FD filtroDapper);
}
