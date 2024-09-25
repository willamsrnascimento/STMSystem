namespace STMData.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task DeleteAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
