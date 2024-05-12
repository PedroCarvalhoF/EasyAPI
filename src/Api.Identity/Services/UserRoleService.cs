using Domain.Identity.UserIdentity;
using Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> AddRole(Guid pessoaId, Guid roleId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(pessoaId.ToString());
                var role = await _roleManager.FindByIdAsync(roleId.ToString());


                var result = await _userManager.AddToRoleAsync(user, role.Name);

                if (result.Succeeded)
                    return true;
                else
                    throw new Exception(result.Errors.FirstOrDefault().Description);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateRole(string role)
        {
            role = role.ToUpper();

            if (!await _roleManager.RoleExistsAsync(role))
            {
                Role identityRole = new Role();
                identityRole.Name = role;
                identityRole.NormalizedName = role;
                identityRole.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(identityRole);
                if (roleResult.Succeeded)
                    return true;
                else
                    return false;
            }
            else
                throw new Exception("Função ja exíste");
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToArrayAsync();

            return roles;

        }
    }
}
