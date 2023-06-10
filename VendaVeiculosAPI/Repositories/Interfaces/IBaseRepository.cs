namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> 
        where T : class
    {
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllQueryAsync();
        Task<T> CreateAsync(T entity, CancellationToken token);
        T Update(T entity);
        Task SaveChangesAsync(CancellationToken token);
    }
}
