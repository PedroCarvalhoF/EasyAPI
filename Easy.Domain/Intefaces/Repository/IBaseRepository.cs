using Easy.Domain.Entities;

namespace Easy.Domain.Intefaces.Repository
{
    public interface IBaseRepository<T, F> where T : BaseEntity where F : FiltroBase
    {
        Task<T> InsertAsync(T item);
        Task<T> Update(T item);
        Task<int> UpdateRange(IEnumerable<T> itens_pedido);
        Task<IEnumerable<T>> SelectAsync(FiltroBase filtro, bool includeAll = false);
        Task<T> SelectAsync(Guid id, FiltroBase filtro, bool includeAll = false);
        
    }
}