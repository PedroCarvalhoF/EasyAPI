using Api.Domain.Interfaces.Services.Identity;
using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.Interfaces.Services.UserMasterCliente;
using Domain.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _identityService;
        private readonly IUserMasterClienteServices _userMasterClienteServices;
        public AccountsController(IUserService identityService, IUserMasterClienteServices userMasterClienteServices)
        {
            _identityService = identityService;
            _userMasterClienteServices = userMasterClienteServices;
        }

        [HttpGet("get-user")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetAll()
        {
            try
            {
                var result = await _identityService.GetAll();
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetId(Guid id)
        {
            try
            {
                var result = await _identityService.GetUserById(id);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [HttpGet("get-user/{idRole}/id-role")]
        public async Task<ActionResult<ResponseDto<List<User>>>> GetByIdRole(Guid idRole)
        {
            try
            {
                var result = await _identityService.GetByIdRole(idRole);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }


        [AllowAnonymous]
        [HttpPost("cadastrar-cadastrar-user")]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _identityService.Create(usuarioCadastro);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [AllowAnonymous]
        [HttpPost("cadastrar-cadastrar-user-master-cliente/")]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> CadastrarUserMasterCliente([FromBody] Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _userMasterClienteServices.CadastrarUserMasterCliente(userId);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [HttpPost("gerar-credencial-usuario/{userCliente}/{userForCrendencial}")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> GerarCredencialUsuario(Guid userCliente, Guid userForCrendencial)
        {
            try
            {
                var createCredencial = await _userMasterClienteServices.GerarCredencialUsuario(userCliente, userForCrendencial);
                return createCredencial.Status ? Ok(createCredencial) : BadRequest(createCredencial);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto<UsuarioLoginResponse>>> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _identityService.Login(usuarioLogin);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult<ResponseDto<UsuarioLoginResponse>>> Alterar(UsuarioUpdateSenhaRequest usuarioLoginUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = await _identityService.AlterarSenha(usuarioLoginUpdate);
                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
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
