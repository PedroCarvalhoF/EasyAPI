using Domain.Dtos;
using Domain.Dtos.Pessoa.Funcionario.CTPS;
using Domain.Dtos.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Services.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Services.Pessoa.Funcionario.Funcao;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CtpsController : ControllerBase
    {
        private readonly ICtpsServices? _ctpsService;

        public CtpsController(ICtpsServices? ctpsService)
        {
            _ctpsService = ctpsService;
        }

        [HttpGet("ctps")]
        public async Task<ActionResult<ResponseDto<List<CtpsDto>>>> GetAll()
        {
            try
            {
                ResponseDto<List<CtpsDto>> respostaService = await _ctpsService.GetAll();

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<CtpsDto>>().Erro(ex));
            }
        }
        [HttpGet("ctps/{ctpsId}/ctpsId")]
        public async Task<ActionResult<ResponseDto<List<CtpsDto>>>> GetByIdCtps(Guid ctpsId)
        {
            try
            {
                var respostaService = await _ctpsService.GetByIdCtps(ctpsId);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<CtpsDto>>().Erro(ex));
            }
        }
        [HttpPost("ctps/create")]
        public async Task<ActionResult<ResponseDto<List<CtpsDto>>>> Create(CtpsDtoCreate create)
        {
            try
            {
                var respostaService = await _ctpsService.Create(create);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<CtpsDto>>().Erro(ex));
            }
        }
        [HttpPut("ctps/update")]
        public async Task<ActionResult<ResponseDto<List<CtpsDto>>>> Update(CtpsDtoUpdate update)
        {
            try
            {
                var respostaService = await _ctpsService.Update(update);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<CtpsDto>>().Erro(ex));
            }
        }
    }
}
