using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Domain.Dtos;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutosCategoriasPrecosController : ControllerBase
    {
        private readonly ICategoriaPrecoService _service;
        public ProdutosCategoriasPrecosController(ICategoriaPrecoService categoriaPrecoService)
        {
            _service = categoriaPrecoService;
        }

        [HttpGet("categorias-precos")]
        public async Task<ActionResult<ResponseDto<List<CategoriaPrecoDto>>>> GetAll()
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
                ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
                response.Dados = new List<CategoriaPrecoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("categorias-precos/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<CategoriaPrecoDto>>>> Get(Guid id)
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
                ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
                response.Dados = new List<CategoriaPrecoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPost("cadastrar-categorias-precos")]
        public async Task<ActionResult<ResponseDto<List<CategoriaPrecoDto>>>> Cadastrar(CategoriaPrecoDtoCreate categoriaPrecoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Create(categoriaPrecoDtoCreate);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
                response.Dados = new List<CategoriaPrecoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPut("alterar-categorias-precos")]
        public async Task<ActionResult<ResponseDto<List<CategoriaPrecoDto>>>> Update(CategoriaPrecoDtoUpdate update)
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
                ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
                response.Dados = new List<CategoriaPrecoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPut("desabilitar/categorias-precos/{id}")]
        public async Task<ActionResult<ResponseDto<List<CategoriaPrecoDto>>>> Desabilitar(Guid id)
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
                ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
                response.Dados = new List<CategoriaPrecoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }
    }
}