namespace STMComunication.Services
{
    public interface IServiceWriteOnly<T> where T : class
    {
        Task<bool> DeleteAsync(long id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
