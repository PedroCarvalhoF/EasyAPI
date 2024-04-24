using Api.Identity.Constants;
using Api.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            //CRIANDO ROLE PROGRAMADOR
            string roleName = Roles.Programador;
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleName;
                role.NormalizedName = roleName;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }


            if (!await _roleManager.RoleExistsAsync(Roles.Admin))
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Admin;
                role.NormalizedName = Roles.Admin;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Gerente))
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Gerente;
                role.NormalizedName = Roles.Gerente;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Supervisor))
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Supervisor;
                role.NormalizedName = Roles.Supervisor;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync(Roles.OperadorCaixa))
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.OperadorCaixa;
                role.NormalizedName = Roles.OperadorCaixa;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

        }

        public async Task SeedUsersAsync()
        {
            string senha_padrao = "123456";

            if (await _userManager.FindByEmailAsync("admin@ec.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@ec.com";
                user.Email = "admin@ec.com";
                user.NormalizedUserName = "admin@ec.com";
                user.NormalizedEmail = "admin@ec.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, senha_padrao);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }

            //SUPERVISOR
            if (await _userManager.FindByEmailAsync("supervisor@ec.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "supervisor@ec.com";
                user.Email = "supervisor@ec.com";
                user.NormalizedUserName = "SUPERVISOR@EC.COM";
                user.NormalizedEmail = "SUPERVISOR@EC.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, senha_padrao);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Supervisor);
                }
            }

            //GERENTE
            if (await _userManager.FindByEmailAsync("gerente@ec.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "gerente@ec.com";
                user.Email = "gerente@ec.com";
                user.NormalizedUserName = "GERENTE@EC.COM";
                user.NormalizedEmail = "GERENTE@EC.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, senha_padrao);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Gerente);
                }
            }

            //GERENTE
            if (await _userManager.FindByEmailAsync("operadorcaixa@ec.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "operadorcaixa@ec.com";
                user.Email = "operadorcaixa@ec.com";
                user.NormalizedUserName = "OPERADORCAIXA@EC.COM";
                user.NormalizedEmail = "OPERADORCAIXA@EC.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, senha_padrao);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.OperadorCaixa);
                }
            }
        }
    }
}
