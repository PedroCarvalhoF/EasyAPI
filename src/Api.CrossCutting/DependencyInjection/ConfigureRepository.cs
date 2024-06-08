using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Domain.Interfaces.Services.Identity;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Api.Identity.Context;
using Api.Identity.Interfaces;
using Api.Identity.Services;
using Api.Service.Services.CategoriaPreco;
using Api.Service.Services.CategoriaProduto;
using Api.Service.Services.Pedido;
using Api.Service.Services.PontoVendaService;
using Api.Service.Services.PrecoProduto;
using Data.Implementations;
using Data.Implementations.FormaPagamento;
using Data.Implementations.Pedido;
using Data.Implementations.PedidoItem;
using Data.Implementations.PedidoPagamento;
using Data.Implementations.PedidoSituacao;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Data.Implementations.PontoVenda;
using Data.Implementations.PontoVendaPeriodo;
using Data.Implementations.PontoVendaUser;
using Data.Implementations.PrecoCategoria;
using Data.Implementations.PrecoProduto;
using Data.Implementations.Produto;
using Data.Implementations.Produto.ProdutoMedida;
using Data.Implementations.Produto.ProdutoTipo;
using Data.Repository;
using Domain.Identity.UserIdentity;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Pedido;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Domain.Interfaces.Repository.PedidoPagamento;
using Domain.Interfaces.Repository.PedidoSituacao;
using Domain.Interfaces.Repository.Pessoa.Pessoa;
using Domain.Interfaces.Repository.PessoaRepositorys.Pessoa;
using Domain.Interfaces.Repository.PontoVenda;
using Domain.Interfaces.Repository.PontoVendaUser;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Interfaces.Services.HGApis;
using Domain.Interfaces.Services.ItemPedido;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Interfaces.Services.PDF;
using Domain.Interfaces.Services.PedidoSituacao;
using Domain.Interfaces.Services.PeriodoPontoVenda;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Interfaces.Services.PontoVendaUser;
using Domain.Interfaces.Services.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.Interfaces.Services.ViaCEP;
using Identity.Interfaces;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.FormaPagamento;
using Service.Services.HGApis;
using Service.Services.ItemPedidoService;
using Service.Services.PagamentoPedidoServices;
using Service.Services.PDF;
using Service.Services.PedidoSituacao;
using Service.Services.PeriodoPontoVenda;
using Service.Services.Pessoas.Pessoa;
using Service.Services.PontoVendaUser;
using Service.Services.Produto;
using Service.Services.ProdutoMedidaService;
using Service.Services.ProdutoTipoService;
using Service.Services.ViaCEP;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString == "desenvolvimento")
            {
                string? desenvolvimento = "Server=localhost;Port=3306;DataBase=RESET_BANCO;Uid=root;password=010203;";
                serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(desenvolvimento, serverVersion));

                serviceCollection.
                    AddDbContext<IdentityDataContext>(options =>
                                 options.UseMySql(desenvolvimento, serverVersion));
            }
            else
            if (connectionString == "producao_montana_vale_sul")
            {
                string? PRODUCAO_MYSQL_MONTANA_VALE_SUL = "Server=mysql246.umbler.com;Port=41890;DataBase=teste_easy;Uid=admin_teste;password=010203++teste;";

                serviceCollection.
                AddDbContext<MyContext>(options =>
                             options.UseMySql(PRODUCAO_MYSQL_MONTANA_VALE_SUL, serverVersion));

                serviceCollection.
                    AddDbContext<IdentityDataContext>(options =>
                                 options.UseMySql(PRODUCAO_MYSQL_MONTANA_VALE_SUL, serverVersion));
            }


            serviceCollection.AddIdentityCore<User>()
           .AddRoles<Role>()
           .AddRoleManager<RoleManager<Role>>()
           .AddSignInManager<SignInManager<User>>()
           .AddRoleValidator<RoleValidator<Role>>()
           .AddEntityFrameworkStores<IdentityDataContext>()
           .AddDefaultTokenProviders();

            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRole, UserRoleServices>();

            serviceCollection.AddScoped<IPDFRepository, PDFRepository>();

            serviceCollection.AddScoped<IViaCepService, ViaCEPServices>();
            serviceCollection.AddScoped<ITaxasCDISelicService, TaxasCDISelicService>();

            serviceCollection.AddScoped<IUsuarioPontoVendaRepository, UsuarioPontoVendaImplementacao>();
            serviceCollection.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoImplementacao>();
            serviceCollection.AddScoped<ISituacaoPedidoRepository, SituacaoPedidoImplementacao>();
            serviceCollection.AddScoped<IPeriodoPontoVendaRepository, PeriodoPontoVendaImplementecao>();
            serviceCollection.AddScoped<IProdutoTipoRepository, ProdutoTipoImplementacao>();
            serviceCollection.AddScoped<IProdutoMedidaRepository, ProdutoMedidaImplementacao>();
            serviceCollection.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

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

            #region Pessoas

            serviceCollection.AddScoped<IPessoaServices, PessoaServices>();
            serviceCollection.AddScoped<IPessoaRepository, PessoaImplementacao>();

            serviceCollection.AddScoped<IDadosBancariosRepository, DadosBancariosImplementacao>();
            serviceCollection.AddScoped<IDadosBancariosServices, DadosBancariosService>();

            #endregion



        }
    }
}
