using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface ICarroArquivoService
    {
        Task<List<CarroArquivoResponseDto>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token);
        Task<CarroArquivoResponseDto> CreateAsync(CarroArquivoRequestDto entity, CancellationToken token);
        Task<List<CarroArquivoResponseDto>> CreateRangeAsync(List<CarroArquivoRequestDto> entities, CancellationToken token);
        Task<CarroArquivoResponseDto> GetFirst(Guid idCarro, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteCarroArquivo(Guid id, CancellationToken token);
        Task DeleteCarroArquivoRangeAsync(Guid idCarro, CancellationToken token);
        Task<bool> ExistCarroArquivo(Guid idCarro, CancellationToken token);
    }
}
