namespace STMComunication.Services.Interfaces
{
    public interface IServiceReadOnly<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
