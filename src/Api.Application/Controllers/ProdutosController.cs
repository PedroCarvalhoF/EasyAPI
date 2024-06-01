using Domain.Dtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Interfaces.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProdutosController(IProdutoService produtoService, IWebHostEnvironment hostEnvironment)
        {
            _service = produtoService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetProdutos()
        {
            try
            {
                var result = await _service.Get();

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("produtos/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetId(Guid id)
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
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }


        [HttpGet("produtos/{codigoPersonalizado}/codigo-personalizado")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetCodigo(string codigoPersonalizado)
        {
            try
            {
                var result = await _service.GetCodigo(codigoPersonalizado);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }


        [HttpGet("produtos/{nomeProduto}/nome")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetNomeProduto(string nomeProduto)
        {
            try
            {
                var result = await _service.Get(nomeProduto);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("produtos/{categoriaId}/id-categoria")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetCategoriaId(Guid categoriaId)
        {
            try
            {
                var result = await _service.GetCategoria(categoriaId);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("produtos/{medidaId}/id-medida")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetMedida(Guid medidaId)
        {
            try
            {
                var result = await _service.GetMedida(medidaId);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("produtos/{produtoTipoId}/id-tipo")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetProdutoTipo(Guid produtoTipoId)
        {
            try
            {
                var result = await _service.GetProdutoTipo(produtoTipoId);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("produtos/{idPdv}/get-produtos-by-pdv")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetProdutosByPdvAsync(Guid idPdv)
        {
            try
            {
                var result = await _service.GetProdutosByPdvAsync(idPdv);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }


        //MÉTODOS
        [HttpPost("cadastrar-produto")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> Post([FromBody] ProdutoDtoCreate create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Cadastrar(create);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost("cadastrar-produto/array")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> PostArray([FromBody] IEnumerable<ProdutoDtoCreate> ArrayCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.CreateArray(ArrayCreate);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("produtos/{habilitado}/habilitado")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            try
            {
                var result = await _service.GetHabilitadoNaoHabilitado(habilitado);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("alterar-produto")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> Update([FromBody] ProdutoDtoUpdate update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Alterar(update);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("produtos/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<ProdutoDto>>>> Desabilitar(Guid id)
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
                ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
                response.Dados = new List<ProdutoDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).
                Take(10).
                ToArray()).Replace(" ", "_");

            imageName = $"{imageName}_{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            string imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/Images", imageName);

            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {

            if (imageName == "sem_foto.png")
                return;

            string imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}
