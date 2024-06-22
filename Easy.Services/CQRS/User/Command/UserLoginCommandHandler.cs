using Easy.Domain.Entities;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.InfrastructureIdentity.Configurations;
using Easy.Services.CQRS.User.Command;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, RequestResult>
{
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtOptions _jwtOptions;
    private readonly IUnitOfWork _repository;

    public UserLoginCommandHandler(SignInManager<UserEntity> signInManager,
                               UserManager<UserEntity> userManager,
                               IOptions<JwtOptions> jwtOptions,
                               IUnitOfWork repository)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
        _repository = repository;
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
                var usersMastersUsers = await _repository.UserMasterUserRepository.GetAllAsync();
                var userSelecionado = usersMastersUsers.SingleOrDefault(u => u.UserMasterUserId == user.Id);
                var filtro = new FiltroBase(userSelecionado.UserClienteId, user.Id);
                var credenciais = await GerarCredenciais(request.Email, filtro);
                return new RequestResult().Ok(credenciais);
            }

            var usuarioLoginResponse = new UsuarioLoginResponse();
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
    private async Task<UsuarioLoginResponse> GerarCredenciais(string email, FiltroBase filtro)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await ObterClaims(user, true, filtro);
        var refreshTokenClaims = await ObterClaims(user, false, filtro);

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

    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {
        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: dataExpiracao,
            signingCredentials: _jwtOptions.SigningCredentials);

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

    #endregion
}
