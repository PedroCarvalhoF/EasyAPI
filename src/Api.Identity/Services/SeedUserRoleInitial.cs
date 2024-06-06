using Api.Identity.Constants;
using Api.Identity.Interfaces;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SeedUserRoleInitial(UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {

            //CRIANDO funcoes PROGRAMADOR
            var lista_funcoes = Roles.GetListaFuncoes();

            foreach (var roleName in lista_funcoes)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    Role role = new Role();
                    role.Name = roleName;
                    role.NormalizedName = roleName;
                    role.ConcurrencyStamp = Guid.NewGuid().ToString();

                    var roleResult = await _roleManager.CreateAsync(role);
                }
            }
           
        }

        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("admin@ec.com") == null)
            {
                User user = new User();
                user.Nome = "Programador ";
                user.SobreNome = "Desenvoledor";
                user.ImagemURL = string.Empty;
                user.UserName = "admin@ec.com";
                user.Email = "admin@ec.com";
                user.NormalizedUserName = "admin@ec.com";
                user.NormalizedEmail = "admin@ec.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = await _userManager.CreateAsync(user, "123456");

                if (result.Succeeded)
                {
                    foreach (var item in Roles.GetListaFuncoes())
                    {
                        await _userManager.AddToRoleAsync(user, item);
                    }
                }
            }
        }
    }
}
