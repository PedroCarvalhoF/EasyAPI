using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterPDVRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5192), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5182), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5203), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(5205) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(4851), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(4846) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(4874), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(8491), new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(8535) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4333), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4328), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4325), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(3147), new DateTime(2024, 5, 11, 9, 47, 52, 373, DateTimeKind.Local).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(6762), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(6754), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(6753) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9229), new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9226), new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9215), new DateTime(2024, 5, 11, 9, 47, 52, 376, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(5764), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(5765) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(5754), new DateTime(2024, 5, 11, 12, 47, 52, 372, DateTimeKind.Utc).AddTicks(5762) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9257), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9243), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9261), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(3410), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(3443), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(2000), new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7504), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7497), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7499) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7490), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(6193), new DateTime(2024, 5, 11, 8, 11, 16, 125, DateTimeKind.Local).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(6122), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(6112), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3364), new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3365) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3360), new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3346), new DateTime(2024, 5, 11, 8, 11, 16, 131, DateTimeKind.Local).AddTicks(3355) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(5321), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(5322) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(5304), new DateTime(2024, 5, 11, 11, 11, 16, 124, DateTimeKind.Utc).AddTicks(5319) });
        }
    }
}
