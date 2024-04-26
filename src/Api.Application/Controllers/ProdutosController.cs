using Domain.Dtos.ProdutoDtos;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

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
        public async Task<ActionResult> GetProdutos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.Get();
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpGet("produtos/{id}/id")]
        public async Task<ActionResult> GetId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.Get(id);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }


        [HttpGet("produtos/{codigoPersonalizado}/codigo-personalizado")]
        public async Task<ActionResult> GetCodigo(string codigoPersonalizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.GetCodigo(codigoPersonalizado);
                if (produtoDto == null)
                   return BadRequest("Não localizado.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }


        [HttpGet("produtos/{nomeProduto}/nome")]
        public async Task<ActionResult> GetNomeProduto(string nomeProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.Get(nomeProduto);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpGet("produtos/{categoriaId}/id-categoria")]
        public async Task<ActionResult> GetCategoriaId(Guid categoriaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.GetCategoria(categoriaId);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpGet("produtos/{medidaId}/id-medida")]
        public async Task<ActionResult> GetMedida(Guid medidaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.GetMedida(medidaId);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpGet("produtos/{produtoTipoId}/id-tipo")]
        public async Task<ActionResult> GetProdutoTipo(Guid produtoTipoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.GetProdutoTipo(produtoTipoId);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }



        [HttpGet("produtos/{habilitado}/habilitado")]
        public async Task<ActionResult> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var produtoDto = await _service.GetHabilitadoNaoHabilitado(habilitado);
                if (produtoDto == null) BadRequest("Não foi possíve realizar consulta.");
                return Ok(produtoDto);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }



        [HttpPost("cadastrar-produto")]
        public async Task<ActionResult> Post([FromBody] ProdutoDtoCreate create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Cadastrar(create);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }

        }

        [HttpPost("alterar-produto")]
        public async Task<ActionResult> Update([FromBody] ProdutoDtoUpdate update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Alterar(update);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
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
