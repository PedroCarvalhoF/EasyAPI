using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FuncoesFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuncoesFuncionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FuncaoFuncionario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Habilitado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncoesFuncionarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2471), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2461), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2475), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(2476) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(1522), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(1543), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(7576), new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(7609) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1225), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1229) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1237), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1234), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1232), new DateTime(2024, 6, 9, 23, 8, 4, 892, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 891, DateTimeKind.Local).AddTicks(9804), new DateTime(2024, 6, 9, 23, 8, 4, 891, DateTimeKind.Local).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(3719), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(3719) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(3713), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(3712) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8373), new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8370), new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8363), new DateTime(2024, 6, 9, 23, 8, 4, 895, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(2753), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(2742), new DateTime(2024, 6, 10, 2, 8, 4, 891, DateTimeKind.Utc).AddTicks(2752) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncoesFuncionarios");

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2783), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2786) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2748), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2788), new DateTime(2024, 6, 9, 11, 6, 16, 668, DateTimeKind.Local).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(2976), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(3007), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(3006) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 676, DateTimeKind.Local).AddTicks(9590), new DateTime(2024, 6, 9, 11, 6, 16, 676, DateTimeKind.Local).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9721), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9753), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9746), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9742), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(5666), new DateTime(2024, 6, 9, 11, 6, 16, 667, DateTimeKind.Local).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9098), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9080), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(9075) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1182), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1174), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1161), new DateTime(2024, 6, 9, 11, 6, 16, 677, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6893) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6856), new DateTime(2024, 6, 9, 14, 6, 16, 665, DateTimeKind.Utc).AddTicks(6888) });
        }
    }
}
