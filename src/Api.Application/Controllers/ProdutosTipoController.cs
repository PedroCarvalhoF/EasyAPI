using Domain.Dtos;
using Domain.Dtos.ProdutoTipo;
using Domain.Interfaces.Services.ProdutoTipo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutosTipoController : ControllerBase
    {
        private readonly IProdutoTipoServices _service;

        public ProdutosTipoController(IProdutoTipoServices services)
        {
            _service = services;
        }

        [HttpGet("tipos-produtos")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }
        [HttpGet("tipos-produtos/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> Get(Guid id)
        {
            try
            {
                var result = await _service.Get(id);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }
        [HttpGet("tipos-produtos/{descricao}")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> Get(string descricao)
        {
            try
            {
                var result = await _service.Get(descricao);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost("cadastrar-tipos-produtos")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> Post(ProdutoTipoDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Create(create);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("alterar-tipos-produtos")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> Update(ProdutoTipoDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Update(update);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("tipos-produtos/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<ProdutoTipoDto>>>> Desabilitar(Guid id)
        {
            try
            {
                var result = await _service.Desabilitar(id);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
