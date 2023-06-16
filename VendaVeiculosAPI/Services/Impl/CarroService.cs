using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IArquivoService _arquivoService;
        private readonly ICarroArquivoService _carroArquivoService;

        public CarroService(ICarroRepository repository, IArquivoService arquivoService, ICarroArquivoService carroArquivoService, IMapper mapper) : base(mapper)
        {
            _carroRepository = repository;
            _arquivoService = arquivoService;
            _carroArquivoService = carroArquivoService;
        }

        public async Task<List<CarroResponseDto>> GetAllAsync(CancellationToken token)
        {
            var _listCarros = await _carroRepository.GetAllQueryAsync()
                .Include(c => c.Arquivos)
                .ThenInclude(c => c.Arquivo)
                .Where(c => c.DataDelete == null && c.Ativo)
                .ToListAsync(token);

            var _listCarrosResponseDto = ConvertModelToResponseDto(_listCarros ?? new List<Car>());

            return _listCarrosResponseDto;
        }

        public async Task<CarroResponseDto> GetAsync(Guid id, CancellationToken token)
        {
            var _carro = await _carroRepository.GetAllQueryAsync()
                .Include(c => c.Arquivos)
                .ThenInclude(c => c.Arquivo)
                .FirstOrDefaultAsync(c => c.Id == id, token);

            var _carroResponseDto = ConvertModelToResponseDto(_carro ?? new Car());

            return _carroResponseDto;
        }

        public async Task<CarroResponseDto> CreateAsync(CarroRequestDto carro, CancellationToken token)
        {
            List<ArquivoResponseDto> fotos = new();
            Car _carro = ConverRequestDtoToModel(carro);
            _carro = await _carroRepository.CreateAsync(_carro, token);
            await _carroRepository.SaveChangesAsync(token);

            var _carroResponseDto = ConvertModelToResponseDto(_carro);
            return _carroResponseDto;
        }

        public async Task<CarroResponseDto> UpdateAsync(Guid id, CarroRequestDto carro, CancellationToken token)
        {
            _ = await _carroRepository.GetByIdAsync(id, token)
                ?? throw new NullReferenceException("Carro não encontrado");

            Car _carro = ConverRequestDtoToModel(carro);
            _carro.Id = id;
            _carro = _carroRepository.Update(_carro);
            await _carroRepository.SaveChangesAsync(token);

            await _carroArquivoService.DeleteCarroArquivoRangeAsync(_carro.Id, token);

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
