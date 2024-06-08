using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Enuns.Pessoas;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DadosBancariosController : ControllerBase
    {
        private readonly IDadosBancariosServices _service;

        public DadosBancariosController(IDadosBancariosServices service)
        {
            _service = service;
        }

        [HttpGet("dados-bancarios/{include}")]
        public async Task<ActionResult<ResponseDto<List<DadosBancariosDto>>>> GetAll(bool include = false)
        {
            try
            {
                var respostaService = await _service.GetAll(include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
        [HttpGet("dados-bancarios/{agencia}/{include}/by-agencia")]
        public async Task<ActionResult<ResponseDto<List<DadosBancariosDto>>>> GetByAgencia(string agencia, bool include = false)
        {
            try
            {
                var respostaService = await _service.GetByAgencia(agencia, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
        [HttpGet("dados-bancarios/{ContaComDigito}/{include}/by-numero-conta")]
        public async Task<ActionResult<ResponseDto<List<DadosBancariosDto>>>> GetByContaCorrente(string contaComDigito, bool include = false)
        {
            try
            {
                var respostaService = await _service.GetByContaCorrente(contaComDigito, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
        [HttpPost("dados-bancarios-create")]
        public async Task<ActionResult<ResponseDto<List<DadosBancariosDto>>>> Create([FromBody] DadosBancariosDtoCreate create)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var respostaService = await _service.Create(create);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
        [HttpPut("dados-bancarios-update")]
        public async Task<ActionResult<ResponseDto<List<DadosBancariosDto>>>> Update(DadosBancariosDtoUpdate update)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var respostaService = await _service.Update(update);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
    }
}
