using Easy.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Easy.InfrastructureData.Seeds;

public class SeedsTeste : ISeedsTeste
{
    private readonly UserManager<UserEntity> _userManager;
    public SeedsTeste(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
}
