using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class PrecosProdutoControllerController : Controller
    {
        private readonly IPrecoProdutoService _service;
        public PrecosProdutoControllerController(IPrecoProdutoService service)
        {
            _service = service;
        }

        [HttpGet("precos-produtos")]
        public async Task<ActionResult<IEnumerable<PrecoProdutoDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                    return BadRequest("Não encontrado");

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("precos-produtos/{id}/id")]
        public async Task<ActionResult<PrecoProdutoDto>> Get(Guid id)
        {
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                    return BadRequest("Não encontrado");

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("precos-produtos/{id}/produto-id")]
        public async Task<ActionResult<IEnumerable<PrecoProdutoDto>>> GetProdutoId(Guid id)
        {
            try
            {
                var result = await _service.GetProdutoId(id);
                if (result == null)
                    return BadRequest("Não encontrado");

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("precos-produtos/{id}/categoria-preco-id")]
        public async Task<ActionResult<IEnumerable<PrecoProdutoDto>>> GetCategoriaPrecoId(Guid id)
        {
            try
            {
                var result = await _service.GetCategoriaPrecoId(id);
                if (result == null)
                    return BadRequest("Não encontrado");

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost("CreateUpdate/precos-produtos")]
        public async Task<ActionResult<PrecoProdutoDto>> CreateUpdate(PrecoProdutoDtoCreate create)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.CreateUpdate(create);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }


    }
}