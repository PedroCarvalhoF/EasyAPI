using Api.Domain.Dtos.IdentityDto;
using Api.Domain.Interfaces.Services.Identity;
using Api.Identity.Configurations;
using Domain.Dtos;
using Domain.Dtos.IdentityDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro)
        {
            ResponseDto<List<UsuarioCadastroResponse>> resposta = new ResponseDto<List<UsuarioCadastroResponse>>();
            resposta.Dados = new List<UsuarioCadastroResponse>();
            IdentityUser identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            IdentityResult result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

                resposta.Status = true;
                resposta.Mensagem = $"Usuário Idendity Cadastrado com sucesso.";
                return resposta;
            }


            UsuarioCadastroResponse usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            resposta.Dados.Add(usuarioCadastroResponse);
            resposta.Status = false;
            resposta.Mensagem = $"{usuarioCadastroResponse.Erros.FirstOrDefault()}";


            return resposta;
        }
        public async Task<ResponseDto<List<UsuarioLoginResponse>>> Login(UsuarioLoginRequest usuarioLogin)
        {

            ResponseDto<List<UsuarioLoginResponse>> resposta = new ResponseDto<List<UsuarioLoginResponse>>();
            resposta.Dados = new List<UsuarioLoginResponse>();

            SignInResult result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
            {
                resposta.Status = true;
                resposta.Mensagem = "Login efetuado com sucesso.";
                resposta.Dados.Add(await GerarCredenciais(usuarioLogin.Email));
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
       
        public async Task<UsuarioDto> GetUserById(Guid id)
        {
            IdentityUser? usuarioName = await _userManager.FindByIdAsync(id.ToString());
            if (usuarioName == null)
                return new UsuarioDto();

            UsuarioDto user = new UsuarioDto
            {
                Email = usuarioName.Email,
                Id = Guid.Parse(usuarioName.Id),
                Nome = usuarioName.UserName
            };

            return user;
        }

        public async Task<Guid> GetIdIdentityByName(string name)
        {
            IdentityUser? userName = await _userManager.FindByNameAsync(name);
            if (userName == null)
                return Guid.Empty;

            return Guid.Parse(userName.Id);
        }


        private async Task<UsuarioLoginResponse> GerarCredenciais(string email)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(email.ToLower());

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
        private async Task<IList<Claim>> ObterClaims(IdentityUser user, bool adicionarClaimsUsuario)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
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

    }
}
