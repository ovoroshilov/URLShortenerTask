namespace URLShortenerTask.DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();
    }
}
