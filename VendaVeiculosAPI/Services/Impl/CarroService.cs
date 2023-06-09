using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Impl;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class CarroService : BaseService<Car, CarroRequestDto, CarroResponseDto>, ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        public CarroService(ICarroRepository repository, IMapper mapper) : base(mapper)
        {
            _carroRepository = repository;
        }

        public async Task<List<CarroResponseDto>> GetAllAsync(CancellationToken token)
        {
            var _list = await _carroRepository.GetAllAsync() 
                ?? new List<Car>();

            return ConvertModelToResponseDto(_list);
        }

        public async Task<CarroResponseDto> GetAsync(Guid id, CancellationToken token)
        {
            var _carro = await _carroRepository.GetByIdAsync(id, token);
            return ConvertModelToResponseDto(_carro);
        }

        public async Task<CarroResponseDto> CreateAsync(CarroRequestDto carro, CancellationToken token)
        {
            Car _carro = ConverRequestDtoToModel(carro);
            _carro = await _carroRepository.CreateAsync(_carro, token);
            await _carroRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_carro);
        }

        public async Task<CarroResponseDto> UpdateAsync(Guid id, CarroRequestDto carro, CancellationToken token)
        {
            Car _carro = await _carroRepository.GetByIdAsync(id, token);
            if(_carro == null)
                throw new NullReferenceException("Carro não encontrado");

            _carro = ConverRequestDtoToModel(carro);
            _carro = _carroRepository.Update(_carro);
            await _carroRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_carro);
        }

        public async Task<bool> ToggleCarro(Guid id, CancellationToken token)
        {
            var _status = await _carroRepository.ToggleStatus(id, token);
            await _carroRepository.SaveChangesAsync(token);
            return _status;
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            await _carroRepository.DeleteCar(id, token);
            await _carroRepository.SaveChangesAsync(token);
        }
    }
}
