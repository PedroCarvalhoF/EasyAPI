using Domain.UserIdentity.MasterUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.UsuarioMaster
{
    public class UserMasterUserMap : IEntityTypeConfiguration<UserMasterUserEntity>
    {
        public void Configure(EntityTypeBuilder<UserMasterUserEntity> builder)
        {
            //builder.ToTable("UsuariosMasterUsers");
            //builder.HasKey(u => new { u.UserId, u.UserMasterClienteIdentityId });

            //builder.HasOne(uMaster => uMaster.UserMasterClienteIdentity)
            //       .WithMany(master => master.UsersMasterUsers)
            //       .HasForeignKey(uMaster => uMaster.UserMasterClienteIdentityId)
            //       .IsRequired();

            //builder.HasOne(us => us.User)
            //       .WithMany(users => users.UsersMasters)
            //       .HasForeignKey(us => us.UserId)
            //       .IsRequired();
        }
    }
}
