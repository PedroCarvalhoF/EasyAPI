using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Extensions;
using Application.UseCases.Commands.PontoVenda.Usuario;
using Application.UseCases.Handlers.PontoVenda.Usuario;
using Domain.Dtos;
using Domain.Dtos.PontoVendaUser;
using Domain.Interfaces.Services.PontoVendaUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class UsuarioPontoVendaController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RegistrarUsuarioPontoVendaCommand command, [FromServices] RegistrarUsuarioPontoVendaHandler service)
        {
            var users = User.GetUserMasterUser();
            return new ReturnActionResult().ParseToActionResult(await service.Handler(command, users), User.GetUserMasterUserDatalhes());
        }
    }
}
