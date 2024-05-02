using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    class PessoasController : Controller
    {
        private readonly IPessoaServices _pessoaServices;

        public PessoasController(IPessoaServices pessoaServices)
        {
            _pessoaServices = pessoaServices;
        }

        [HttpPost("cadastrar-pessoa")]
        public async Task<ActionResult<PessoaDto>> Create([FromBody] PessoaDtoCreate pessoaCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PessoaDto? pessoaDto = await _pessoaServices.Create(pessoaCreate);
                if (pessoaDto == null) BadRequest("Não foi possíve realizar cadastro.");
                return Ok(pessoaDto);
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
        [HttpGet("get-idpessoa/{idPessoa}")]
        public async Task<ActionResult<PessoaDto>> Get(Guid idPessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PessoaDto? dto = await _pessoaServices.Get(idPessoa);
                if (dto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(dto);
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
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IEnumerable<PessoaDto>? dtos = await _pessoaServices.GetAll();
                if (dtos == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(dtos);
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
        [HttpGet("get-all-idpessoatipo/{pessoaTipo}")]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetAll(Guid pessoaTipo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IEnumerable<PessoaDto>? dtos = await _pessoaServices.GetAll(pessoaTipo);
                if (dtos == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(dtos);
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

        [HttpPut("pessoa-update")]
        public async Task<ActionResult<PessoaDto>> Update([FromBody] PessoaDtoUpdate pessoaUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PessoaDto? pessoaDto = await _pessoaServices.Update(pessoaUpdate);
                if (pessoaDto == null) BadRequest("Não foi possíve realizar update.");
                return Ok(pessoaDto);
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
