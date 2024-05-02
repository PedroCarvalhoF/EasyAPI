using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PrecoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecoProdutoEntity",
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
                    table.PrimaryKey("PK_PrecoProdutoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecoProdutoEntity_CategoriasPrecos_CategoriaPrecoEntityId",
                        column: x => x.CategoriaPrecoEntityId,
                        principalTable: "CategoriasPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecoProdutoEntity_Produtos_ProdutoEntityId",
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
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8246), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8231), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8252), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(7574), new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(7600), new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6393), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6410), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6407), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6404), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(4918), new DateTime(2024, 4, 25, 16, 58, 37, 839, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 838, DateTimeKind.Utc).AddTicks(2898), new DateTime(2024, 4, 25, 19, 58, 37, 838, DateTimeKind.Utc).AddTicks(2897) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 838, DateTimeKind.Utc).AddTicks(2877), new DateTime(2024, 4, 25, 19, 58, 37, 838, DateTimeKind.Utc).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(9827), new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(9801), new DateTime(2024, 4, 25, 19, 58, 37, 837, DateTimeKind.Utc).AddTicks(9825) });

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProdutoEntity_CategoriaPrecoEntityId",
                table: "PrecoProdutoEntity",
                column: "CategoriaPrecoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProdutoEntity_ProdutoEntityId",
                table: "PrecoProdutoEntity",
                column: "ProdutoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecoProdutoEntity");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(386), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(388) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(375), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(389), new DateTime(2024, 4, 25, 15, 11, 16, 175, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1363), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1382), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9495), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9508), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9506), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9503), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 4, 25, 15, 11, 16, 174, DateTimeKind.Local).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2961), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2954), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2254), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2247), new DateTime(2024, 4, 25, 18, 11, 16, 174, DateTimeKind.Utc).AddTicks(2253) });
        }
    }
}
