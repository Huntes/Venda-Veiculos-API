using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Impl;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class ArquivoService : BaseService<Arquivo, ArquivoRequestDto, ArquivoResponseDto>, IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        public ArquivoService(IArquivoRepository repository, IMapper mapper) : base(mapper)
        {
            _arquivoRepository = repository;
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
            return ConvertModelToResponseDto(_listArquivo);
        }

        public async Task<ArquivoResponseDto> GetByIdAsync(Guid id, CancellationToken token)
        {
            Arquivo _arquivo = await _arquivoRepository.GetArquivoById(id, token);
            return ConvertModelToResponseDto(_arquivo);
        }

        public async Task<ArquivoResponseDto> UpdateAsync(ArquivoRequestDto entity, CancellationToken token)
        {
            Arquivo _arquivo = await _arquivoRepository.GetArquivoById(entity.Id, token)
                ?? throw new NullReferenceException("Arquivo não encontrado");

            _arquivo = ConverRequestDtoToModel(entity);
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
