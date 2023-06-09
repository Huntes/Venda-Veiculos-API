namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface IBaseService<T, Filter> 
        where T : class
        where Filter : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, CancellationToken token);
        Task<T> CreateAsync(T entity, CancellationToken token);
        Task<T> UpdateAsync(T entity, CancellationToken token);
        Task<bool> DeleteAsync(int id, CancellationToken token);
    }
}
