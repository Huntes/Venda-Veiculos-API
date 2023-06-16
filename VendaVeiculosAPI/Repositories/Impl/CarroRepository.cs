using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class CarroRepository : BaseRepository<Car>, ICarroRepository
    {
        public CarroRepository(Context context) : base(context){}

        public async Task<List<Car>> GetAllAsync(CancellationToken token)
        {
            var _list = await _context.Carros.AsNoTracking().ToListAsync(token);
            return _list.Where(c => c.DataDelete == null && c.Ativo).ToList();
        }

        public async Task<Car> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _context.Carros
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, token) ?? new Car();
        }

        public async Task<Car> GetByModelo(string modelo, CancellationToken token)
        {
            return await _context.Carros.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Modelo.ToUpper() == modelo.ToUpper() && c.DataDelete == null && c.Ativo) ?? new Car();
        }

        public async Task<bool> ToggleStatus(Guid id, CancellationToken token)
        {
            Car _car = await _context.Carros.FirstOrDefaultAsync(c => c.Id == id, token) 
                ?? throw new NullReferenceException("Carro não encontrado");

            _car.Ativo = !_car.Ativo;
            _car.DataAlteracao = DateTimeHelpers.GetDateTimeNow();
            _context.Carros.Update(_car);
            return _car.Ativo;
        }

        public async Task DeleteCar(Guid id, CancellationToken token)
        {
            Car _car = await GetByIdAsync(id, token);
            _car.Ativo = false;
            _car.DataDelete = DateTimeHelpers.GetDateTimeNow();
            _context.Carros.Update(_car);
        }
    }
}
