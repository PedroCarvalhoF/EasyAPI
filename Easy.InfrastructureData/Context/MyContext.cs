using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Context
{
    public class MyContext : IdentityDbContext<UserEntity, RoleEntity, Guid, IdentityUserClaim<Guid>, UserRoleEntity, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configurando USER
            modelBuilder.Entity<UserRoleEntity>(userRole =>
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

            //configurando UserMasterCliente ==>  UserEntity
            //1:1
            modelBuilder.Entity<UserMasterClienteEntity>(userMaster =>
            {
                userMaster.HasKey(uM => new { uM.UserMasterId });

                userMaster.HasOne(uM => uM.UserMaster)
                          .WithOne(user => user.UserMasterCliente)
                          .HasForeignKey<UserMasterClienteEntity>(umc => umc.UserMasterId);
            });

            //configurando UserCliente
            modelBuilder.Entity<UserMasterUserEntity>(userMasterUser =>
            {
                userMasterUser.HasKey(uCli => new { uCli.UserClienteId, uCli.UserMasterUserId });

                userMasterUser.HasOne(uMu => uMu.UserCliente)
                           .WithMany(uCli => uCli.UsersMasterUsers)
                           .HasForeignKey(uMu => uMu.UserClienteId);

                userMasterUser.HasOne(uMu => uMu.UserMasterUser)
                              .WithOne(user => user.UserMasterUser)
                              .HasForeignKey<UserMasterUserEntity>(uMu => uMu.UserMasterUserId);
            });
        }
    }
}
