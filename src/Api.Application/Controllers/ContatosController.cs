using Domain.Dtos;
using Domain.Dtos.Pessoas.Contato;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Interfaces.Services.Pessoas.Contato;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoServices? _contatoServices;

        public ContatosController(IContatoServices? contatoServices)
        {
            _contatoServices = contatoServices;
        }

        [HttpGet("contatos")]
        public async Task<ActionResult<ResponseDto<List<ContatoDto>>>> GetAllContatos()
        {
            try
            {
                ResponseDto<List<ContatoDto>> respostaService = await _contatoServices.GetAllContatos();

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

        [HttpGet("contatos/{idContato}/idContato")]
        public async Task<ActionResult<ResponseDto<List<ContatoDto>>>> GetByContatoId(Guid idContato)
        {
            try
            {
                var respostaService = await _contatoServices.GetByContatoId(idContato);

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

        [HttpPost("contatos/create")]
        public async Task<ActionResult<ResponseDto<List<ContatoDto>>>> CreateContato(ContatoDtoCreate create)
        {
            try
            {
                var respostaService = await _contatoServices.CreateContato(create);

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

        [HttpPut("contatos/update")]
        public async Task<ActionResult<ResponseDto<List<ContatoDto>>>> UpdateContato(ContatoDtoUpdate update)
        {
            try
            {
                var respostaService = await _contatoServices.UpdateContato(update);

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

        [HttpDelete("contatos/{idContato}/delete")]
        public async Task<ActionResult<ResponseDto<List<ContatoDto>>>> DeleteContato(Guid idContato)
        {
            try
            {
                var respostaService = await _contatoServices.DeleteContato(idContato);

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