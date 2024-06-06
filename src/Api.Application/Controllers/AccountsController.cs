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
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _identityService;
        public AccountsController(IUserService identityService)
        {
            _identityService = identityService;

        }

        [HttpGet("get-user")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetAll()
        {
            try
            {
                var users = await _identityService.GetAll();

                if (users.Status)
                    return Ok(users);
                else
                    return BadRequest(users);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<User>>();
                response.Dados = new List<User>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetId(Guid id)
        {
            var usuarioDto = await _identityService.GetUserById(id);
            if (usuarioDto.Status)
                return Ok(usuarioDto);

            return BadRequest(usuarioDto);
        }

        [HttpGet("get-user/{idRole}/id-role")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetByIdRole(Guid idRole)
        {
            try
            {
                var users = await _identityService.GetByIdRole(idRole);

                if (users.Status)
                    return Ok(users);
                else
                    return BadRequest(users);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<User>>();
                response.Dados = new List<User>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.Create(usuarioCadastro);
            if (resultado.Status)
                return Ok(resultado);


            return BadRequest(resultado);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto<UsuarioLoginResponse>>> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.Login(usuarioLogin);

            if (resultado.Dados != null)
                return Ok(resultado);

            ResponseDto<List<UsuarioLoginResponse>> response = new ResponseDto<List<UsuarioLoginResponse>>();
            response.Dados = new List<UsuarioLoginResponse>();
            response.Erro(resultado.Mensagem);

            return BadRequest(response);

        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<ResponseDto<UsuarioLoginResponse>>> Alterar(UsuarioUpdateSenhaRequest usuarioLoginUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.AlterarSenha(usuarioLoginUpdate);

            if (resultado.Status)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpGet("get-server")]
        [AllowAnonymous]
        public async Task<ActionResult> GetServerName([FromServices] IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            return Ok(connectionString);

        }
    }
}
