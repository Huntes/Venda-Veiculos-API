using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface ICarroRepository : IBaseRepository<Car>
    {
        Task<Car> GetByIdAsync(Guid id, CancellationToken token);
        Task<Car> GetByModelo(string modelo, CancellationToken token);
        Task<bool> ToggleStatus(Guid id, CancellationToken token);
        Task DeleteCar(Guid id, CancellationToken token);
    }
}
