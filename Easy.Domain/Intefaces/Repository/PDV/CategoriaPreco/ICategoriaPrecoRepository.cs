using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;

namespace Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;

public interface ICategoriaPrecoRepository<T, F> where T : CategoriaPrecoEntity where F : FiltroBase
{
    Task<CategoriaPrecoEntity> InsertAsync(T item, F filtro);
    CategoriaPrecoEntity UpdateAsync(T item, F filtro);
    Task<IEnumerable<CategoriaPrecoEntity>> GetAllAsync(F filtro);
    Task<CategoriaPrecoEntity> GetByIdAsync(Guid id, F filtro);
    Task<CategoriaPrecoEntity> GetByCodigoAsync(int codigo, F filtro);
    Task<CategoriaPrecoEntity> GetByDescricaoCategoriaAsync(string descricao, F filtro);

}