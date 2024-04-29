using Api.Application.Shared;
using Api.Domain.Dtos.IdentityDto;
using Api.Domain.Interfaces.Services.Identity;
using Domain.Dtos.IdentityDto;
using Domain.Dtos.PerfilUsuario;
using Domain.Interfaces.Services.PerfilUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IPerfilUsuarioService _perfilUsuarioService;

        public AccountsController(IIdentityService identityService, IPerfilUsuarioService perfilUsuarioService)
        {
            _identityService = identityService;
            _perfilUsuarioService = perfilUsuarioService;
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UsuarioCadastroResponse resultado = await _identityService.CadastrarUsuario(usuarioCadastro);




            if (resultado.Sucesso)
            {

                var idIdentity = await _identityService.GetIdIdentityByName(usuarioCadastro.Email);
                

                PerfilUsuarioDtoCreate perfilCreate = new PerfilUsuarioDtoCreate
                {
                    Nome = usuarioCadastro.Nome,
                    IdentityId = idIdentity
                };

                var perfilResult = await _perfilUsuarioService.Create(perfilCreate);

                return Ok(resultado);
            }


            else if (resultado.Erros.Count > 0)
            {
                CustomProblemDetails problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: resultado.Erros);
                return BadRequest(problemDetails);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UsuarioLoginResponse resultado = await _identityService.Login(usuarioLogin);
            if (resultado.Sucesso)
                return Ok(resultado);

            return Unauthorized(resultado);
        }

        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<UsuarioDto>> GetId(Guid id)
        {
            UsuarioDto usuarioDto = await _identityService.GetUserById(id);
            if (usuarioDto.Id == Guid.Empty)
                return BadRequest("Usuário não encontrado");


            return Ok(usuarioDto);
        }

        [HttpGet("get-all-user")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var users = await _identityService.GetAll();
            return Ok(users);
        }


        [AllowAnonymous]
        [HttpGet("TESTE-API")]
        public async Task<ActionResult> TesteAPI()
        {
            return Content("Teste de conexão realizada com sucesso!Realize o login para ter acesso completo ao sistema");
        }
    }
}
