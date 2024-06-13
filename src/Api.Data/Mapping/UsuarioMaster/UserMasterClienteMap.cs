using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.UsuarioMaster
{
    public class UserMasterClienteMap : IEntityTypeConfiguration<UserMasterClienteEntity>
    {
        public void Configure(EntityTypeBuilder<UserMasterClienteEntity> builder)
        {
            builder.ToTable("UsuariosMasterClientes");
            builder.HasKey(u => u.UserMasterId);

            builder.HasOne(um => um.UserMaster)
                   .WithOne(user => user.UsuerMasterCliente);
        }
    }
}
