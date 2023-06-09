using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Impl;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class UsuarioService : BaseService<Usuario, UsuarioRequestDto, UsuarioResponseDto>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) : base(mapper)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioResponseDto> CreateAsync(UsuarioRequestDto entity, CancellationToken token)
        {
            Usuario usuario = ConverRequestDtoToModel(entity);
            usuario = await _usuarioRepository.CreateAsync(usuario, token);
            await _usuarioRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(usuario);
        }

        public async Task<List<UsuarioResponseDto>> GetAllAsync(CancellationToken token)
        {
            var _list = await _usuarioRepository.GetAllAsync()
                ?? new List<Usuario>();

            return ConvertModelToResponseDto(_list);
        }

        public async Task<UsuarioResponseDto> GetByIdAsync(Guid id, CancellationToken token)
        {
            var _usuario = await _usuarioRepository.GetByIdAsync(id, token);
            return ConvertModelToResponseDto(_usuario);
        }

        public async Task<UsuarioResponseDto?> GetByNameAsync(string name, CancellationToken token)
        {
            var _usuario = await _usuarioRepository.GetByNameAsync(name, token);
            return ConvertModelToResponseDto(_usuario);
        }

        public async Task<UsuarioResponseDto> UpdateAsync(Guid id, UsuarioRequestDto entity, CancellationToken token)
        {
            entity.Id = id;
            Usuario _usuario = ConverRequestDtoToModel(entity);
            _usuario = _usuarioRepository.Update(_usuario);
            await _usuarioRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_usuario);
        }

        public async Task<UsuarioResponseDto> ToogleUsuario(Guid id, CancellationToken token)
        {
            var _usuario = await _usuarioRepository.ToggleAsync(id, token);
            await _usuarioRepository.SaveChangesAsync(token);
            return ConvertModelToResponseDto(_usuario);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            await _usuarioRepository.DeleteUserAsync(id, token);
            await _usuarioRepository.SaveChangesAsync(token);
        }
    }
}
