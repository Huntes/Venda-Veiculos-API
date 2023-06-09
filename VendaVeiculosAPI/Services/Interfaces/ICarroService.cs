using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Services.Interfaces
{
    public interface ICarroService 
    {
        Task<List<CarroResponseDto>> GetAllAsync(CancellationToken token);
        Task<CarroResponseDto> GetAsync(Guid id, CancellationToken token);
        Task<CarroResponseDto> CreateAsync(CarroRequestDto carro, CancellationToken token);
        Task<CarroResponseDto> UpdateAsync(Guid id, CarroRequestDto carro, CancellationToken token);
        Task<bool> ToggleCarro(Guid id, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
