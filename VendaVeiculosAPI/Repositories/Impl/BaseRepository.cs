using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Repositories.Interfaces;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<T> GetAllQueryAsync()
        {
            return _context.Set<T>().AsQueryable().AsNoTracking();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

        public async Task<T> CreateAsync(T entity, CancellationToken token)
        {
            await _context.Set<T>().AddAsync(entity, token);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<List<T>> CreateRangeAsync(List<T> entities, CancellationToken token)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<List<T>> RemoveRange(List<T> entities, CancellationToken token)
        {
            _context.Set<T>().RemoveRange(entities);
            return entities;
        }
    }
}
