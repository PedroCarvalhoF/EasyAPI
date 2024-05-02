using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PontoVendaFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontosVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPerfilAbriuPDV = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPerfilUtilizarPDV = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                        name: "FK_PontosVendas_PerfisUsuarios_IdPerfilAbriuPDV",
                        column: x => x.IdPerfilAbriuPDV,
                        principalTable: "PerfisUsuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PontosVendas_PerfisUsuarios_IdPerfilUtilizarPDV",
                        column: x => x.IdPerfilUtilizarPDV,
                        principalTable: "PerfisUsuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PontosVendas_PeriodosPontosVendas_PeriodoPontoVendaEntityId",
                        column: x => x.PeriodoPontoVendaEntityId,
                        principalTable: "PeriodosPontosVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4100), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4102) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4090), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4098) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4103), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(5013), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(5035), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(5033) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3292), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3296) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3305), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3307) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3301), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3302) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3298), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 4, 29, 16, 2, 26, 231, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6717), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6710), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6709) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6039), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6031), new DateTime(2024, 4, 29, 19, 2, 26, 230, DateTimeKind.Utc).AddTicks(6037) });

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_IdPerfilAbriuPDV",
                table: "PontosVendas",
                column: "IdPerfilAbriuPDV");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_IdPerfilUtilizarPDV",
                table: "PontosVendas",
                column: "IdPerfilUtilizarPDV");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVendas_PeriodoPontoVendaEntityId",
                table: "PontosVendas",
                column: "PeriodoPontoVendaEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosVendas");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3740), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3731), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3752), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3922), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3947), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2657), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2661) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2667), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2668) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2664), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(1936), new DateTime(2024, 4, 29, 13, 11, 2, 903, DateTimeKind.Local).AddTicks(1947) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5951), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5945), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5135), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5127), new DateTime(2024, 4, 29, 16, 11, 2, 902, DateTimeKind.Utc).AddTicks(5134) });
        }
    }
}
