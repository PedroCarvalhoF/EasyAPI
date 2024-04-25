using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Domain.Interfaces.Services.Identity;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Domain.Interfaces.Services.Pessoas.PessoaTipo;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Api.Domain.Repository;
using Api.Identity.Context;
using Api.Identity.Interfaces;
using Api.Identity.Services;
using Api.Service.Services.CategoriaPreco;
using Api.Service.Services.CategoriaProduto;
using Api.Service.Services.Pedido;
using Api.Service.Services.Pessoas.PessoasTipo;
using Api.Service.Services.PontoVendaService;
using Api.Service.Services.PrecoProduto;
using Data.Implementations;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Data.Implementations.Pessoas.PessoasTipoImplementacao;
using Data.Implementations.Produto;
using Domain.Interfaces;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Interfaces.Services.PeriodoPontoVenda;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Interfaces.Services.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.Repository;
using Domain.Repository.PessoaRepositorys.Pessoa;
using Domain.Repository.PessoaRepositorys.PessoaTipo;
using Domain.Repository.Produto;
using Identity.Interfaces;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.FormaPagamento;
using Service.Services.ItemPedidoService;
using Service.Services.PagamentoPedidoServices;
using Service.Services.PeriodoPontoVenda;
using Service.Services.Pessoas.Pessoa;
using Service.Services.Produto;
using Service.Services.ProdutoMedidaService;
using Service.Services.ProdutoTipoService;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(connectionString, serverVersion));

            serviceCollection.
                AddDbContext<IdentityDataContext>(options =>
                             options.UseMySql(connectionString, serverVersion));

            serviceCollection.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

            serviceCollection.AddScoped<IIdentityService, IdentityService>();
            serviceCollection.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


            serviceCollection.AddScoped<IProdutoRepository, ProdutoImplementation>();
            serviceCollection.AddScoped<IPrecoProdutoRepository, PrecoProdutoImplementacao>();
            serviceCollection.AddScoped<IPedidoRepository, PedidoImplementacao>();
            serviceCollection.AddScoped<IPontoVendaRepository, PontoVendaImplementacao>();
            serviceCollection.AddScoped<ICategoriaPrecoRepository, CategoriaPrecoImplementacao>();
            serviceCollection.AddScoped<IItemPedidoRepository, ItemPedidoImplementacao>();
            serviceCollection.AddScoped<IFormaPagamentoRepository, FormaPagamentoImplementacao>();
            serviceCollection.AddScoped<IPagamentoPedidoRepository, PagamentoPedidoImplementacao>();
            serviceCollection.AddScoped<IPessoaTipoRepository, PessoaTipoImplementecao>();
            serviceCollection.AddScoped<IPessoaRepository, PessoaImplementacao>();
            serviceCollection.AddScoped<IProdutoMedidaRepository, ProdutoMedidaImplementacao>();
            serviceCollection.AddScoped<IProdutoTipoRepository, ProdutoTipoImplementacao>();
            serviceCollection.AddScoped<IPeriodoPontoVendaRepository, PeriodoPontoVendaImplementecao>();


            serviceCollection.AddTransient<IPontoVendaService, PontoVendaService>();
            serviceCollection.AddTransient<IPedidoService, PedidoService>();
            serviceCollection.AddTransient<ICategoriaProdutoService, CategoriaProdutoService>();
            serviceCollection.AddTransient<IProdutoService, ProdutoService>();
            serviceCollection.AddTransient<ICategoriaPrecoService, CategoriaPrecoService>();
            serviceCollection.AddTransient<IPrecoProdutoService, PrecoProdutoService>();
            serviceCollection.AddTransient<IItemPedidoService, ItemPedidoService>();
            serviceCollection.AddTransient<IFormaPagamentoService, FormaPagamentoService>();
            serviceCollection.AddTransient<IPagamentoPedidoService, PagamentoPedidoService>();
            serviceCollection.AddTransient<IProdutoMedidaServices, ProdutoMedidaServices>();
            serviceCollection.AddTransient<IProdutoTipoServices, ProdutoTipoServices>();
            serviceCollection.AddTransient<IPeriodoPontoVendaService, PeriodoPontoVendaServices>();



            serviceCollection.AddTransient<IUserRole, UserRole>();
            serviceCollection.AddTransient<IPessoaTipoServices, PessoaTipoServices>();
            serviceCollection.AddTransient<IPessoaServices, PessoaServices>();
        }
    }
}
