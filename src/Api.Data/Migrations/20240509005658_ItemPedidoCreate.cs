using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemPedidoCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PerfilUsuarioEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PedidoEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoEntityId",
                        column: x => x.PedidoEntityId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_PerfisUsuarios_PerfilUsuarioEntityId",
                        column: x => x.PerfilUsuarioEntityId,
                        principalTable: "PerfisUsuarios",
                        principalColumn: "IdentityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_ProdutoEntityId",
                        column: x => x.ProdutoEntityId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(152), new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(155) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(134), new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(157), new DateTime(2024, 5, 8, 21, 56, 57, 677, DateTimeKind.Local).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(1282), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(1276) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(1318), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(5668), new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(5717) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8801), new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8808) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8819), new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8821) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8815), new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8817) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8812), new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(8813) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(7413), new DateTime(2024, 5, 8, 21, 56, 57, 676, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(4732), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(4717), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7047), new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7043), new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 5, 8, 21, 56, 57, 685, DateTimeKind.Local).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(3266), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(3269) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(3251), new DateTime(2024, 5, 9, 0, 56, 57, 675, DateTimeKind.Utc).AddTicks(3264) });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoEntityId",
                table: "ItensPedidos",
                column: "PedidoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PerfilUsuarioEntityId",
                table: "ItensPedidos",
                column: "PerfilUsuarioEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoEntityId",
                table: "ItensPedidos",
                column: "ProdutoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6208), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6193), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6205) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(6215) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 979, DateTimeKind.Utc).AddTicks(9488), new DateTime(2024, 5, 4, 20, 3, 3, 979, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 979, DateTimeKind.Utc).AddTicks(9514), new DateTime(2024, 5, 4, 20, 3, 3, 979, DateTimeKind.Utc).AddTicks(9513) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(173), new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4668), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4688), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4690) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4684), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4680), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(4681) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(3323), new DateTime(2024, 5, 4, 17, 3, 3, 981, DateTimeKind.Local).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(2304), new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(2295), new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1292), new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1287), new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1278), new DateTime(2024, 5, 4, 17, 3, 3, 987, DateTimeKind.Local).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(1252), new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(1240), new DateTime(2024, 5, 4, 20, 3, 3, 980, DateTimeKind.Utc).AddTicks(1250) });
        }
    }
}
