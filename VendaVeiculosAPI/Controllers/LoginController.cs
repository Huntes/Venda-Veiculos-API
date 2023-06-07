using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Services.Impl;

namespace VendaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var token = string.Empty;
                if(username == "samu" && password == "123456")
                {
                     token = TokenService.GenerateToken(new Usuario { Nome = username, Senha = password });
                    return Ok(token);
                }

                return BadRequest("Usuário errado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
