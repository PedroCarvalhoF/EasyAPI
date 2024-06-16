#region Using
using Api.Data.Repository;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Domain.Interfaces.Services.Identity;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Api.Identity.Interfaces;
using Api.Identity.Services;
using Api.Service.Services.CategoriaPreco;
using Api.Service.Services.CategoriaProduto;
using Api.Service.Services.Pedido;
using Api.Service.Services.PontoVendaService;
using Api.Service.Services.PrecoProduto;
using Application.UseCases.Handlers.PontoVenda.Periodo;
using CrossCutting.DependencyInjection.Extensions;
using Data.Implementations;
using Data.Implementations.FormaPagamento;
using Data.Implementations.Pedido;
using Data.Implementations.PedidoItem;
using Data.Implementations.PedidoPagamento;
using Data.Implementations.PedidoSituacao;
using Data.Implementations.PontoVenda;
using Data.Implementations.PontoVenda.Periodo;
using Data.Implementations.PontoVendaUser;
using Data.Implementations.PrecoCategoria;
using Data.Implementations.PrecoProduto;
using Data.Implementations.Produto;
using Data.Implementations.Produto.ProdutoMedida;
using Data.Implementations.Produto.ProdutoTipo;
using Data.Implementations.UserMasterCliente;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Pedido;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.Interfaces.Repository.PedidoPagamento;
using Domain.Interfaces.Repository.PedidoSituacao;
using Domain.Interfaces.Repository.PontoVenda;
using Domain.Interfaces.Repository.PontoVendaUser;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Interfaces.Services.PDF;
using Domain.Interfaces.Services.PedidoSituacao;
using Domain.Interfaces.Services.PeriodoPontoVenda;
using Domain.Interfaces.Services.PontoVendaUser;
using Domain.Interfaces.Services.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.Interfaces.Services.UserMasterCliente;
using Identity.Interfaces;
using Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.FormaPagamento;
using Service.Services.ItemPedidoService;
using Service.Services.PagamentoPedidoServices;
using Service.Services.PDF;
using Service.Services.PedidoSituacao;
using Service.Services.PeriodoPontoVenda;
using Service.Services.PontoVendaUser;
using Service.Services.Produto;
using Service.Services.ProdutoMedidaService;
using Service.Services.ProdutoTipoService;
using Service.Services.UserMaster;


#endregion
namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            ConfiguracaoExternas.Configure(serviceCollection);
            ConfiguracaoBancoDados.Configurar(serviceCollection, configuration);
            ConfiguracaoIQuery.Configurar(serviceCollection);
            ConfiguracaoPessoas.Pessoas(serviceCollection);

            serviceCollection.AddTransient<PeriodoPontoVendaServiceHandler>();



            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRole, UserRoleServices>();
            serviceCollection.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            serviceCollection.AddTransient<IUserMasterClienteServices, UserMasterClienteServices>();
            serviceCollection.AddTransient<IUserMasterClienteRepository, UserMasterClienteImplementacao>();

            serviceCollection.AddScoped<IPDFRepository, PDFRepository>();

            serviceCollection.AddScoped<IUsuarioPontoVendaRepository, UsuarioPontoVendaImplementacao>();
            serviceCollection.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoImplementacao>();
            serviceCollection.AddScoped<ISituacaoPedidoRepository, SituacaoPedidoImplementacao>();
            serviceCollection.AddScoped<IPeriodoPontoVendaRepository, PeriodoPontoVendaImplementecao>();
            serviceCollection.AddScoped<IProdutoTipoRepository, ProdutoTipoImplementacao>();
            serviceCollection.AddScoped<IProdutoMedidaRepository, ProdutoMedidaImplementacao>();
            serviceCollection.AddScoped<IProdutoRepository, ProdutoImplementation>();
            serviceCollection.AddScoped<IPrecoProdutoRepository, PrecoProdutoImplementacao>();
            serviceCollection.AddScoped<IPedidoRepository, PedidoImplementacao>();
            serviceCollection.AddScoped<IPontoVendaRepository, PontoVendaImplementacao>();
            serviceCollection.AddScoped<ICategoriaPrecoRepository, CategoriaPrecoImplementacao>();
            serviceCollection.AddScoped<IFormaPagamentoRepository, FormaPagamentoImplementacao>();
            serviceCollection.AddScoped<IPagamentoPedidoRepository, PagamentoPedidoImplementacao>();
            serviceCollection.AddScoped<IItemPedidoRepository, ItemPedidoImplementacao>();

            serviceCollection.AddScoped<IItemPedidoService, ItemPedidoService>();
            serviceCollection.AddScoped<IPontoVendaService, PontoVendaService>();
            serviceCollection.AddScoped<IPedidoService, PedidoService>();
            serviceCollection.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped<ICategoriaPrecoService, CategoriaPrecoService>();
            serviceCollection.AddScoped<IPrecoProdutoService, PrecoProdutoService>();
            serviceCollection.AddScoped<IFormaPagamentoService, FormaPagamentoService>();
            serviceCollection.AddScoped<IPagamentoPedidoService, PagamentoPedidoService>();
            serviceCollection.AddScoped<IProdutoMedidaServices, ProdutoMedidaService>();
            serviceCollection.AddScoped<IProdutoTipoServices, ProdutoTipoServices>();
            serviceCollection.AddScoped<IPeriodoPontoVendaService, PeriodoPontoVendaServices>();
            serviceCollection.AddScoped<ISituacaoPedidoService, SituacaoPedidoService>();
            serviceCollection.AddScoped<IUsuarioPontoVendaService, UsuarioPontoVendaService>();
        }
    }
}
