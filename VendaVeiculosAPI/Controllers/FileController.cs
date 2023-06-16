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
    public class FileController : ControllerBase
    {
        readonly IArquivoService _service;
        readonly CancellationTokenSource _token;

        public FileController(IArquivoService arquivoService)
        {
            _service = arquivoService;
            _token = new CancellationTokenSource(50000);
        }

        [Authorize]
        [HttpPost("upload")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> UploadFile([FromBody] ArquivoRequestDto entity, CancellationToken token)
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
        [HttpPost("upload-files")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> UploadFiles([FromBody] List<ArquivoRequestDto> entities, CancellationToken token)
        {
            try
            {
                return Ok(await _service.CreateRange(entities, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("upload-files-car")]
        [ProducesResponseType(typeof(List<ArquivoResponseDto>), 200)]
        public async Task<IActionResult> UploadFilesCar([FromBody] ArquivoRequestInsertDto entity, CancellationToken token)
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

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            try
            {
                var _file = await _service.GetByIdAsync(id, token);
                return Ok(_file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(String), 200)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            try
            {
                await _service.DeleteArquivo(id, token);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
