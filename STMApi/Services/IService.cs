namespace STMApi.Services
{
    public interface IService<T> where T : class
    {
        Task DeleteAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
