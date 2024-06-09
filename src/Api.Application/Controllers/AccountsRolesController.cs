using AutoMapper;
using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsRoleController : ControllerBase
    {
        private readonly IUserRole _userRole;
        private readonly IMapper _mapper;
        public AccountsRoleController(IUserRole userRole, IMapper mapper)
        {
            _userRole = userRole; _mapper = mapper;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<ResponseDto<List<IdentityRole>>>> GetRoles()
        {
            try
            {
                var result = await _userRole.GetRoles();
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);

            }
            catch (Exception ex)
            {
                var response = new ResponseDto<List<Role>>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }


        [HttpPost("{idPessoa}/{idRole}/adionar")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AplicarRoleUser(Guid idPessoa, Guid idRole)
        {
            var result = await _userRole.AddRole(idPessoa, idRole);
            if (result.Status)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
