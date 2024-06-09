using Domain.Dtos;
using Domain.Dtos.PontoVendaUser;
using Domain.Interfaces.Services.PontoVendaUser;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PontoVendaUsuarioController : ControllerBase
    {
        private readonly IUsuarioPontoVendaService _service;

        public PontoVendaUsuarioController(IUsuarioPontoVendaService service)
        {
            _service = service;
        }

        [HttpGet("users-ponto-venda")]
        public async Task<ActionResult<ResponseDto<List<UsuarioPontoVendaDto>>>> GetAll()
        {
            try
            {
                var respostaService = await _service.GetAll();

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<UsuarioPontoVendaDto>>().Erro(ex));
            }
        }
        [HttpGet("users-ponto-venda/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<UsuarioPontoVendaDto>>>> Get(Guid id)
        {
            try
            {
                var respostaService = await _service.Get(id);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<UsuarioPontoVendaDto>>().Erro(ex));
            }
        }
        [HttpGet("users-ponto-venda/{userId}/user-id")]
        public async Task<ActionResult<ResponseDto<List<UsuarioPontoVendaDto>>>> GetByIdUser(Guid userId)
        {
            try
            {
                var respostaService = await _service.GetByIdUser(userId);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<UsuarioPontoVendaDto>>().Erro(ex));
            }
        }
        [HttpPost("users-ponto-venda/create")]
        public async Task<ActionResult<ResponseDto<List<UsuarioPontoVendaDto>>>> Create([FromBody] UsuarioPontoVendaDtoCreate userCreate)
        {
            try
            {
                var respostaService = await _service.Create(userCreate);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<UsuarioPontoVendaDto>>().Erro(ex));
            }
        }

    }
}
