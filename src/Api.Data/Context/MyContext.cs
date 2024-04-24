using Api.Data.Mapping;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.Pessoa.PessoaTipo;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Data.Mapping;
using Data.Seeds;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.Filial;
using Domain.Entities.FormaPagamento;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.Pedido;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        //revisados
        public DbSet<CategoriaProdutoEntity>? CategoriasProdutos { get; set; }
        public DbSet<ProdutoTipoEntity>? TiposProdutos { get; set; }
        public DbSet<ProdutoEntity>? Produtos { get; set; }



        //faltar revisar - desta linha para baixo
        public DbSet<FilialEntity>? Filiais { get; set; }


        public DbSet<PedidoEntity>? Pedidos { get; set; }
        public DbSet<CategoriaPrecoEntity>? CategoriasPrecos { get; set; }
        public DbSet<PrecoProdutoEntity>? PrecosProdutos { get; set; }
        public DbSet<ItemPedidoEntity>? ItensPedidos { get; set; }
        public DbSet<PontoVendaEntity>? PontosVendas { get; set; }
        public DbSet<FormaPagamentoEntity>? FormasPagamentos { get; set; }
        public DbSet<PagamentoPedidoEntity>? PagamentosPedidos { get; set; }
        public DbSet<PessoaTipoEntity>? PessoasTipos { get; set; }
        public DbSet<PessoaEntity>? Pessoas { get; set; }
        public DbSet<ProdutoMedidaEntity>? ProdutosMedidas { get; set; }

        public DbSet<SituacaoPedidoEntity>? SituacoesPedidos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaProdutoEntity>(new CategoriaProdutoMap().Configure);
            modelBuilder.Entity<ProdutoTipoEntity>(new ProdutoTipoMap().Configure);
            modelBuilder.Entity<ProdutoEntity>(new ProdutoMap().Configure);

            //modelBuilder.Entity<PedidoEntity>(new PedidoMap().Configure);
            //modelBuilder.Entity<PrecoProdutoEntity>(new PrecoProdutoMap().Configure);
            //modelBuilder.Entity<FormaPagamentoEntity>(new FormaPagamentoMap().Configure);
            //modelBuilder.Entity<PagamentoPedidoEntity>(new PagamentoPedidoMap().Configure);
            //modelBuilder.Entity<PessoaTipoEntity>(new PessoaTipoMap().Configure);
            //modelBuilder.Entity<PessoaEntity>(new PessoaMap().Configure);
            //modelBuilder.Entity<ProdutoMedidaEntity>(new ProdutoMedidaMap().Configure);

            #region Seeds
            //CategoriaProdutos
            CategoriaProdutoSeeds.CategoriaProduto(modelBuilder);
            ProdutoSeeds.Produto(modelBuilder);
            FormaPagamentoSeeds.FormaPagamento(modelBuilder);
            FormaPagamentoSeeds.PessoaTipo(modelBuilder);
            ProdutoMedidaSeeds.MedidaDoProdutoSeeds(modelBuilder);
            ProdutoTipoSeeds.TipoProdutoSeeds(modelBuilder);

            #endregion

        }

    }
}
