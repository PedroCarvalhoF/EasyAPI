using Api.Domain.Dtos.PessoasDtos.PessoaTipoDtos;
using Api.Domain.Interfaces.Services.Pessoas.PessoaTipo;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    class PessoasTiposController : Controller
    {
        private readonly IPessoaTipoServices _pessoaTipoServices;

        public PessoasTiposController(IPessoaTipoServices pessoaTipoServices)
        {
            _pessoaTipoServices = pessoaTipoServices;
        }


        [HttpGet("get-pessoas-tipo")]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PessoaTipoDto> result = await _pessoaTipoServices.GetAll();
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
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
