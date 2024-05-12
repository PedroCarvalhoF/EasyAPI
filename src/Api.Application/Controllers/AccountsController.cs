using Api.Application.Shared;
using Api.Domain.Dtos.IdentityDto;
using Api.Domain.Interfaces.Services.Identity;
using Domain.Dtos;
using Domain.Dtos.PerfilUsuario;
using Domain.Identity.UserIdentity;
using Domain.Interfaces.Services.PerfilUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IPerfilUsuarioService _perfilUsuarioService;

        public AccountsController(IIdentityService identityService, IPerfilUsuarioService perfilUsuarioService)
        {
            _identityService = identityService;
            _perfilUsuarioService = perfilUsuarioService;
        }


        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<User>> GetId(Guid id)
        {
            var usuarioDto = await _identityService.GetUserById(id);
            if (usuarioDto.Id == Guid.Empty)
                return BadRequest("Usuário não encontrado");
            return Ok(usuarioDto);
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guidExists = await _identityService.GetIdIdentityByName(usuarioCadastro.Email);

            if (guidExists != Guid.Empty)
            {
                ResponseDto<List<string>> resposta = new ResponseDto<List<string>>();
                resposta.Dados = new List<string>();
                resposta.Status = false;
                resposta.Mensagem = "Atenção usuário ja existe";
                return BadRequest(resposta);
            }


            var resultado = await _identityService.Create(usuarioCadastro);
            if (!resultado.Status)
            {
                return BadRequest(resultado);
            }

            if (resultado.Status)
            {
                //cadastra no sistema interno - criando perfil

                var idIdentity = await _identityService.GetIdIdentityByName(usuarioCadastro.Email);

                PerfilUsuarioDtoCreate perfilCreate = new PerfilUsuarioDtoCreate
                {
                    Nome = usuarioCadastro.Nome,
                    IdentityId = idIdentity
                };

                ResponseDto<List<PerfilUsuarioDto>> perfilResult = await _perfilUsuarioService.Create(perfilCreate);

                resultado.Mensagem += "Perfil de Usuário também cadastrado.";

                return Ok(resultado);
            }


            else if (resultado.Dados[0].Erros.Count > 0)
            {
                CustomProblemDetails problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: resultado.Dados[0].Erros);
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

            var resultado = await _identityService.Login(usuarioLogin);

            if (resultado.Dados.Any())
                return Ok(resultado);

            return Unauthorized(resultado);
        }



    }
}
