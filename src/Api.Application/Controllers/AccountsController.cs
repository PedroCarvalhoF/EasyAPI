using Api.Domain.Interfaces.Services.Identity;
using Api.Extensions;
using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.Interfaces.Services.UserMasterCliente;
using Domain.UserIdentity;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.UserMaster;

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

        [AllowAnonymous]
        [HttpPost("cadastrar-user/")]
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
        [HttpPost("cadastrar-user-master-cliente/")]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> CadastrarUserMasterCliente([FromBody] UserMasterUserDtoCreate uM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _userMasterClienteServices.CadastrarUserMasterCliente(uM.UserMasterClienteIdentityId);
                if (result.Status)
                {
                    var resultCredencial = await GerarCredencialUsuario(uM);
                    return Ok(resultCredencial);
                }

                return result.Status ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<User>>().Erro(ex));
            }
        }

        [HttpPost("gerar-credencial-usuario/")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseDto<List<UsuarioCadastroResponse>>>> GerarCredencialUsuario([FromBody] UserMasterUserDtoCreate uM)
        {
            try
            {
                var createCredencial = await _userMasterClienteServices.GerarCredencialUsuario(uM.UserMasterClienteIdentityId, uM.UserId);
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
        public async Task<ActionResult> GetServerName([FromServices] IConfiguration configuration)
        {
            var userMaster = User.GetUserMasterUser();


            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            return Ok(connectionString);

        }

        [HttpGet("users-masters-clientes")]
        public async Task<RequestResult> GetUserMastersCliente()
        {
            return await _userMasterClienteServices.GetUserMastersCliente();
        }
    }
}
