using Easy.Domain.Entities.User;
using Easy.InfrastructureData.Configurations;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, RequestResult>
{
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtOptions _jwtOptions;

    public UserLoginCommandHandler(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<RequestResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userManager.Users
                                            .SingleOrDefaultAsync(user => user.UserName == request.Email.ToLower());

            if (user == null)
                return new RequestResult().BadRequest("Login ou senha inválido");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Senha, false);
            if (result.Succeeded)
            {

                var credenciais = await GerarCredenciais(request.Email);
                return new RequestResult().Ok(credenciais);
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

            return new RequestResult().BadRequest(usuarioLoginResponse.Erros.Single());
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
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
    private async Task<IList<Claim>> ObterClaims(UserEntity user, bool adicionarClaimsUsuario)
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
}
