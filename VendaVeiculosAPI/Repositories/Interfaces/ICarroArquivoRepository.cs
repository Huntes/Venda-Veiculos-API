using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface ICarroArquivoRepository : IBaseRepository<CarroArquivo>
    {
        Task<CarroArquivo> GetFirst(Guid idCarro, CancellationToken cancellationToken);
        Task<List<CarroArquivo>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteCarroArquivo(Guid id, CancellationToken token);
        Task<bool> ExistByIdCarro (Guid idCarro, CancellationToken token);
    }
}
