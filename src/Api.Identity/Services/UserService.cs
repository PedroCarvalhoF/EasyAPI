using Api.Domain.Interfaces.Services.Identity;
using Api.Identity.Configurations;
using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;

        public UserService(SignInManager<User> signInManager,
                               UserManager<User> userManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        #region Privados
        private async Task<UsuarioLoginResponse> GerarCredenciais(string email)
        {
            var user = await _userManager.FindByEmailAsync(email.ToLower());

            if (user == null)
            {
                //Lidar com o usuário
                return new UsuarioLoginResponse();
            }

            IList<Claim> accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
            IList<Claim> refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

            DateTime dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            DateTime dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            string accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            string refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            return new UsuarioLoginResponse
            (
                sucesso: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }
        private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private async Task<IList<Claim>> ObterClaims(User user, bool adicionarClaimsUsuario)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            if (adicionarClaimsUsuario)
            {
                IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
                IList<string> roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (string role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }
        #endregion
        public async Task<ResponseDto<List<User>>> GetAll()
        {
            var resposta = new ResponseDto<List<User>>();
            resposta.Dados = new List<User>();
            try
            {
                var users = await _userManager.Users.Include(r => r.UserRoles).ThenInclude(r => r.Role).ToArrayAsync();
                resposta.Dados = users.ToList();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Erro(ex.Message);
                return resposta;
            }
        }
        public async Task<ResponseDto<List<User>>> GetUserById(Guid id)
        {
            var resposta = new ResponseDto<List<User>>();
            resposta.Dados = new List<User>();

            try
            {
                var user = await _userManager.Users.Include(r => r.UserRoles).ThenInclude(r => r.Role).Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
                if (user == null)
                {
                    resposta.Erro();
                    return resposta;
                }

                resposta.Dados.Add(user);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Erro(ex.Message);
                return resposta;
            }
        }
        public async Task<ResponseDto<List<Guid>>> GetIdIdentityByName(string name)
        {
            var resposta = new ResponseDto<List<Guid>>();
            resposta.Dados = new List<Guid>();

            try
            {
                var userName = await _userManager.FindByNameAsync(name);
                if (userName == null)
                {
                    resposta.ErroConsulta("Atençao.", "Usuário não localizado");
                    return resposta;
                }

                resposta.Dados.Add(userName.Id);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Erro(ex.Message);
                return resposta;
            }

        }
        public async Task<ResponseDto<List<User>>> GetByIdRole(Guid idRole)
        {
            var resposta = new ResponseDto<List<User>>();
            resposta.Dados = new List<User>();

            try
            {
                var users = await _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(u => u.UserRoles.Any(ur => ur.RoleId == idRole)).ToListAsync();
                if (users == null)
                {
                    resposta.ErroConsulta();
                    return resposta;
                }

                resposta.Dados = users;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Erro(ex.Message);
                return resposta;
            }
        }
        public async Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro)
        {
            var resposta = new ResponseDto<List<UsuarioCadastroResponse>>();
            try
            {
                var exists = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.Equals(usuarioCadastro.Email));

                if (exists != null)
                {
                    return resposta.Erro("Usuário já cadastrado");
                }

                User identityUser = new User
                {
                    Nome = usuarioCadastro.Nome,
                    SobreNome = usuarioCadastro.SobreNome,
                    UserName = usuarioCadastro.Email,
                    Email = usuarioCadastro.Email,
                    EmailConfirmed = true,
                    ImagemURL = string.Empty
                };

                var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);

                if (result.Succeeded)
                {
                    var userCreate = await _userManager.SetLockoutEnabledAsync(identityUser, false);

                    resposta.CadastroOk();
                    return resposta;
                }

                var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
                if (!result.Succeeded && result.Errors.Count() > 0)
                    usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

                resposta.Dados.Add(usuarioCadastroResponse);
                resposta.Status = false;
                resposta.Mensagem = $"{usuarioCadastroResponse.Erros.FirstOrDefault()}";

                return resposta;

            }
            catch (Exception ex)
            {
                return resposta.Erro(ex);
            }
        }
        public async Task<ResponseDto<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {

            ResponseDto<UsuarioLoginResponse> resposta = new ResponseDto<UsuarioLoginResponse>();
            resposta.Dados = new UsuarioLoginResponse();

            var user = await _userManager.Users
                                            .SingleOrDefaultAsync(user => user.UserName == usuarioLogin.Email.ToLower());

            if (user == null)
            {
                resposta.Status = false;
                resposta.Erro("Login ou senha inválido");
                return resposta;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, usuarioLogin.Senha, false);
            if (result.Succeeded)
            {
                resposta.Status = true;
                resposta.Mensagem = "Login efetuado com sucesso.";
                var credenciais = await GerarCredenciais(usuarioLogin.Email);
                resposta.Dados = (credenciais);
                return resposta;
            }


            UsuarioLoginResponse usuarioLoginResponse = new UsuarioLoginResponse();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada.");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login.");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação.");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha inválidos.");
            }

            resposta.Mensagem = $"{usuarioLoginResponse.Erros.FirstOrDefault()}";
            resposta.Status = false;
            return resposta;
        }

        public async Task<ResponseDto<List<UsuarioCadastroResponse>>> AlterarSenha(UsuarioUpdateSenhaRequest userNewPass)
        {
            try
            {
                var user = await _userManager.Users.Where(u => u.Id == userNewPass.IdUser).SingleOrDefaultAsync();
                if (user == null)
                    return new ResponseDto<List<UsuarioCadastroResponse>>().Erro("Usuário não localizado");

                var varResultSenhaAlterada = await _userManager.ChangePasswordAsync(user, userNewPass.SenhaAntiga, userNewPass.NovaSenha);
                if (!varResultSenhaAlterada.Succeeded)
                {
                    return new ResponseDto<List<UsuarioCadastroResponse>>().Erro(varResultSenhaAlterada.Errors.SingleOrDefault().Description);
                }

                return new ResponseDto<List<UsuarioCadastroResponse>>().UpdateOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<UsuarioCadastroResponse>>().Erro(ex);
            }
        }
    }
}
