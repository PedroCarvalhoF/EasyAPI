using Api.Tools;
using Application.UseCases.Commands.UserMasterCliente;
using Application.UseCases.Handlers.UserMasterCliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    // [Authorize]
    public class AccountsUsuarioMasterClienteController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("CadastraUsuario")]
        public async Task<ActionResult> Cadastrar([FromBody] UserMasterCreateCommand create, [FromServices] UserMasterClienteHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.CadastrarUsuarioMaster(create));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] UserMasterClienteHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.GetAll());
        }

    }
}
