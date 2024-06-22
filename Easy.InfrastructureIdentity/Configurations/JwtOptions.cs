using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Easy.InfrastructureIdentity.Configurations;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public SigningCredentials SigningCredentials => new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)), SecurityAlgorithms.HmacSha256);
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
}