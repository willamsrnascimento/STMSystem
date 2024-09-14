namespace STMComunication.Services
{
    public interface IServiceReadOnly<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
