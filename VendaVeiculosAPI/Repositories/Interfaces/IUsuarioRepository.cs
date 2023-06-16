using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetByNameAsync(string name, CancellationToken token);
        Task<Usuario> GetByEmailAsync(string email, CancellationToken token);
        Task<Usuario> GetByIdAsync(Guid id, CancellationToken token);
        Task<Usuario> ToggleAsync(Guid id, CancellationToken token);
        Task<bool> ExistUsuario(string name, CancellationToken token);
        Task DeleteUserAsync(Guid id, CancellationToken token);
    }
}
