using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8255), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8242), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8258), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(181), new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6955), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6973) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6983), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6984) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6980), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6976), new DateTime(2024, 6, 13, 1, 29, 39, 83, DateTimeKind.Local).AddTicks(6978) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(9767), new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(9766) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(9758), new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(9757) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1020), new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1016), new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1008), new DateTime(2024, 6, 13, 1, 29, 39, 87, DateTimeKind.Local).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(8649), new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(8624), new DateTime(2024, 6, 13, 4, 29, 39, 82, DateTimeKind.Utc).AddTicks(8647) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5500), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5484), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "CategoriasPrecos",
                keyColumn: "Id",
                keyValue: new Guid("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(5505) });

            migrationBuilder.UpdateData(
                table: "FormasPagamentos",
                keyColumn: "Id",
                keyValue: new Guid("92008957-f185-4563-9d9e-7b71f4ea2691"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("567906bb-6eb4-42e9-b890-10e6da214766"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4226), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("7e107de8-c97a-435b-9976-7a689ca28bb7"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4253), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4251), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "PeriodosPontosVendas",
                keyColumn: "Id",
                keyValue: new Guid("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4246), new DateTime(2024, 6, 13, 0, 7, 32, 225, DateTimeKind.Local).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4989), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "ProdutosMedidas",
                keyColumn: "Id",
                keyValue: new Guid("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8497), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8491), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "SituacoesPedidos",
                keyColumn: "Id",
                keyValue: new Guid("abc0f0f9-3295-439c-a468-795b071b7f22"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8480), new DateTime(2024, 6, 13, 0, 7, 32, 231, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3612), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "TiposProdutos",
                keyColumn: "Id",
                keyValue: new Guid("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3580), new DateTime(2024, 6, 13, 3, 7, 32, 224, DateTimeKind.Utc).AddTicks(3610) });
        }
    }
}
