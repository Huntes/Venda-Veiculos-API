using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaVeiculosAPI.Dto.Request;
using VendaVeiculosAPI.Dto.Response;
using VendaVeiculosAPI.Services.Interfaces;

namespace VendaVeiculosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(String), 400)]
    [ProducesResponseType(typeof(String), 404)]
    public class VehiclesController : ControllerBase
    {
        private readonly ICarroService _service;
        private readonly CancellationTokenSource _token;

        public VehiclesController(ICarroService carroService)
        {
            _service = carroService;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<CarroResponseDto>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            try
            {
                var _cars = await _service.GetAllAsync(token);
                return Ok(_cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> GetByID(Guid id, CancellationToken token)
        {
            try
            {
                return Ok(await _service.GetAsync(id, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("insert-car")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> Insert([FromBody] CarroRequestDto entity, CancellationToken token)
        {
            try
            {
                return Ok(await _service.CreateAsync(entity, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> Update(Guid id, [FromBody] CarroRequestDto entity, CancellationToken token)
        {
            try
            {
                return Ok(await _service.UpdateAsync(id, entity, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("change-status/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> ToggleCarro(Guid id, CancellationToken token)
        {
            try
            {
                return Ok(await _service.ToggleCarro(id, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            try
            {
                await _service.DeleteAsync(id, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
