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
    public class FileVehiclesController : ControllerBase
    {
        private readonly ICarroArquivoService _service;
        private readonly CancellationTokenSource _token;
        
        public FileVehiclesController(ICarroArquivoService carroArquivoService)
        {
            _service = carroArquivoService;
            _token = new CancellationTokenSource(5000);
        }

        [Authorize]
        [HttpPost("insert")]
        [ProducesResponseType(typeof(CarroArquivoResponseDto), 200)]
        public async Task<IActionResult> Insert([FromBody] CarroArquivoRequestDto entity)
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
        [HttpPost("insert-files")]
        [ProducesResponseType(typeof(List<CarroArquivoResponseDto>), 200)]
        public async Task<IActionResult> InsertFiles([FromBody] List<CarroArquivoRequestDto> entities)
        {
            try
            {
                return Ok(await _service.CreateRangeAsync(entities, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
