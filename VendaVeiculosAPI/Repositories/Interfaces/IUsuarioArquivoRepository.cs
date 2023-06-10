using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IUsuarioArquivoRepository : IBaseRepository<UsuarioArquivo>
    {
        Task<List<UsuarioArquivo>> GetArquivosByIdUsuarioAsync(Guid idUsuario, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteUsuarioArquivo(Guid id, CancellationToken token);
    }
}
