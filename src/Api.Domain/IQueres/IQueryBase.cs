namespace Domain.IQueres
{
    public  interface IQueryBase<T> where T : class
    {
        IQueryable<T> FullInclude(IQueryable<T> query);
    }
}
