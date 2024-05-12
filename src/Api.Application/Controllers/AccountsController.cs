using Api.Application.Shared;
using Api.Domain.Interfaces.Services.Identity;
using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity;
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


        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;

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
                resultado.CadastroOk("User cadastrado com sucesso!");
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
