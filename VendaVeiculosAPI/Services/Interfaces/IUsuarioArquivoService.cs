using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface IUsuarioArquivoService
    {
        Task<List<UsuarioArquivoResponseDto>> GetArquivosByIdUsuarioAsync(Guid idUsuario, CancellationToken token);
        Task<UsuarioArquivoResponseDto> CreateAsync(UsuarioArquivoRequestDto entity, CancellationToken token);
        Task<UsuarioArquivoResponseDto> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteUsuarioArquivo(Guid id, CancellationToken token);
    }
}
