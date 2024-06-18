using Api.Tools;
using Application.UseCases.Commands.User;
using Application.UseCases.Handlers.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    // [Authorize]
    public class AccountsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("CadastraUsuario")]
        public async Task<ActionResult> Cadastrar([FromBody] UserCreateCommand create, [FromServices] UserIdentityHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.Cadastrar(create));
        }
        [AllowAnonymous]
        [HttpPost("AlterarSenha")]
        public async Task<ActionResult> AlterarSenha([FromBody] UserUpdatePassword updatePassword, [FromServices] UserIdentityHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.AlterarSenha(updatePassword));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] UserGetHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.GetAllAsync());
        }

        [HttpGet("get-by-user-id/{id}/")]
        public async Task<ActionResult> GetUserByIdAsync(Guid id, [FromServices] UserGetHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.GetUserByIdAsync(id));
        }

        [HttpGet("get-by-user-email/{email}/")]
        public async Task<ActionResult> GetAll(string email, [FromServices] UserGetHandler services)
        {
            return new ReturnActionResult().ParseToActionResult(await services.GetUserByEmailAsync(email));
        }
    }
}
