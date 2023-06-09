using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface ICarroArquivoService
    {
        Task<List<CarroArquivoResponseDto>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token);
        Task<CarroArquivoResponseDto> CreateAsync(CarroArquivoRequestDto entity, CancellationToken token);
        Task<bool> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteCarroArquivo(Guid id, CancellationToken token);
    }
}
