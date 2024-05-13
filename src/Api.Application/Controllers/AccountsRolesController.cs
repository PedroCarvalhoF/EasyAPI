using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.IdentityRole;
using Domain.Identity.UserIdentity;
using Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
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
            ResponseDto<List<Role>> response = new ResponseDto<List<Role>>();
            response.Dados = new List<Role>();
            try
            {
                var result = await _userRole.GetRoles();
                if (result == null)
                {
                    response.Mensagem = $"Não foi possível consultar funções";
                    response.Status = false;
                    return BadRequest(response);
                }

                

                response.Dados = result.ToList();
                response.Status = true;
                response.Mensagem = $"Consulta realizada com sucesso!Localizadas: {response.Dados.Count}";

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return BadRequest(response);
            }
        }

        [HttpPost("role/add-role-user")]
        public async Task<ActionResult<ResponseDto<bool>>> AddRole(UserRoleDtoAdd user)
        {
            ResponseDto<string> response = new ResponseDto<string>();
            try
            {
                var result = await _userRole.AddRole(user.PessoaId, user.RoleId);

                if (result)
                {
                    response.Mensagem = $"Função aplicada.";
                    response.Status = true;
                    response.Dados = $"Função aplicada com sucesso! Usuário tem a permissão atribuída.";
                    return Ok(response);
                }

                response.Mensagem = $"Não foi possível criar.";
                response.Status = false;                
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}.";
                response.Status = false;
                return BadRequest(response);
            }
        }

        [HttpPost("role/create")]
        public async Task<ActionResult<ResponseDto<string>>> CreateRole(RoleDtoCreate role)
        {
            ResponseDto<string> response = new ResponseDto<string>();

            try
            {
                bool result = await _userRole.CreateRole(role.RoleName);
                if (result)
                {
                    response.Mensagem = $"Função {role.RoleName.ToLower()} criada com sucesso.";
                    response.Status = true;
                    response.Dados = $"Adicionar funções aos usuários.";
                    return Ok(response);
                }

                response.Mensagem = $"Não foi possível criar.";
                response.Status = false;
                response.Dados = $"Não foi possível criar.";

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                response.Dados = $"Erro ao Executar Operacao.";
                return BadRequest(response);
            }
        }
    }
}
