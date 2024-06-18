namespace Easy.Domain.Intefaces.Repository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> InsertGenericAsync(T item);
        Task<int> InsertArrayGenericAsync(IEnumerable<T> entity);
        Task<T> UpdateGenericAsync(T item);
        Task<bool> DeleteGenericAsync(Guid id);
        Task<int> DeleteGenericAsync(IEnumerable<T> itens);
        Task<T> SelectGenericAsync(Guid id);
        Task<IEnumerable<T>> SelectGenericAsync();
    }
}
