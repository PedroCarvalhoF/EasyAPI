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
            builder.ToTable("PerfilsUsuarios");

            //Id 
            builder.HasKey(user => user.Id);         

            //nome do produto
            builder.Property(user => user.Nome)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(user => user.Nome)
                .IsUnique();

            //senha           
            builder.Property(user => user.Senha)
                .IsRequired();
        }
    }
}
