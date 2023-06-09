namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T, Filter> 
        where T : class
        where Filter : class
    {
        Task SaveChangesAsync(CancellationToken token);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity, CancellationToken token);
        T Update(T entity);
    }
}
