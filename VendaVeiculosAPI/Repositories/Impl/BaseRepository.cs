using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Repositories.Interfaces;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class BaseRepository<T, Filter> : IBaseRepository<T, Filter>
        where T : class
        where Filter : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
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

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
