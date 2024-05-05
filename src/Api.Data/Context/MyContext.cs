using Api.Data.Mapping;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Data.Mapping;
using Data.Mapping.Pedido;
using Data.Mapping.PedidoFormaPagamento;
using Data.Mapping.PedidoSituacao;
using Data.Mapping.PerfilUsuario;
using Data.Mapping.PontoVena;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.FormaPagamento;
using Domain.Entities.PedidoSituacao;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Domain.Entities.UsuarioSistema;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        //revisados
        public DbSet<CategoriaProdutoEntity>? CategoriasProdutos { get; set; }
        public DbSet<ProdutoTipoEntity>? TiposProdutos { get; set; }
        public DbSet<ProdutoMedidaEntity>? ProdutosMedidas { get; set; }
        public DbSet<ProdutoEntity>? Produtos { get; set; }
        public DbSet<PeriodoPontoVendaEntity>? PeriodosPontosVendas { get; set; }
        public DbSet<CategoriaPrecoEntity>? CategoriasPrecos { get; set; }
        public DbSet<CategoriaPrecoEntity>? PrecosProdutos { get; set; }
        public DbSet<PerfilUsuarioEntity>? PerfisUsuarios { get; set; }
        public DbSet<PontoVendaEntity> PontosVendas { get; set; }
        public DbSet<FormaPagamentoEntity> FormasPagamentos { get; set; }
        public DbSet<SituacaoPedidoEntity> SituacoesPedidos { get; set; }
        public DbSet<PedidoEntity> Pedidos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaProdutoEntity>(new CategoriaProdutoMap().Configure);
            modelBuilder.Entity<ProdutoTipoEntity>(new ProdutoTipoMap().Configure);
            modelBuilder.Entity<ProdutoMedidaEntity>(new ProdutoMedidaMap().Configure);
            modelBuilder.Entity<ProdutoEntity>(new ProdutoMap().Configure);
            modelBuilder.Entity<PeriodoPontoVendaEntity>(new PeriodoPontoVendaMap().Configure);
            modelBuilder.Entity<CategoriaPrecoEntity>(new CategoriaPrecoMap().Configure);
            modelBuilder.Entity<PrecoProdutoEntity>(new PrecoProdutoMap().Configure);
            modelBuilder.Entity<PerfilUsuarioEntity>(new PerfilUsuarioMap().Configure);
            modelBuilder.Entity<PontoVendaEntity>(new PontoVendaMap().Configure);
            modelBuilder.Entity<FormaPagamentoEntity>(new FormaPagamentoMap().Configure);
            modelBuilder.Entity<SituacaoPedidoEntity>(new SituacaoPedidoMap().Configure);
            modelBuilder.Entity<PedidoEntity>(new PedidoMap().Configure);
        }

    }
}
