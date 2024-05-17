using Domain.Dtos;
using Domain.Dtos.PedidoSituacao;
using Domain.Interfaces.Services.PedidoSituacao;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PedidosSituacaoController : ControllerBase
    {
        private readonly ISituacaoPedidoService _service;

        public PedidosSituacaoController(ISituacaoPedidoService service)
        {
            _service = service;
        }

        [HttpGet("situacao-pedido")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> GetAll()
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
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
        [HttpGet("situacao-pedido/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Get(Guid id)
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
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
        [HttpGet("situacao-pedido/{descricao}/descricao")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Get(string descricao)
        {
            try
            {
                var respostaService = await _service.Get(descricao);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
        [HttpPost("situacao-pedido/create")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Create(SituacaoPedidoDtoCreate create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var respostaService = await _service.Create(create);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
        [HttpPut("situacao-pedido/update")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Update(SituacaoPedidoDtoUpdate update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var respostaService = await _service.Update(update);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
        [HttpPut("situacao-pedido/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Desabilitar(Guid id)
        {
            try
            {
                var respostaService = await _service.Desabilitar(id);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<SituacaoPedidoDto>>().Erro(ex));
            }
        }
    }
}
