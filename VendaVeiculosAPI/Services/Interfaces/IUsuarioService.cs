using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioResponseDto>> GetAllAsync(CancellationToken token);
        Task<UsuarioResponseDto> GetByIdAsync(Guid id, CancellationToken token);
        Task<UsuarioResponseDto?> GetByNameAsync(string name, CancellationToken token);
        Task<UsuarioResponseDto> CreateAsync(UsuarioRequestDto entity, CancellationToken token);
        Task<UsuarioResponseDto> UpdateAsync(Guid id, UsuarioRequestDto entity, CancellationToken token);
        Task<UsuarioResponseDto> ToogleUsuario (Guid id, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
