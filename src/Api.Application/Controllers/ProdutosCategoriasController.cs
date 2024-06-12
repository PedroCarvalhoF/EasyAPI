using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutosCategoriasController : ControllerBase
    {
        private readonly ICategoriaProdutoService _service;
        public ProdutosCategoriasController(ICategoriaProdutoService categoriaProdutoService)
        {
            _service = categoriaProdutoService;
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<ResponseDto<List<CategoriaProdutoDto>>>> Get()
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
                var response = new ResponseDto<List<CategoriaProdutoDto>>();
                return BadRequest(response.Erro(ex.Message));
            }
        }
        [HttpGet("categorias/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<CategoriaProdutoDto>>>> Get(Guid id)
        {
            try
            {
                var result = await _service.GetIdCategoriaProduto(id);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<CategoriaProdutoDto>>();
                return BadRequest(response.Erro(ex.Message));
            }
        }


        [HttpPost("categorias/create")]
        public async Task<ActionResult<ResponseDto<List<CategoriaProdutoDto>>>> Create(CategoriaProdutoDtoCreate create)
        {
            try
            {
                var result = await _service.Create(create);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<CategoriaProdutoDto>>();
                return BadRequest(response.Erro(ex.Message));
            }

        }

        [HttpPut("categorias/update")]
        public async Task<ActionResult<ResponseDto<List<CategoriaProdutoDto>>>> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate)
        {
            try
            {
                var result = await _service.Update(categoriaProdutoDtoUpdate);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);

            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<CategoriaProdutoDto>>();
                return BadRequest(response.Erro(ex.Message));
            }
        }
    }
}