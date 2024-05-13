using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Identity.Services
{
    public class UserRoleServices : IUserRole
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserRoleServices(RoleManager<Role> roleManager, UserManager<User> userManager
            )
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task<ResponseDto<List<Role>>> GetRoles()
        {
            ResponseDto<List<Role>> resposta = new ResponseDto<List<Role>>();
            // resposta.Dados = new List<Role>();
            try
            {
                var roles = await _roleManager.Roles.ToArrayAsync();
                if (roles == null)
                {
                    resposta.ErroConsulta();
                    return resposta;
                }

                return resposta.Retorno(roles.ToList());
            }
            catch (Exception ex)
            {
                resposta.Erro(ex.Message);
                return resposta;

            }
        }
        public async Task<ResponseDto<List<Role>>> AddRole(Guid pessoaId, Guid roleId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(pessoaId.ToString());
                var role = await _roleManager.FindByIdAsync(roleId.ToString());


                var result = await _userManager.AddToRoleAsync(user, role.Name);

                return new ResponseDto<List<Role>>();

                //if (result.Succeeded)
                //    return true;
                //else
                //    throw new Exception(result.Errors.FirstOrDefault().Description);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseDto<List<Role>>> CreateRole(string role)
        {
            role = role.ToUpper();

            if (!await _roleManager.RoleExistsAsync(role))
            {
                Role identityRole = new Role();
                identityRole.Name = role;
                identityRole.NormalizedName = role;
                identityRole.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(identityRole);
                return new ResponseDto<List<Role>>();

                //if (roleResult.Succeeded)
                //    return true;
                //else
                //    return false;
            }
            else
                throw new Exception("Função ja exíste");
        }


    }
}
