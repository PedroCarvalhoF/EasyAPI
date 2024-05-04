using Domain.Entities.UsuarioSistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PerfilUsuario
{
    public class PerfilUsuarioMap : IEntityTypeConfiguration<PerfilUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuarioEntity> builder)
        {
            //tabela Produto
            builder.ToTable("PerfisUsuarios");
            //Id 
            builder.HasKey(user => user.IdentityId);


            //UsuarioIdentity           
            builder.Property(user => user.IdentityId)
                .IsRequired();


            //nome
            builder.Property(user => user.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(user => user.Nome)
                .IsUnique();
        }
    }
}
