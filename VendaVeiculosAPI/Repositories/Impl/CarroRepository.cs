using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Repositories.Impl
{
    public class CarroRepository : BaseRepository<Car, CarroFilter>, ICarroRepository
    {
        public CarroRepository(Context context) : base(context){}

        public async Task<List<Car>> GetAllAsync(CancellationToken token)
        {
            return await _context.Carros.AsNoTracking().ToListAsync(token);
        }

        public async Task<Car> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _context.Carros
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, token);
        }

        public async Task<Car> GetByModelo(string modelo, CancellationToken token)
        {
            return await _context.Carros
                .FirstOrDefaultAsync(c => c.Modelo.ToUpper() == modelo.ToUpper());
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
