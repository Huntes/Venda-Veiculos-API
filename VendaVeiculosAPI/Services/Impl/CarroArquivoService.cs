using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class CarroArquivoService : BaseService<CarroArquivo, CarroArquivoRequestDto, CarroArquivoResponseDto>, ICarroArquivoService
    {
        private readonly ICarroArquivoRepository _carroArquivoRepository;
        private readonly ICarroRepository _carroRepository;
        private readonly IArquivoRepository _arquivoRepository; 

        public CarroArquivoService(ICarroArquivoRepository repository, ICarroRepository carroRepository, IArquivoRepository arquivoRepository, IMapper mapper) : base(mapper)
        {
            _carroArquivoRepository = repository;
            _carroRepository = carroRepository;
            _arquivoRepository = arquivoRepository;
        }

        public async Task<List<CarroArquivoResponseDto>> GetArquivosByIdCarroAsync(Guid idCarro, CancellationToken token)
        {
            var _listCarroArquivos = await _carroArquivoRepository.GetArquivosByIdCarroAsync(idCarro, token);
            return ConvertModelToResponseDto(_listCarroArquivos);
        }

        public async Task<CarroArquivoResponseDto> GetFirst(Guid idCarro, CancellationToken token)
        {
            var _carroArquivo = await _carroArquivoRepository.GetFirst(idCarro, token);
            return ConvertModelToResponseDto(_carroArquivo);
        }

        public async Task<List<CarroArquivoResponseDto>> CreateRangeAsync(List<CarroArquivoRequestDto> entities, CancellationToken token)
        {
            List<CarroArquivo> _carroArquivos = ConvertRequestDtoToModel(entities).ToList();
            var _carroArquivosModel = await _carroArquivoRepository.CreateRangeAsync(_carroArquivos, token);
            await _carroArquivoRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_carroArquivosModel);
        }

        public async Task<CarroArquivoResponseDto> CreateAsync(CarroArquivoRequestDto entity, CancellationToken token)
        {
            var Carro = await _carroRepository.GetByIdAsync(entity.IdCarro, token);
            if (Carro == null) { throw new NullReferenceException("O carro não foi encotnrado"); }

            var Arquivo = await _arquivoRepository.GetArquivoById(entity.IdArquivo, token);
            if (Arquivo == null) { throw new NullReferenceException("O carro não foi encotnrado"); }

            var CarroArquivo = ConverRequestDtoToModel(entity);
            
            CarroArquivo.Arquivo = Arquivo;
            CarroArquivo.Carro = Carro;

            await _carroArquivoRepository.CreateAsync(CarroArquivo, token);
            await _carroArquivoRepository.SaveChangesAsync(token);

            return ConvertModelToResponseDto(CarroArquivo);
        }

        public async Task<bool> ExistCarroArquivo(Guid idCarro, CancellationToken token)
        {
            return await _carroArquivoRepository.ExistByIdCarro(idCarro, token);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            return await _carroArquivoRepository.ToggleAsync(id, token);
        }

        public async Task DeleteCarroArquivo(Guid id, CancellationToken token)
        {
            await _carroArquivoRepository.DeleteCarroArquivo(id, token);
            await _carroArquivoRepository.SaveChangesAsync(token);
        }

        public async Task DeleteCarroArquivoRangeAsync(Guid idCarro, CancellationToken token)
        {
            await _carroArquivoRepository.DeleteAllCarroArquivo(idCarro, token);
            await _carroArquivoRepository.SaveChangesAsync(token);
        }
    }
}
