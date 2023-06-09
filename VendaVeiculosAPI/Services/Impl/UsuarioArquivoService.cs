using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class UsuarioArquivoService : BaseService<UsuarioArquivo, UsuarioArquivoRequestDto, UsuarioArquivoResponseDto>, IUsuarioArquivoService
    {
        private readonly IUsuarioArquivoRepository _usuarioArquivoRepository;
        public UsuarioArquivoService(IUsuarioArquivoRepository repository, IMapper mapper) : base(mapper)
        {
            _usuarioArquivoRepository = repository;
        }

        public Task<List<UsuarioArquivoResponseDto>> GetArquivosByIdUsuarioAsync(Guid idUsuario, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioArquivoResponseDto> ToggleAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuarioArquivo(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioArquivoResponseDto> CreateAsync(UsuarioArquivoRequestDto entity, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
