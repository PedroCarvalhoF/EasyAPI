using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FormaPagamentoCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6188), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6178), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6187) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6191), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(6549), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(6569), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(6568) });

            migrationBuilder.InsertData(
                table: "FormasPagamentos",
                columns: new[] { "Id", "CreateAt", "DescricaoFormaPg", "Habilitado", "UpdateAt" },
                values: new object[] { new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"), new DateTime(2024, 4, 30, 0, 13, 39, 804, DateTimeKind.Local).AddTicks(6452), "Dinheiro", true, new DateTime(2024, 4, 30, 0, 13, 39, 804, DateTimeKind.Local).AddTicks(6498) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5285), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5300), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5301) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5296), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5292), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(4361), new DateTime(2024, 4, 30, 0, 13, 39, 797, DateTimeKind.Local).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(8159), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(8153), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(8151) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(7445), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(7447) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(7437), new DateTime(2024, 4, 30, 3, 13, 39, 796, DateTimeKind.Utc).AddTicks(7444) });

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_DescricaoFormaPg",
                table: "FormasPagamentos",
                column: "DescricaoFormaPg",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormasPagamentos");

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
        }
    }
}
