using Api.Domain.Entities.PontoVenda;
using Domain.Identity.UserIdentity;
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

            modelBuilder.Entity<PontoVendaEntity>()
             .HasOne(pdv => pdv.UserPdvCreate)
             .WithMany(perfil => perfil.UserPontoVendaCreate)
             .HasForeignKey(pdv => pdv.UserPdvCreateId)
             .OnDelete(DeleteBehavior.Restrict);


            //PerfilUsuarioEntityUtilizarPDV
            modelBuilder.Entity<PontoVendaEntity>()
                .Property(pdv => pdv.UserPdvUsingId)
                .IsRequired();

            modelBuilder.Entity<PontoVendaEntity>().HasOne(pdv => pdv.UserPdvUsing)
                .WithMany(perfil => perfil.UserPontoVendaUsing)
                .HasForeignKey(pdv => pdv.UserPdvUsingId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
