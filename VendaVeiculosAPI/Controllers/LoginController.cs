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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly CancellationTokenSource _token;
        public LoginController(ILoginService loginService)
        {
            _service = loginService;
            _token = new CancellationTokenSource(5000);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto entity)
        {
            try
            {
                return Ok(await _service.Login(entity, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
