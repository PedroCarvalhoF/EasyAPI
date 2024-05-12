using Domain.Identity.UserIdentity;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Identity.Context
{
    public class IdentityDataContext : IdentityDbContext<User, Role, Guid,
                                                       IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
                                                       IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }

    }
}
