using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PedidoEntityCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UserCreatePedidoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                        name: "FK_Pedidos_PerfisUsuarios_UserCreatePedidoId",
                        column: x => x.UserCreatePedidoId,
                        principalTable: "PerfisUsuarios",
                        principalColumn: "IdentityId",
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_Pedidos_UserCreatePedidoId",
                table: "Pedidos",
                column: "UserCreatePedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7549), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7540), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7552), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4517), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4546), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7012), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6731), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6745), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6742), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6739), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(5824), new DateTime(2024, 5, 4, 15, 18, 34, 709, DateTimeKind.Local).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8308), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8299), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7910), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7911) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7902), new DateTime(2024, 5, 4, 15, 18, 34, 715, DateTimeKind.Local).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7026), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7002), new DateTime(2024, 5, 4, 18, 18, 34, 708, DateTimeKind.Utc).AddTicks(7024) });
        }
    }
}
