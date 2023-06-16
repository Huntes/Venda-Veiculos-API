using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Impl;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;
using VendaVeiculosAPI.Utils;

namespace VendaVeiculosAPI.Services.Impl
{
    public class ArquivoService : BaseService<Arquivo, ArquivoRequestDto, ArquivoResponseDto>, IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly ICarroArquivoRepository _carroArquivoRepository;
        public ArquivoService(IArquivoRepository repository, ICarroArquivoRepository carroArquivoRepository, IMapper mapper) : base(mapper)
        {
            _arquivoRepository = repository;
            _carroArquivoRepository = carroArquivoRepository;
        }

        public async Task<List<ArquivoResponseDto>> CreateRange(List<ArquivoRequestDto> entities, CancellationToken token)
        {
            List<Arquivo> _arquivos = ConvertRequestDtoToModel(entities).ToList();
            var _arquivosModel = await _arquivoRepository.CreateRangeAsync(_arquivos, token);
            await _arquivoRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_arquivosModel);
        }

        public async Task<List<ArquivoResponseDto>> CreateAsync(ArquivoRequestInsertDto entity, CancellationToken token)
        {
            var _listCarroArquivo = new List<CarroArquivo>();
            var _listArquivos = ConvertRequestDtoToModel(entity.Arquivos ?? new List<ArquivoRequestDto>()).ToList(); 
            var _carroModel = new Car { Id = entity.IdCarro };

            _listArquivos.ForEach(arquivo =>
            {
                arquivo.Id = Guid.NewGuid();
            });

            var _arquivosModel = await _arquivoRepository.CreateRangeAsync(_listArquivos, token);

            _arquivosModel.ForEach(arquivo => {
                _listCarroArquivo.Add(new CarroArquivo 
                {
                    CarroId = entity.IdCarro,
                    ArquivoId = arquivo.Id, 
                    DataCriacao = DateTimeHelpers.GetDateTimeNow() 
                });
            });

            await _carroArquivoRepository.CreateRangeAsync(_listCarroArquivo, token);
            await _carroArquivoRepository.SaveChangesAsync(token);

            return ConvertModelToResponseDto(_arquivosModel);
        }

        public async Task<ArquivoResponseDto> CreateAsync(ArquivoRequestDto entity, CancellationToken token)
        {
            Arquivo _arquivo = ConverRequestDtoToModel(entity);
            _arquivo = await _arquivoRepository.CreateAsync(_arquivo, token);
            await _arquivoRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_arquivo);
        }

        public async Task<List<ArquivoResponseDto>> GetAllArquivos(CancellationToken token)
        {
            var _listArquivo = await _arquivoRepository.GetAllAsync();
            _listArquivo = _listArquivo.Where(c => c.DataDelete == null).ToList();
            return ConvertModelToResponseDto(_listArquivo);
        }

        public async Task<ArquivoResponseDto> GetByIdAsync(Guid id, CancellationToken token)
        {
            Arquivo _arquivo = await _arquivoRepository.GetArquivoById(id, token);
            return ConvertModelToResponseDto(_arquivo);
        }

        public async Task<ArquivoResponseDto> UpdateAsync(Guid id, ArquivoRequestDto entity, CancellationToken token)
        {
            _ = await _arquivoRepository.GetArquivoById(id, token)
                ?? throw new NullReferenceException("Arquivo não encontrado");

            Arquivo _arquivo = ConverRequestDtoToModel(entity);
            _arquivo = _arquivoRepository.Update(_arquivo);
            await _arquivoRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_arquivo);
        }

        public async Task<bool> ToggleAsync(Guid id, CancellationToken token)
        {
            var _status = await _arquivoRepository.ToggleAsync(id, token);
            await _arquivoRepository.SaveChangesAsync(token);
            return _status;
        }

        public async Task DeleteArquivo(Guid id, CancellationToken token)
        {
            await _arquivoRepository.ToggleAsync(id, token);
            await _arquivoRepository.SaveChangesAsync(token);
        }

    }
}
