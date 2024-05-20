using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PagamentoPedidoEntityAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SobreNome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagemURL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoCategoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasPrecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoCategoria = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormasPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoFormaPg = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamentos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PeriodosPontosVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoPeriodo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosPontosVendas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosMedidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosMedidas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SituacoesPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoSituacao = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesPedidos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoTipoProduto = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosPontoVendas",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPontoVendas", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UsuariosPontoVendas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeProduto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarrasPersonalizado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoMedidaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoTipoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_CategoriasProdutos_CategoriaProdutoEntityId",
                        column: x => x.CategoriaProdutoEntityId,
                        principalTable: "CategoriasProdutos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_ProdutosMedidas_ProdutoMedidaEntityId",
                        column: x => x.ProdutoMedidaEntityId,
                        principalTable: "ProdutosMedidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_TiposProdutos_ProdutoTipoEntityId",
                        column: x => x.ProdutoTipoEntityId,
                        principalTable: "TiposProdutos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PontosVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPdvCreateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPdvUsingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PeriodoPontoVendaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AbertoFechado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosVendas_PeriodosPontosVendas_PeriodoPontoVendaEntityId",
                        column: x => x.PeriodoPontoVendaEntityId,
                        principalTable: "PeriodosPontosVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvCreateId",
                        column: x => x.UserPdvCreateId,
                        principalTable: "UsuariosPontoVendas",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontosVendas_UsuariosPontoVendas_UserPdvUsingId",
                        column: x => x.UserPdvUsingId,
                        principalTable: "UsuariosPontoVendas",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrecosProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPrecoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecosProdutos_CategoriasPrecos_CategoriaPrecoEntityId",
                        column: x => x.CategoriaPrecoEntityId,
                        principalTable: "CategoriasPrecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrecosProdutos_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroPedido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SituacaoPedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PontoVendaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPrecoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserRegistroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_CategoriasPrecos_CategoriaPrecoEntityId",
                        column: x => x.CategoriaPrecoEntityId,
                        principalTable: "CategoriasPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_PontosVendas_PontoVendaEntityId",
                        column: x => x.PontoVendaEntityId,
                        principalTable: "PontosVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_SituacoesPedidos_SituacaoPedidoEntityId",
                        column: x => x.SituacaoPedidoEntityId,
                        principalTable: "SituacoesPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_UsuariosPontoVendas_UserRegistroId",
                        column: x => x.UserRegistroId,
                        principalTable: "UsuariosPontoVendas",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quatidade = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObservacaoItem = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioPontoVendaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_UsuariosPontoVendas_UsuarioPontoVendaEntityId",
                        column: x => x.UsuarioPontoVendaEntityId,
                        principalTable: "UsuariosPontoVendas",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagamentosPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FormaPagamentoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentosPedidos_FormasPagamentos_FormaPagamentoEntityId",
                        column: x => x.FormaPagamentoEntityId,
                        principalTable: "FormasPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentosPedidos_Pedidos_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CategoriasPrecos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7924), "IFood", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7925) },
                    { new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7914), "Balcão", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7922) },
                    { new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7927), "Lojista", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(7929) }
                });

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(2930), "Executivos", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(2927) },
                    { new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(2948), "Bebidas", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(2947) }
                });

            migrationBuilder.InsertData(
                table: "FormasPagamentos",
                columns: new[] { "Id", "CreateAt", "DescricaoFormaPg", "Habilitado", "UpdateAt" },
                values: new object[] { new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"), new DateTime(2024, 5, 20, 19, 45, 31, 333, DateTimeKind.Local).AddTicks(9513), "Dinheiro", true, new DateTime(2024, 5, 20, 19, 45, 31, 333, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.InsertData(
                table: "PeriodosPontosVendas",
                columns: new[] { "Id", "CreateAt", "DescricaoPeriodo", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("567906bb-6eb4-42e9-b890-10e6da214766"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6978), "Almoço", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6983) },
                    { new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6992), "Noturno", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6993) },
                    { new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6989), "Dia Todo", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6990) },
                    { new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6985), "Janta", true, new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(6986) }
                });

            migrationBuilder.InsertData(
                table: "ProdutosMedidas",
                columns: new[] { "Id", "CreateAt", "Descricao", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(8079), "Caixa", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(8079) },
                    { new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(8071), "Unidade", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(8068) }
                });

            migrationBuilder.InsertData(
                table: "SituacoesPedidos",
                columns: new[] { "Id", "CreateAt", "DescricaoSituacao", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"), new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(437), "Cancelado", true, new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(438) },
                    { new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"), new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(433), "Fechado", true, new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(434) },
                    { new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"), new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(427), "Aberto", true, new DateTime(2024, 5, 20, 19, 45, 31, 334, DateTimeKind.Local).AddTicks(431) }
                });

            migrationBuilder.InsertData(
                table: "TiposProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoTipoProduto", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(6615), "Materia Prima", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(6621) },
                    { new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"), new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(6593), "Venda", true, new DateTime(2024, 5, 20, 22, 45, 31, 329, DateTimeKind.Utc).AddTicks(6612) }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaProdutoEntityId", "CodigoBarrasPersonalizado", "CreateAt", "Descricao", "Habilitado", "ImgUrl", "NomeProduto", "Observacoes", "ProdutoMedidaEntityId", "ProdutoTipoEntityId", "UpdateAt" },
                values: new object[] { new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"), new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), "01", new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(5499), "", true, "", "Agua sem gas", "", new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"), new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"), new DateTime(2024, 5, 20, 19, 45, 31, 330, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasPrecos_DescricaoCategoria",
                table: "CategoriasPrecos",
                column: "DescricaoCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos",
                column: "DescricaoCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos",
                column: "DescricaoFormaPg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoEntityId",
                table: "ItensPedidos",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoEntityId",
                table: "ItensPedidos",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_UserId",
                table: "ItensPedidos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_UsuarioPontoVendaEntityId",
                table: "ItensPedidos",
                column: "UsuarioPontoVendaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosPedidos_FormaPagamentoEntityId",
                table: "PagamentosPedidos",
                column: "FormaPagamentoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentosPedidos_PedidoEntityId",
                table: "PagamentosPedidos",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CategoriaPrecoEntityId",
                table: "Pedidos",
                column: "CategoriaPrecoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PontoVendaEntityId",
                table: "Pedidos",
                column: "PontoVendaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SituacaoPedidoEntityId",
                table: "Pedidos",
                column: "SituacaoPedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UserRegistroId",
                table: "Pedidos",
                column: "UserRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosPontosVendas_DescricaoPeriodo",
                table: "PeriodosPontosVendas",
                column: "DescricaoPeriodo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_PeriodoPontoVendaEntityId",
                table: "PontosVendas",
                column: "PeriodoPontoVendaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_UserPdvCreateId",
                table: "PontosVendas",
                column: "UserPdvCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_UserPdvUsingId",
                table: "PontosVendas",
                column: "UserPdvUsingId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecosProdutos_CategoriaPrecoEntityId",
                table: "PrecosProdutos",
                column: "CategoriaPrecoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecosProdutos_ProdutoEntityId",
                table: "PrecosProdutos",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaProdutoEntityId",
                table: "Produtos",
                column: "CategoriaProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarrasPersonalizado",
                table: "Produtos",
                column: "CodigoBarrasPersonalizado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NomeProduto",
                table: "Produtos",
                column: "NomeProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoTipoEntityId",
                table: "Produtos",
                column: "ProdutoTipoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosMedidas_Descricao",
                table: "ProdutosMedidas",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SituacoesPedidos_DescricaoSituacao",
                table: "SituacoesPedidos",
                column: "DescricaoSituacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutos_DescricaoTipoProduto",
                table: "TiposProdutos",
                column: "DescricaoTipoProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPontoVendas_UserId",
                table: "UsuariosPontoVendas",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "PagamentosPedidos");

            migrationBuilder.DropTable(
                name: "PrecosProdutos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FormasPagamentos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "CategoriasPrecos");

            migrationBuilder.DropTable(
                name: "PontosVendas");

            migrationBuilder.DropTable(
                name: "SituacoesPedidos");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropTable(
                name: "ProdutosMedidas");

            migrationBuilder.DropTable(
                name: "TiposProdutos");

            migrationBuilder.DropTable(
                name: "PeriodosPontosVendas");

            migrationBuilder.DropTable(
                name: "UsuariosPontoVendas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
