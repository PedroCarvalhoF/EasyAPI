using Api.Data.Mapping;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Data.Mapping;
using Data.Mapping.Pedido;
using Data.Mapping.PedidoFormaPagamento;
using Data.Mapping.PedidoPagamento;
using Data.Mapping.PedidoSituacao;
using Data.Mapping.Pessoa;
using Data.Mapping.PontoVena;
using Data.Mapping.PontoVendaPeriodo;
using Data.Mapping.PontoVendaUser;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.FormaPagamento;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.PedidoSituacao;
using Domain.Entities.Pessoa.PessoaFuncionario;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;

namespace Api.Data.Context
{
    public class MyContext : IdentityDbContext<User,
                                               Role,
                                               Guid,
                                               IdentityUserClaim<Guid>,
                                               UserRole,
                                               IdentityUserLogin<Guid>,
                                               IdentityRoleClaim<Guid>,
                                               IdentityUserToken<Guid>>
    {
        public DbSet<CategoriaProdutoEntity>? CategoriasProdutos { get; set; }
        public DbSet<ProdutoTipoEntity>? TiposProdutos { get; set; }
        public DbSet<ProdutoMedidaEntity>? ProdutosMedidas { get; set; }
        public DbSet<ProdutoEntity>? Produtos { get; set; }
        public DbSet<PeriodoPontoVendaEntity>? PeriodosPontosVendas { get; set; }
        public DbSet<CategoriaPrecoEntity>? CategoriasPrecos { get; set; }
        public DbSet<CategoriaPrecoEntity>? PrecosProdutos { get; set; }
        public DbSet<PontoVendaEntity>? PontosVendas { get; set; }
        public DbSet<FormaPagamentoEntity>? FormasPagamentos { get; set; }
        public DbSet<SituacaoPedidoEntity>? SituacoesPedidos { get; set; }
        public DbSet<PedidoEntity>? Pedidos { get; set; }
        public DbSet<PagamentoPedidoEntity>? PagamentosPedidos { get; set; }
        public DbSet<ItemPedidoEntity>? ItensPedidos { get; set; }
        public DbSet<UsuarioPontoVendaEntity>? UsuariosPontoVendas { get; set; }


        #region Pessoas
        public DbSet<PessoaEntity>? Pessoas { get; set; }
        public DbSet<DadosBancariosEntity>? DadosBancarios { get; set; }
        public DbSet<PessoaDadosBancariosEntity>? PessoasDadosBancarios { get; set; }

        #endregion

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir nomes de tabela únicos
            modelBuilder.Entity<PessoaEntity>().ToTable("Pessoas");
            modelBuilder.Entity<DadosBancariosEntity>().ToTable("DadosBancarios");
            modelBuilder.Entity<PessoaDadosBancariosEntity>().ToTable("PessoaDadosBancarios");

            // Configurar a chave composta para PessoaDadosBancariosEntity
            modelBuilder.Entity<PessoaDadosBancariosEntity>()
                .HasKey(pd => new { pd.PessoaEntityId, pd.DadosBancariosEntityId });

            // Configurar o relacionamento entre PessoaEntity e PessoaDadosBancariosEntity
            modelBuilder.Entity<PessoaDadosBancariosEntity>()
                .HasOne(pd => pd.PessoaEntity)
                .WithMany(p => p.PessoaDadosBancarios)
                .HasForeignKey(pd => pd.PessoaEntityId);

            // Configurar o relacionamento entre DadosBancariosEntity e PessoaDadosBancariosEntity
            modelBuilder.Entity<PessoaDadosBancariosEntity>()
                .HasOne(pd => pd.DadosBancariosEntity)
                .WithMany(d => d.PessoaDadosBancarios)
                .HasForeignKey(pd => pd.DadosBancariosEntityId);

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

            modelBuilder.Entity<CategoriaProdutoEntity>(new CategoriaProdutoMap().Configure);
            modelBuilder.Entity<ProdutoTipoEntity>(new ProdutoTipoMap().Configure);
            modelBuilder.Entity<ProdutoMedidaEntity>(new ProdutoMedidaMap().Configure);
            modelBuilder.Entity<ProdutoEntity>(new ProdutoMap().Configure);
            modelBuilder.Entity<PeriodoPontoVendaEntity>(new PeriodoPontoVendaMap().Configure);
            modelBuilder.Entity<CategoriaPrecoEntity>(new CategoriaPrecoMap().Configure);
            modelBuilder.Entity<PrecoProdutoEntity>(new PrecoProdutoMap().Configure);
            modelBuilder.Entity<PontoVendaEntity>(new PontoVendaMap().Configure);
            modelBuilder.Entity<FormaPagamentoEntity>(new FormaPagamentoMap().Configure);
            modelBuilder.Entity<SituacaoPedidoEntity>(new SituacaoPedidoMap().Configure);
            modelBuilder.Entity<PedidoEntity>(new PedidoMap().Configure);
            modelBuilder.Entity<PagamentoPedidoEntity>(new PagamentoPedidoMap().Configure);
            modelBuilder.Entity<UsuarioPontoVendaEntity>(new UsuarioPontoVendaMap().Configure);

           
        }
    }
}
