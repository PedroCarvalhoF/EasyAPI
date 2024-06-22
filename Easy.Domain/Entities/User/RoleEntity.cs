using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Easy.Domain.Entities.User
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public List<UserRoleEntity>? UserRoles { get; set; }
    }
}
