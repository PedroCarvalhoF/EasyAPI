using Api.Tools;
using Application.UseCases.Commands.UserMasterUser;
using Application.UseCases.Handlers.UserMasterCliente;
using Application.UseCases.Handlers.UserMasterUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    // [Authorize]
    public class AccountsUsuarioMasterUserController : ControllerBase
    {
        
        [HttpPost("cadastrar-usuario-ao-cliente")]
        public async Task<ActionResult> Cadastrar([FromBody] UserMasterUserCreateCommand create, [FromServices] UserMasterUserHadler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.CadastrarUsuarioCliente(create));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] UserMasterClienteHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.GetAll());
        }

    }
}
