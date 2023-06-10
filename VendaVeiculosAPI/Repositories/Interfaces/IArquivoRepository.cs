using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IArquivoRepository : IBaseRepository<Arquivo>
    {
        Task<Arquivo> GetArquivoById(Guid id, CancellationToken token);
        Task<Arquivo> GetByName(string name, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteArquivo(Guid id, CancellationToken token);
    }
}
