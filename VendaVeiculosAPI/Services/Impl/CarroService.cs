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
            var _listCarros = await _carroRepository.GetAllAsync();
            var _listCarrosResponseDto = ConvertModelToResponseDto(_listCarros ?? new List<Car>());

            foreach(var carro in _listCarrosResponseDto)
            {
                bool _existCarroFotos = await _carroArquivoService.ExistCarroArquivo(carro.Id, token);
                if (_existCarroFotos)
                {
                    carro.Fotos = new();
                    var _foto = await _carroArquivoService.GetFirst(carro.Id, token);
                    if(_foto != null)
                    {
                        var _firstFotoCarro = await _arquivoService.GetByIdAsync(_foto.IdArquivo, token);
                        carro.Fotos.Add(_firstFotoCarro);
                    }
                }
            }

            return _listCarrosResponseDto;
        }

        public async Task<CarroResponseDto> GetAsync(Guid id, CancellationToken token)
        {
            var _carro = await _carroRepository.GetByIdAsync(id, token);
            var _carroResponseDto = ConvertModelToResponseDto(_carro);

            bool _existCarroFotos = await _carroArquivoService.ExistCarroArquivo(id, token);
            if (_existCarroFotos)
            {
                _carroResponseDto.Fotos = new();
                var _fotos = await _carroArquivoService.GetArquivosByIdCarroAsync(id, token);
                foreach (var foto in _fotos)
                {
                    var _foto = await _arquivoService.GetByIdAsync(foto.IdArquivo, token);
                    _carroResponseDto.Fotos.Add(_foto);
                }
            }

            return _carroResponseDto;
        }

        public async Task<CarroResponseDto> CreateAsync(CarroRequestDto carro, CancellationToken token)
        {
            List<ArquivoResponseDto> fotos = new();
            Car _carro = ConverRequestDtoToModel(carro);
            _carro = await _carroRepository.CreateAsync(_carro, token);
            await _carroRepository.SaveChangesAsync(token);

            //if (carro.Fotos != null)
            //{
            //    foreach (var arquivo in carro.Fotos)
            //    {
            //        var _foto = await _arquivoService.CreateAsync(arquivo, token);
            //        fotos.Add(_foto);
            //    }

            //    foreach (var foto in fotos)
            //    {
            //        await _carroArquivoService.CreateAsync(new CarroArquivoRequestDto { IdCarro = _carro.Id, IdArquivo = foto.Id }, token);
            //    }
            //}

            var _carroResponseDto = ConvertModelToResponseDto(_carro);
            //_carroResponseDto.Fotos = fotos;
            return _carroResponseDto;
        }

        public async Task<CarroResponseDto> UpdateAsync(Guid id, CarroRequestDto carro, CancellationToken token)
        {
            _ = await _carroRepository.GetByIdAsync(id, token)
                ?? throw new NullReferenceException("Carro não encontrado");

            Car _carro = ConverRequestDtoToModel(carro);
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
