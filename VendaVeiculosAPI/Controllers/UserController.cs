using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Models;
using VendaVeiculosAPI.Services.Impl;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly CancellationTokenSource _token;

        public UserController(IUsuarioService usuarioService)
        {
            _service = usuarioService;
            _token = new CancellationTokenSource(5000);
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(UsuarioResponseDto), 200)]
        public async Task<IActionResult> Create(UsuarioRequestDto usuarioRequestDto, CancellationToken token)
        {
            try
            {
                var _usuario = await _service.CreateAsync(usuarioRequestDto, token);
                return Ok(_usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDto), 200)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken token)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDto), 200)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UsuarioRequestDto entity, CancellationToken token)
        {
            try
            {
                return Ok(await _service.UpdateAsync(id ,entity, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
