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
            _token = new CancellationTokenSource(5000);
        }

        [Authorize]
        [HttpPost("upload")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> UploadFile([FromBody] ArquivoRequestDto entity)
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
        [HttpPost("upload-files")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> UploadFiles([FromBody] List<ArquivoRequestDto> entities)
        {
            try
            {
                return Ok(await _service.CreateRange(entities, _token.Token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(ArquivoResponseDto), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var _file = await _service.GetByIdAsync(id, _token.Token);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteArquivo(id, _token.Token);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
