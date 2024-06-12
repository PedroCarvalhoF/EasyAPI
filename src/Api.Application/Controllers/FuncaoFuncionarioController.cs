using Domain.Dtos;
using Domain.Dtos.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Services.Pessoa.Funcionario.Funcao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FuncaoFuncionarioController : ControllerBase
    {
        private readonly IFuncaoFuncionarioServices? _funcaoFuncionarioServices;

        public FuncaoFuncionarioController(IFuncaoFuncionarioServices? funcaoFuncionarioServices)
        {
            _funcaoFuncionarioServices = funcaoFuncionarioServices;
        }

        [HttpGet("funcao-funcionario")]
        public async Task<ActionResult<ResponseDto<List<FuncaoFuncionarioDto>>>> GetAll()
        {
            try
            {
                ResponseDto<List<FuncaoFuncionarioDto>> respostaService = await _funcaoFuncionarioServices.GetAll();

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex));
            }
        }
        [HttpGet("funcao-funcionario/{funcaoId}/funcaoId")]
        public async Task<ActionResult<ResponseDto<List<FuncaoFuncionarioDto>>>> GetById(Guid funcaoId)
        {
            try
            {
                var respostaService = await _funcaoFuncionarioServices.GetById(funcaoId);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex));
            }
        }
        [HttpPost("funcao-funcionario/create")]
        public async Task<ActionResult<ResponseDto<List<FuncaoFuncionarioDto>>>> Create(FuncaoFuncionarioDtoCreate create)
        {
            try
            {
                var respostaService = await _funcaoFuncionarioServices.CreateFuncao(create);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex));
            }
        }
        [HttpPut("funcao-funcionario/update")]
        public async Task<ActionResult<ResponseDto<List<FuncaoFuncionarioDto>>>> Update(FuncaoFuncionarioDtoUpdate update)
        {
            try
            {
                var respostaService = await _funcaoFuncionarioServices.Update(update);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FuncaoFuncionarioDto>>().Erro(ex));
            }
        }
    }
}
