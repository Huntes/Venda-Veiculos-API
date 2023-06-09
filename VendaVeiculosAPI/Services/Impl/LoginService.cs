using AutoMapper;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Repositories.Interfaces;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository) : base()
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> Login(UsuarioRequestDto entity, CancellationToken token)
        {
            string login = entity.Nome;
            string senha = entity.Senha;

            var _usuario = await _usuarioRepository.GetByNameAsync(login, token);

            if(_usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            else if(_usuario.Senha != senha)
            {
                throw new Exception("Senha incorreta");
            }

            return TokenService.GenerateToken(_usuario);
        }
    }
}
