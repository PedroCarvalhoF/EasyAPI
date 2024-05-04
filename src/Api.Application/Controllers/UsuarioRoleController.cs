using Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //[Authorize(Roles = $"{Roles.Gerente},{Roles.Admin},{Roles.Supervisor}")]
    [ApiController]
    [Route("api/[controller]")]
    class UsuarioRoleController : ControllerBase
    {
        private readonly IUserRole _userRole;

        public UsuarioRoleController(IUserRole userRole)
        {
            this._userRole = userRole;
        }

        [HttpPost("CadastrarRole")]
        public async Task<ActionResult<bool>> CadastrarRole(string nameRole)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = await _userRole.CreateRole(nameRole);
            return result;
        }


        [HttpGet("ConsultarRoles")]
        public async Task<ActionResult> ConsultarRoles()
        {
            return Ok(await _userRole.GetRoles());
        }

        [HttpPost("AplicarRolesUser")]
        public async Task<ActionResult> AplicarRoleUser(Guid pessoaId, Guid roldId)
        {
            Boolean resultado = await _userRole.AddRole(pessoaId, roldId);


            if (resultado)
                return Ok(resultado);
            else
                return BadRequest("Não foi possível aplicar função ao usuário.");
        }


    }
}
