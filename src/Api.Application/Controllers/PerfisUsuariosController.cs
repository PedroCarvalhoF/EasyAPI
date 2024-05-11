using Domain.Dtos;
using Domain.Dtos.PerfilUsuario;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.PerfilUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PerfisUsuariosController : ControllerBase
    {
        private readonly IPerfilUsuarioService _service;

        public PerfisUsuariosController(IPerfilUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("perfil-usuario")]
        public async Task<ActionResult<ResponseDto<List<PerfilUsuarioDto>>>> GetAll()
        {
            try
            {
                ResponseDto<List<PerfilUsuarioDto>> result = await _service.GetAll();
                if (result == null)
                    return BadRequest("Não foi possível realizar consulta");
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
        //[HttpGet("perfil-usuarios/{id}/id")]
        //public async Task<ActionResult<ResponseDto<List<PerfilUsuarioDto>>>> GetPerfilUsuarioId(Guid id)
        //{
        //    try
        //    {
        //        var result = await _service.GetPerfilUsuarioId(id);
        //        if (result == null)
        //            return BadRequest("Não foi possível realizar consulta.");
        //        return Ok(result);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}

        //[HttpPost("perfil-usuario/create")]
        //public async Task<ActionResult<ResponseDto<List<PerfilUsuarioDto>>>> Create(PerfilUsuarioDtoCreate create)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _service.Create(create);
        //        if (result == null)
        //            return BadRequest("Não foi possível cadastrar");
        //        return Ok(result);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}

        //[HttpPut("perfil-usuario/update")]
        //public async Task<ActionResult<ResponseDto<List<PerfilUsuarioDto>>>> Update(PerfilUsuarioDtoUpdate update)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _service.Update(update);
        //        if (result == null)
        //            return BadRequest("Não foi possível realizar update");
        //        return Ok(result);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}


        //[HttpPut("perfil-usuario/{id}/habilitado")]
        //public async Task<ActionResult<ResponseDto<List<PerfilUsuarioDto>>>> Desabilitar(Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _service.Desabilitar(id);
        //        if (result == null)
        //            return BadRequest("Não foi possível desabilitar");
        //        return Ok(result);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}
    }
}