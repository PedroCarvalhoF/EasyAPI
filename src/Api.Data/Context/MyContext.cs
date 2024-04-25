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
using Domain.Entities.PontoVendaPeriodoVenda;
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
        public DbSet<ProdutoMedidaEntity>? ProdutosMedidas { get; set; }
        public DbSet<ProdutoEntity>? Produtos { get; set; }
        public DbSet<PeriodoPontoVendaEntity>? PeriodosPontosVendas { get; set; }
        public DbSet<CategoriaPrecoEntity>? CategoriasPrecos { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaProdutoEntity>(new CategoriaProdutoMap().Configure);
            modelBuilder.Entity<ProdutoTipoEntity>(new ProdutoTipoMap().Configure);
            modelBuilder.Entity<ProdutoEntity>(new ProdutoMap().Configure);
            modelBuilder.Entity<PeriodoPontoVendaEntity>(new PeriodoPontoVendaMap().Configure);

            modelBuilder.Entity<CategoriaPrecoEntity>(new CategoriaPrecoMap().Configure);
           

        }

    }
}
