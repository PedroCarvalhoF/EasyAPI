using Easy.Domain.Entities;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.InfrastructureData.Configuration;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Easy.Services.Service
{
    public class UserService : IUserService
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly JwtOptions _jwtOptions;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(SignInManager<UserEntity> signInManager,
                           UserManager<UserEntity> userManager,
                           IOptions<JwtOptions> jwtOptions,
                           IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult<UsuarioCadastroResponse>> CadastrarUsuario(UsuarioCadastroRequest user)
        {
            var identityUser = UserEntity.CreateUser(user.Nome, user.SobreNome, user.Email, user.Email);

            var result = await _userManager.CreateAsync(identityUser, user.Senha);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded, identityUser.Id);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            if (result.Succeeded)
            {
                return RequestResult<UsuarioCadastroResponse>.Ok(usuarioCadastroResponse, "Usuário cadastrado com sucesso.");
            }
            else
            {
                return RequestResult<UsuarioCadastroResponse>.BadRequest("Falha ao cadastrar usuário.");
            }
        }

        public async Task<RequestResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {
            var usuarioLoginResponse = new UsuarioLoginResponse();

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
            {
                var userSelecionado = await _userManager.FindByEmailAsync(usuarioLogin.Email);

                var mUser = await _unitOfWork.UserMasterUserRepository.GetById(userSelecionado.Id);

                if (mUser == null)
                    throw new ArgumentException("Usuário não crendeciado para ter acesso.");

                var filtro = new FiltroBase(mUser.UserClienteId, mUser.UserMasterUserId);

                usuarioLoginResponse = await GerarCredenciais(usuarioLogin.Email, filtro);
                usuarioLoginResponse.UsuarioReponseDetails(userSelecionado.Nome, userSelecionado.Email, userSelecionado.Id);
            }

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return RequestResult<UsuarioLoginResponse>.Ok(usuarioLoginResponse, "Login realizado com sucesso.");

        }
        private async Task<UsuarioLoginResponse> GerarCredenciais(string email, FiltroBase filtro)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true, filtro);
            var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false, filtro);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);
            return new UsuarioLoginResponse
            (
                sucesso: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        public string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<IList<Claim>> ObterClaims(UserEntity user, bool adicionarClaimsUsuario, FiltroBase filtro)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("ClienteId", filtro.clienteId.ToString()),
                new Claim("UserId", filtro.userId.ToString())
            };

            if (adicionarClaimsUsuario)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("roles", role));
            }

            return claims;
        }
    }
}
