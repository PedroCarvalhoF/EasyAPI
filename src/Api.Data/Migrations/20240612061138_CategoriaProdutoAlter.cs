using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaProdutoAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos");

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"));

            migrationBuilder.DeleteData(
                table: "CategoriasProdutos",
                keyColumn: "Id",
                keyValue: new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"));

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8739), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8741) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8729), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8742), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6043), new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7768), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7784), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7777), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(7778) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(6355), new DateTime(2024, 6, 12, 3, 11, 37, 505, DateTimeKind.Local).AddTicks(6367) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(9445), new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(9444) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(9435), new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6979), new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6976), new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6977) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6970), new DateTime(2024, 6, 12, 3, 11, 37, 512, DateTimeKind.Local).AddTicks(6974) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(8068), new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(8041), new DateTime(2024, 6, 12, 6, 11, 37, 504, DateTimeKind.Utc).AddTicks(8067) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4919), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4887), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4923), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(4925) });

            migrationBuilder.InsertData(
                table: "CategoriasProdutos",
                columns: new[] { "Id", "CreateAt", "DescricaoCategoria", "FiltroId", "Habilitado", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("a9b05f16-71f0-4f77-a653-52c1a15b36bc"), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(3230), "Executivos", null, true, new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(3224) },
                    { new Guid("d9d229c4-9a64-4836-af41-2f111f229c46"), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(3269), "Bebidas", null, true, new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(3268) }
                });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(6324), new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(6366) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2799), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2822), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2823) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2817), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2813), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(68), new DateTime(2024, 6, 12, 0, 45, 5, 464, DateTimeKind.Local).AddTicks(129) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(7373), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(7361), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7826), new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7821), new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7811), new DateTime(2024, 6, 12, 0, 45, 5, 471, DateTimeKind.Local).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(5638), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 6, 12, 3, 45, 5, 462, DateTimeKind.Utc).AddTicks(5636) });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_DescricaoCategoria",
                table: "CategoriasProdutos",
                column: "DescricaoCategoria",
                unique: true);
        }
    }
}
