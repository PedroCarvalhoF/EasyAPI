using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class corrigBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedidoEntity");

            migrationBuilder.DropTable(
                name: "PagamentoPedidoEntity");

            migrationBuilder.DropTable(
                name: "PedidoEntity");

            migrationBuilder.RenameColumn(
                name: "DescricaoSituacaoPedido",
                table: "SituacoesPedidos",
                newName: "DescricaoSituacao");

            migrationBuilder.RenameIndex(
                name: "IX_SituacoesPedidos_DescricaoSituacaoPedido",
                table: "SituacoesPedidos",
                newName: "IX_SituacoesPedidos_DescricaoSituacao");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3010), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3012), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(3943), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(3935) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(3964), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2243), new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2212), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2221), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2218), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(1509), new DateTime(2024, 5, 1, 21, 25, 14, 621, DateTimeKind.Local).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(5605), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(5597), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(5596) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2827), new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2824), new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2817), new DateTime(2024, 5, 1, 21, 25, 14, 624, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(4819), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(4812), new DateTime(2024, 5, 2, 0, 25, 14, 620, DateTimeKind.Utc).AddTicks(4817) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescricaoSituacao",
                table: "SituacoesPedidos",
                newName: "DescricaoSituacaoPedido");

            migrationBuilder.RenameIndex(
                name: "IX_SituacoesPedidos_DescricaoSituacao",
                table: "SituacoesPedidos",
                newName: "IX_SituacoesPedidos_DescricaoSituacaoPedido");

            migrationBuilder.CreateTable(
                name: "PedidoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaPrecoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PontoVendaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SituacaoPedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumeroPedido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalItensPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserIdCreatePedido = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoEntity_CategoriasPrecos_CategoriaPrecoEntityId",
                        column: x => x.CategoriaPrecoEntityId,
                        principalTable: "CategoriasPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoEntity_PontosVendas_PontoVendaEntityId",
                        column: x => x.PontoVendaEntityId,
                        principalTable: "PontosVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoEntity_SituacoesPedidos_SituacaoPedidoEntityId",
                        column: x => x.SituacaoPedidoEntityId,
                        principalTable: "SituacoesPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemPedidoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PerfilUsuarioEntityRegistroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObservacaoItem = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quatidade = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    SubTtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedidoEntity_PedidoEntity_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "PedidoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoEntity_PerfisUsuarios_PerfilUsuarioEntityRegistroId",
                        column: x => x.PerfilUsuarioEntityRegistroId,
                        principalTable: "PerfisUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidoEntity_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagamentoPedidoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FormaPagamentoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoPedidoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoPedidoEntity_FormasPagamentos_FormaPagamentoEntityId",
                        column: x => x.FormaPagamentoEntityId,
                        principalTable: "FormasPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoPedidoEntity_PedidoEntity_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "PedidoEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8304), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8292), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8309), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(3594), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(3589) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(3628), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(6958), new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(6998) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7102), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7120), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7116), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7111), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(5746), new DateTime(2024, 5, 1, 21, 1, 46, 50, DateTimeKind.Local).AddTicks(5762) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(6684), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(6675), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7572), new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7569), new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7563), new DateTime(2024, 5, 1, 21, 1, 46, 54, DateTimeKind.Local).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(5304), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(5306) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(5294), new DateTime(2024, 5, 2, 0, 1, 46, 49, DateTimeKind.Utc).AddTicks(5302) });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoEntity_PedidoEntityId",
                table: "ItemPedidoEntity",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoEntity_PerfilUsuarioEntityRegistroId",
                table: "ItemPedidoEntity",
                column: "PerfilUsuarioEntityRegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidoEntity_ProdutoEntityId",
                table: "ItemPedidoEntity",
                column: "ProdutoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoPedidoEntity_FormaPagamentoEntityId",
                table: "PagamentoPedidoEntity",
                column: "FormaPagamentoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoPedidoEntity_PedidoEntityId",
                table: "PagamentoPedidoEntity",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoEntity_CategoriaPrecoEntityId",
                table: "PedidoEntity",
                column: "CategoriaPrecoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoEntity_PontoVendaEntityId",
                table: "PedidoEntity",
                column: "PontoVendaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoEntity_SituacaoPedidoEntityId",
                table: "PedidoEntity",
                column: "SituacaoPedidoEntityId");
        }
    }
}
