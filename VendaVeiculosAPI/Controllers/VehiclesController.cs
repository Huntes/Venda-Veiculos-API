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
            _token = new CancellationTokenSource(500000);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<CarroResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _cars = await _service.GetAllAsync(_token.Token);
                return Ok(_cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> GetByID(Guid id)
        {
            try
            {
                return Ok(await _service.GetAsync(id, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("insert-car")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> Insert([FromBody] CarroRequestDto entity)
        {
            try
            {
                return Ok(await _service.CreateAsync(entity, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(CarroResponseDto), 200)]
        public async Task<IActionResult> Update(Guid id, [FromBody] CarroRequestDto entity)
        {
            try
            {
                return Ok(await _service.UpdateAsync(id, entity, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("change-status/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> ToggleCarro(Guid id)
        {
            try
            {
                return Ok(await _service.ToggleCarro(id, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id, _token.Token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
