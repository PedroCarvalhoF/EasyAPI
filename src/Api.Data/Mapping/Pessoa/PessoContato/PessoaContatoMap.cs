using Domain.Entities.Pessoa.PessoaContato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa.PessoContato
{
    public class PessoaContatoMap : IEntityTypeConfiguration<PessoaContatoEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaContatoEntity> modelBuilder)
        {
            #region Pessoa Contato
            modelBuilder
                .HasKey(pc => new { pc.PessoaEntityId, pc.ContatoEntityId });

            modelBuilder
                .HasOne(pc => pc.PessoaEntity)
                .WithMany(pessoa => pessoa.PessoaContatos)
                .HasForeignKey(pc => pc.PessoaEntityId);

            modelBuilder
                .HasOne(pc => pc.ContatoEntity)
                .WithMany(contato => contato.PessoaContatos)
                .HasForeignKey(pc => pc.ContatoEntityId);
            #endregion
        }
    }
}
