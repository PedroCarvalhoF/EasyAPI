using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class PessosContaBancaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CpfCnpj",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_RgIE",
                table: "Pessoas");

            migrationBuilder.AlterColumn<string>(
                name: "RgIE",
                table: "Pessoas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BancoSalario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Agencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaComDigito = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaDadosBancarios",
                columns: table => new
                {
                    PessoaEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DadosBancariosEntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaDadosBancarios", x => new { x.PessoaEntityId, x.DadosBancariosEntityId });
                    table.ForeignKey(
                        name: "FK_PessoaDadosBancarios_DadosBancarios_DadosBancariosEntityId",
                        column: x => x.DadosBancariosEntityId,
                        principalTable: "DadosBancarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaDadosBancarios_Pessoas_PessoaEntityId",
                        column: x => x.PessoaEntityId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4623), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4614), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4626), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(4627) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(4648), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(4669), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(4205), new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3617), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3630), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3627), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3628) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3624), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(2179), new DateTime(2024, 6, 8, 1, 14, 13, 586, DateTimeKind.Local).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(6649), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(6649) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(6642), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5113), new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5110), new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5103), new DateTime(2024, 6, 8, 1, 14, 13, 589, DateTimeKind.Local).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(5824), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(5825) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(5808), new DateTime(2024, 6, 8, 4, 14, 13, 585, DateTimeKind.Utc).AddTicks(5813) });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaDadosBancarios_DadosBancariosEntityId",
                table: "PessoaDadosBancarios",
                column: "DadosBancariosEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaDadosBancarios");

            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "RgIE",
                keyValue: null,
                column: "RgIE",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RgIE",
                table: "Pessoas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2366), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2355), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2364) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2370), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(5584), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(5608), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 193, DateTimeKind.Local).AddTicks(8167), new DateTime(2024, 6, 3, 2, 53, 52, 193, DateTimeKind.Local).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(687), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(716), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(712), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(696), new DateTime(2024, 6, 3, 2, 53, 52, 184, DateTimeKind.Local).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 183, DateTimeKind.Local).AddTicks(8959), new DateTime(2024, 6, 3, 2, 53, 52, 183, DateTimeKind.Local).AddTicks(8973) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(9445), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(9444) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(9363), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(368), new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(369) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(365), new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(356), new DateTime(2024, 6, 3, 2, 53, 52, 194, DateTimeKind.Local).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(7768), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(7771) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(7758), new DateTime(2024, 6, 3, 5, 53, 52, 182, DateTimeKind.Utc).AddTicks(7766) });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CpfCnpj",
                table: "Pessoas",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_RgIE",
                table: "Pessoas",
                column: "RgIE",
                unique: true);
        }
    }
}
