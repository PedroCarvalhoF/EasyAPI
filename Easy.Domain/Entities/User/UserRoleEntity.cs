﻿using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Entities.User
{
    public class UserRoleEntity : IdentityUserRole<Guid>
    {
        public UserEntity? User { get; set; }
        public RoleEntity? Role { get; set; }
    }
}
