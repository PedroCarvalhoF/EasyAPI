using Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class UserRole : IUserRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRole(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager
            )
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task<bool> AddRole(Guid pessoaId, Guid roleId)
        {
            try
            {
                IdentityUser? user = await _userManager.FindByIdAsync(pessoaId.ToString());
                IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString());


                IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);

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
                IdentityRole identityRole = new IdentityRole();
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

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            IdentityRole[] roles = await _roleManager.Roles.ToArrayAsync();

            return roles;

        }
    }
}
