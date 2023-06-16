using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Services.Impl;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly CancellationTokenSource _token;
        public LoginController(ILoginService loginService)
        {
            _service = loginService;
            _token = new CancellationTokenSource(100000);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto entity, CancellationToken token)
        {
            try
            {
                return Ok(await _service.Login(entity, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
