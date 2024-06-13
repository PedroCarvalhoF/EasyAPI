#region Usings
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
using Data.Mapping.Pessoa.Funcionario.CTPS;
using Data.Mapping.Pessoa.Funcionario.Funcao;
using Data.Mapping.Pessoa.PessoContato;
using Data.Mapping.PontoVena;
using Data.Mapping.PontoVendaPeriodo;
using Data.Mapping.PontoVendaUser;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.FormaPagamento;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.PedidoSituacao;
using Domain.Entities.Pessoa;
using Domain.Entities.Pessoa.Contato;
using Domain.Entities.Pessoa.DadosBancarios;
using Domain.Entities.Pessoa.Endereco;
using Domain.Entities.Pessoa.Funcionario.CTPS;
using Domain.Entities.Pessoa.Funcionario.Funcao;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Entities.Pessoa.PessoaDadosBancarios;
using Domain.Entities.Pessoa.PessoaEndereco;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.Entities.TesteEntidade;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Api.Data.Context
{
    public class MyContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        #region Produtos
        public DbSet<ProdutoTipoEntity>? TiposProdutos { get; set; }
        public DbSet<CategoriaProdutoEntity>? CategoriasProdutos { get; set; }
        public DbSet<ProdutoMedidaEntity>? ProdutosMedidas { get; set; }
        public DbSet<ProdutoEntity>? Produtos { get; set; }

        #region Precos Produtos
        public DbSet<CategoriaPrecoEntity>? CategoriasPrecos { get; set; }
        public DbSet<CategoriaPrecoEntity>? PrecosProdutos { get; set; }
        #endregion
        #endregion
        #region Ponto de Venda
        public DbSet<PeriodoPontoVendaEntity>? PeriodosPontosVendas { get; set; }
        public DbSet<PontoVendaEntity>? PontosVendas { get; set; }
        public DbSet<FormaPagamentoEntity>? FormasPagamentos { get; set; }
        public DbSet<SituacaoPedidoEntity>? SituacoesPedidos { get; set; }
        public DbSet<PedidoEntity>? Pedidos { get; set; }
        public DbSet<PagamentoPedidoEntity>? PagamentosPedidos { get; set; }
        public DbSet<ItemPedidoEntity>? ItensPedidos { get; set; }
        public DbSet<UsuarioPontoVendaEntity>? UsuariosPontoVendas { get; set; }
        #endregion
        #region Pessoas
        public DbSet<PessoaEntity>? Pessoas { get; set; }
        public DbSet<DadosBancariosEntity>? DadosBancarios { get; set; }
        public DbSet<PessoaDadosBancariosEntity>? PessoaDadosBancarios { get; set; }
        public DbSet<EnderecoEntity>? Enderecos { get; set; }
        public DbSet<PessoaEnderecoEntity>? PessoaEnderecos { get; set; }
        public DbSet<ContatoEntity>? Contatos { get; set; }
        public DbSet<PessoaContatoEntity>? PessoaContatos { get; set; }
        public DbSet<FuncaoFuncionarioEntity>? FuncoesFuncionarios { get; set; }
        public DbSet<CtpsEntity>? Ctpss { get; set; }
        #endregion


        public DbSet<EntidadeTeste>? EntidadeTestes { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<PessoaEntity>().ToTable("Pessoas");
            modelBuilder.Entity<DadosBancariosEntity>().ToTable("DadosBancarios");
            modelBuilder.Entity<PessoaDadosBancariosEntity>().ToTable("PessoaDadosBancarios");
            modelBuilder.Entity<EnderecoEntity>().ToTable("Enderecos");
            modelBuilder.Entity<PessoaEnderecoEntity>().ToTable("PessoaEnderecos");
            modelBuilder.Entity<ContatoEntity>().ToTable("Contatos");
            modelBuilder.Entity<PessoaContatoEntity>().ToTable("PessoaContatos");
            modelBuilder.Entity<FuncaoFuncionarioEntity>().ToTable("FuncoesFuncionarios");

            #region Pessoa Dados Bancario

            modelBuilder.Entity<PessoaEntity>()
                .HasKey(p => p.Id);


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
            #endregion
            #region Pessoa Endereco

            modelBuilder.Entity<PessoaEnderecoEntity>()
                .HasKey(pEnd => new { pEnd.PessoaEntityId, pEnd.EnderecoEntityId });

            //configurar o relacionamento entre PessoaEntity com PessoaEnderecoEntity
            modelBuilder.Entity<PessoaEnderecoEntity>()
                .HasOne(ps => ps.PessoaEntity)
                .WithMany(p => p.PessoaEnderecos)
                .HasForeignKey(p => p.PessoaEntityId);

            //configurar o relacionamento entre Endereco com PessoaEnderecoEntity
            modelBuilder.Entity<PessoaEnderecoEntity>()
                .HasOne(p => p.EnderecoEntity)
                .WithMany(p => p.PessoaEnderecos)
                .HasForeignKey(p => p.EnderecoEntityId);

            #endregion

            modelBuilder.Entity<PessoaContatoEntity>(new PessoaContatoMap().Configure);
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
            modelBuilder.Entity<FuncaoFuncionarioEntity>(new FuncaoFuncionarioMap().Configure);
            modelBuilder.Entity<CtpsEntity>(new CtpsMap().Configure);


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
