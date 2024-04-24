using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriasPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoCategoria = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeFilial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormaPagamentoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoFormaPg = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentoEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaTipoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoPessoaTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTipoEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PontoVendaEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserIdCreatePdv = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserIdResponsavel = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PeriodoPontoVendaEnum = table.Column<int>(type: "int", nullable: false),
                    AbertoFechado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAlteracaoEncerrado = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoVendaEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoMedidasEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoMedidasEntities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoTipoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoTipoProduto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoTipoEntity", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SituacaoPedidoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DescricaoSituacaoPedido = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoPedidoEntity", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PrimeiroNome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SegundoNome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RgIE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CpfCnpj = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sexo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimentoFundacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PessoaTipoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaEntities_PessoaTipoEntities_PessoaTipoEntityId",
                        column: x => x.PessoaTipoEntityId,
                        principalTable: "PessoaTipoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeProduto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarrasPersonalizado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoMedidaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoTipoEntityId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                        name: "FK_Produtos_ProdutoMedidasEntities_ProdutoMedidaEntityId",
                        column: x => x.ProdutoMedidaEntityId,
                        principalTable: "ProdutoMedidasEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_ProdutoTipoEntity_ProdutoTipoEntityId",
                        column: x => x.ProdutoTipoEntityId,
                        principalTable: "ProdutoTipoEntity",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroPedido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalItensPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SituacaoPedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserIdCreatePedido = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PontoVendaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPrecoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_PontoVendaEntities_PontoVendaEntityId",
                        column: x => x.PontoVendaEntityId,
                        principalTable: "PontoVendaEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_SituacaoPedidoEntity_SituacaoPedidoEntityId",
                        column: x => x.SituacaoPedidoEntityId,
                        principalTable: "SituacaoPedidoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrecoProdutoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPrecoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoProdutoEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecoProdutoEntities_CategoriasPrecos_CategoriaPrecoEntityId",
                        column: x => x.CategoriaPrecoEntityId,
                        principalTable: "CategoriasPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecoProdutoEntities_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemPedidoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quatidade = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObservacaoItem = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SituacaoItemPedidoEnum = table.Column<int>(type: "int", nullable: false),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioRestroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedidoEntities_Pedidos_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoEntities_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagamentoPedidoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FormaPagamentoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoPedidoEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoPedidoEntities_FormaPagamentoEntities_FormaPagament~",
                        column: x => x.FormaPagamentoEntityId,
                        principalTable: "FormaPagamentoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoPedidoEntities_Pedidos_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("060645d4-f4e3-4163-995c-98869d974aa9"), new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9921), "Executivos", true, null },
                    { new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"), new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9838), "Bebidas", true, null },
                    { new Guid("9fb6ab8f-5aa1-4d93-a07c-ae0dcc60bdd3"), new DateTime(2024, 4, 20, 13, 47, 49, 932, DateTimeKind.Local).AddTicks(9886), "Promoções", true, null }
                });

            migrationBuilder.InsertData(
                table: "FormaPagamentoEntities",
                columns: new[] { "Id", "CreateAt", "DescricaoFormaPg", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("18e68a14-54b5-44b6-87ed-e8b0258d9c1d"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(513), "DÉBITO", true, null },
                    { new Guid("249c0c31-ee8e-487b-b4c9-1f14ced84553"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(509), "DINHEIRO", true, null },
                    { new Guid("46152359-216e-4b2e-827c-411092ecc423"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(524), "TICKT ELETRON", true, null },
                    { new Guid("7aaecde9-7290-48e7-bf31-f8dab886381f"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(535), "IFOOD", true, null },
                    { new Guid("935f9721-bcc2-4239-88a1-2e0c9b1a75f6"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(529), "AMEX", true, null },
                    { new Guid("ac336bfb-39eb-4da0-9b04-c159f0068676"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(518), "CRÉDITO", true, null },
                    { new Guid("cdd1b70b-5c96-472e-a983-3abdcc318c53"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(527), "VR", true, null },
                    { new Guid("d276bcd0-e552-46d4-af7a-390a3af0eb37"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(521), "SODEXO", true, null },
                    { new Guid("e93ceba1-40f8-4420-8dc3-bb1b3ee6ee9f"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(532), "VALE SHOPPING", true, null }
                });

            migrationBuilder.InsertData(
                table: "PessoaTipoEntities",
                columns: new[] { "Id", "CreateAt", "DescricaoPessoaTipo", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("2cc73259-4063-4f20-9c21-34ff2a9cbd58"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(600), "JURÍDICA", true, null },
                    { new Guid("a58b678c-07d4-417b-929b-600dc63858ea"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(592), "FÍSICA", true, null }
                });

            migrationBuilder.InsertData(
                table: "ProdutoMedidasEntities",
                columns: new[] { "Id", "CreateAt", "Descricao", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(646), "Unidade", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(647) },
                    { new Guid("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(643), "Caixa", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(643) },
                    { new Guid("cc8119c5-7651-4708-bba4-8f350726bdac"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(638), "Litro", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(639) }
                });

            migrationBuilder.InsertData(
                table: "ProdutoTipoEntity",
                columns: new[] { "Id", "CreateAt", "DescricaoTipoProduto", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("2491c7e2-10ec-48a4-8898-44e24814f23d"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(690), "Venda", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(691) },
                    { new Guid("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(696), "Materia Prima", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(696) },
                    { new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(700), "Ambos", true, new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(700) }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaProdutoEntityId", "CodigoBarrasPersonalizado", "CreateAt", "Descricao", "Habilitado", "ImgUrl", "NomeProduto", "Observacoes", "ProdutoMedidaEntityId", "ProdutoTipoEntityId", "UpdateAt" },
                values: new object[] { new Guid("d2a0c172-e742-4e54-a806-938ddaaf8edb"), new Guid("6fb282e9-6ee8-44d9-a049-994f68bd0b27"), "agua", new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(445), "agua zero sódio", true, "agua.jpg", "Agua sem Gás", "Vendida com ou sem gelo", new Guid("05b3382d-0940-446a-8c2c-3e27293cf77d"), new Guid("59de4011-1ca7-4a52-833c-9672a03320ac"), new DateTime(2024, 4, 20, 13, 47, 49, 933, DateTimeKind.Local).AddTicks(462) });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoEntities_PedidoEntityId",
                table: "ItemPedidoEntities",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoEntities_ProdutoEntityId",
                table: "ItemPedidoEntities",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoPedidoEntities_FormaPagamentoEntityId",
                table: "PagamentoPedidoEntities",
                column: "FormaPagamentoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoPedidoEntities_PedidoEntityId",
                table: "PagamentoPedidoEntities",
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
                name: "IX_PessoaEntities_PessoaTipoEntityId",
                table: "PessoaEntities",
                column: "PessoaTipoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProdutoEntities_CategoriaPrecoEntityId",
                table: "PrecoProdutoEntities",
                column: "CategoriaPrecoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProdutoEntities_ProdutoEntityId",
                table: "PrecoProdutoEntities",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaProdutoEntityId",
                table: "Produtos",
                column: "CategoriaProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoMedidaEntityId",
                table: "Produtos",
                column: "ProdutoMedidaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoTipoEntityId",
                table: "Produtos",
                column: "ProdutoTipoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filias");

            migrationBuilder.DropTable(
                name: "ItemPedidoEntities");

            migrationBuilder.DropTable(
                name: "PagamentoPedidoEntities");

            migrationBuilder.DropTable(
                name: "PessoaEntities");

            migrationBuilder.DropTable(
                name: "PrecoProdutoEntities");

            migrationBuilder.DropTable(
                name: "FormaPagamentoEntities");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "PessoaTipoEntities");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "CategoriasPrecos");

            migrationBuilder.DropTable(
                name: "PontoVendaEntities");

            migrationBuilder.DropTable(
                name: "SituacaoPedidoEntity");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropTable(
                name: "ProdutoMedidasEntities");

            migrationBuilder.DropTable(
                name: "ProdutoTipoEntity");
        }
    }
}
