using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Interfaces.Services.FormaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PedidosFormasPagamentosController : ControllerBase
    {
        private readonly IFormaPagamentoService _service;

        public PedidosFormasPagamentosController(IFormaPagamentoService service)
        {
            _service = service;
        }

        [HttpGet("forma-pagamento")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetAll()
        {
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }

        }
        [HttpGet("forma-pagamento/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetById(Guid id)
        {
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }


        [HttpGet("forma-pagamento/{descricao}/descricao")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetByDescricao(string descricao)
        {
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.GetByDescricao(descricao);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(resposta);
            }
        }


        [HttpPost("forma-pagamento/create")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.Create(formaPagamentoDtoCreate);
                return result;
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }
        [HttpPut("forma-pagamento/update")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.Update(formaPagamentoDtoUpdate);
                return result;
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }

        [HttpPut("forma-pagamento/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> DesabilitarHabilitar(Guid id)
        {
            try
            {
                ResponseDto<List<FormaPagamentoDto>> result = await _service.DesabilitarHabilitar(id);
                return result;
            }
            catch (Exception ex)
            {
                ResponseDto<List<FormaPagamentoDto>> resposta = new ResponseDto<List<FormaPagamentoDto>>();
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return resposta;
            }
        }

    }
}
