using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.InfrastructureData.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Context;
public class MyContext : IdentityDbContext
    <UserEntity, RoleEntity, Guid, IdentityUserClaim<Guid>, UserRoleEntity, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }
    public DbSet<UserMasterUserEntity> UsersMastersUsers { get; set; }
    public DbSet<UserMasterClienteEntity> UserMasterCliente { get; set; }
    public DbSet<CategoriaProdutoEntity> CategoriasProdutos { get; set; }
    public DbSet<FormaPagamentoEntity> FormasPagamentos { get; set; }
    public DbSet<CategoriaPrecoEntity> CategoriasPrecos { get; set; }
    public DbSet<ProdutoEntity> Produtos { get; set; }
    public DbSet<PrecoProdutoEntity> PrecosProdutos { get; set; }
    public DbSet<UsuarioPdvEntity> UsuariosPdvs { get; set; }
    public DbSet<PeriodoPdvEntity> PeriodosPdvs { get; set; }
    public DbSet<PontoVendaEntity> PontosVendas { get; set; }
    public DbSet<PedidoEntity> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaProdutoMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new FormaPagamentoMap());
        modelBuilder.ApplyConfiguration(new CategoriaPrecoMap());
        modelBuilder.ApplyConfiguration(new PrecoProdutoMap());
        modelBuilder.ApplyConfiguration(new UsuarioPdvMap());
        modelBuilder.ApplyConfiguration(new UsuarioPdvMap());
        modelBuilder.ApplyConfiguration(new PontoVendaMap());
        modelBuilder.ApplyConfiguration(new PedidoMap());

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
