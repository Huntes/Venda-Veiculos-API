using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface ICarroArquivoRepository : IBaseRepository<CarroArquivo, CarroArquivoFilter>
    {
        Task<List<CarroArquivo>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteCarroArquivo(Guid id, CancellationToken token);
    }
}
