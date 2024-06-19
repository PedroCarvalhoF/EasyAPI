namespace Easy.Domain.Intefaces.Repository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
