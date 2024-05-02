using Domain.Dtos;
using Domain.Dtos.PedidoSituacao;
using Domain.Interfaces.Services.PedidoSituacao;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

            }
        }
        [HttpGet("situacao-pedido/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Get(Guid id)
        {
            try
            {
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

            }
        }
        [HttpGet("situacao-pedido/{descricao}/descricao")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Get(string descricao)
        {
            try
            {
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.Get(descricao);
                if (!result.Status)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

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
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.Create(create);
                if (!result.Status)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

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
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.Update(update);
                if (!result.Status)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

            }
        }
        [HttpPut("situacao-pedido/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<SituacaoPedidoDto>>>> Desabilitar(Guid id)
        {
            try
            {
                ResponseDto<List<SituacaoPedidoDto>> result = await _service.Desabilitar(id);

                if (!result.Status)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<SituacaoPedidoDto>> resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta = new ResponseDto<List<SituacaoPedidoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);

            }
        }
    }
}
