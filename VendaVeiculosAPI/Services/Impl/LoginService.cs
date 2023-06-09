using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<string> Login(LoginRequestDto entity, CancellationToken token)
        {
            var _usuario = await _usuarioRepository.GetByNameAsync(entity.Login, token) 
                ?? throw new Exception("Usuário não encontrado");

            if (!Utils.Utils.VerifyPassword(entity.Password, _usuario.Senha))
            {
                throw new Exception("Senha incorreta");
            }

            return TokenService.GenerateToken(_usuario);
        }
    }
}
